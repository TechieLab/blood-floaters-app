using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using AutoMapper;
using BloodFloater.Services;
using BloodFloater.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using DomainModels = BloodFloater.Models;

namespace BloodFloater.Web.Api.Helpers
{
    public class JwtAuthHelper
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IUserService _userService;

        public JwtAuthHelper(IUserService userService, JwtIssuerOptions jwtOptions)
        {
            _userService = userService;
            _jwtOptions = jwtOptions;
        }

        public Result GetAuthTokenResult(Login model)
        {
            ThrowIfInvalidOptions(_jwtOptions);

            var existUser = _userService.ValidateUser(model.UserName, model.Password);

            if (existUser == null)
                return new Result
                {
                    Success = false,
                    Message = "Invalid username or passward"
                };

            var requestAt = DateTime.Now;
            var expiresIn = requestAt + _jwtOptions.ValidFor;
            var token = GenerateToken(existUser, expiresIn);
               
            var result = new Result
            {
                Success = true,
                Message = "Authenticated succesfully",
                Content = new
                {
                    access_token = token,
                    context = existUser,
                    expires = expiresIn,
                }
            };

            return result;
        }

        private string GenerateToken(User user, DateTime expires)
        {
            var handler = new JwtSecurityTokenHandler();

            var identity = new ClaimsIdentity(
                new GenericIdentity(user.UserName, "TokenAuth"),
                new[] { new Claim("UserName", user.UserName) }
            );

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = _jwtOptions.SigningCredentials,
                Subject = identity,
                Expires = expires
            });
            return handler.WriteToken(securityToken);
        }

        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }
    }
}

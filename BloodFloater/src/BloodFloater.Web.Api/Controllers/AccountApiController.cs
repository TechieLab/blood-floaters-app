
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BloodFloater.Services;
using BloodFloater.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DomainModels = BloodFloater.Models;

namespace BloodFloater.Web.Api.Controllers
{
    [Route("api/account")]
    [EnableCors("CorsPolicy")]
    public class AccountApiController
    {
        private readonly IUserService _userService;
        public AccountApiController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpPost("authenticate")]
        //public async Task<Result> Login([FromBody] Login model)
        //{
        //    var result = new Result();

        //    try
        //    {
        //        var user = _userService.ValidateUser(model.Username, model.Password);

        //        if (user != null)
        //        {
        //            List<Claim> claims = new List<Claim>();

        //            Claim claim = new Claim(ClaimTypes.Role, "User", ClaimValueTypes.String, model.Username);
        //            claims.Add(claim);

        //            result.Success = true;
        //            result.Message = "Authentication succeeded";
        //            result.Content = user;
        //        }
        //        else
        //        {
        //            result.Success = true;
        //            result.Message = "Invalid Username or password!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Success = false;
        //        result.Message = ex.Message;

        //        //_loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
        //        //_loggingRepository.Commit();
        //    }

        //    return result;
        //}

        [HttpPost("logout")]
        public async void Logout()
        {
            try
            {
               // await HttpContext.Authentication.SignOutAsync("Cookies");

            }
            catch (Exception ex)
            {
                //_loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
                //_loggingRepository.Commit();


            }
        }

        [Route("register")]
        [HttpPost]
        public Result Register([FromBody] Registration user)
        {
            var result = new Result();

            try
            {

                var tempUser = new User
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    EmailId = user.EmailId,
                    RememberMe = user.RememberMe
                };

                _userService.Create(Mapper.Map<User, DomainModels.User>(tempUser));

                result.Success = true;
                result.Message = "Registration succeeded";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Registration failed" + ex.Message;
            }

            return result;
        }
    }
}

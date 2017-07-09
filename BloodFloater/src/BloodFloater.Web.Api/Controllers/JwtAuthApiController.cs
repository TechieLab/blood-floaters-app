using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using BloodFloater.Services;
using BloodFloater.ViewModels;
using BloodFloater.Web.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BloodFloater.Web.Api.Controllers
{
    [Route("api/jwt-auth")]
    [EnableCors("CorsPolicy")]
    public class JwtAuthApiController : Controller
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly ILogger _logger;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IUserService _userService;

        public JwtAuthApiController(IUserService userService, IOptions<JwtIssuerOptions> jwtOptions,
            ILoggerFactory loggerFactory)
        {
            _userService = userService;

            _jwtOptions = jwtOptions.Value;

            _logger = loggerFactory.CreateLogger<JwtAuthApiController>();

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var jwtHelper = new JwtAuthHelper(_userService, _jwtOptions);
            var result = jwtHelper.GetAuthTokenResult(model);

            var json = JsonConvert.SerializeObject(result, _serializerSettings);

            if (result.Success)
            {
                return new OkObjectResult(json);
            }
            else
            {
                return new BadRequestObjectResult(JsonConvert.SerializeObject(result, _serializerSettings));
            }
        }
    }
}
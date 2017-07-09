using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DomainModels = BloodFloater.Models;
using BloodFloater.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BloodFloater.Services;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodFloater.Web.Api.Controllers
{
    [EnableCors("CorsPolicy")]
    public class UsersController : BaseApiController<DomainModels.User,User>
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        ////[Route("api/users/getUserByName/{userName:string}")]
        //[HttpGet("api/users/GetUserByName/{userName}")]
        //public User GetUserByName(string userName)
        //{
        //    return Mapper.Map<DomainModels.User, User>(_userService.GetUserByName(userName));
        //}
    }
}

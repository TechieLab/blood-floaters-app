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
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodFloater.Web.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;

        public UsersController(IUserService userService, IProfileService profileService)
        {
            _userService = userService;
            _profileService = profileService;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            string userName = HttpContext.Request.Query["userName"].ToString();

            if (string.IsNullOrEmpty(userName))
            {
                return new BadRequestObjectResult("UserName cannot be null");
            }

            return StatusCode(200, _userService.GetSingle(u => u.UserName == userName));
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _userService.Get(id);
            if (user != null)
            {
                var profile = _profileService.GetSingle(p => p.UserId == user.Id);
                if (profile != null)
                {
                    user.ProfileId = profile.Id;
                }
            }

            return user;
        }

        [HttpPost("search")]
        public List<User> Search(SearchCriteria criteria)
        {
            //return _userService.Search(criteria);
            return null;
        }

        [HttpPost]
        public virtual void Post([FromBody]User value)
        {
            _userService.Create(Mapper.Map<User, DomainModels.User>(value));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User value)
        {
            _userService.Update(Mapper.Map<User, DomainModels.User>(value));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }
    }
}

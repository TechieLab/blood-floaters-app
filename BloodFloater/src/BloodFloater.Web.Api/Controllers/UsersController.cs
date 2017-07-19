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
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodFloater.Web.Api.Controllers
{
    [Route("api/users")]
    public class UsersController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.Get(id);
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

        [HttpGet("GetUserByName/{userName}")]
        public User GetUserByName(string userName)
        {
            return _userService.Get(u => u.UserName == userName).FirstOrDefault();
        }
    }
}

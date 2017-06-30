using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.Models;
using Microsoft.AspNetCore.Mvc;
using BloodFloater.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodFloater.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseApiController<User>
    {
        public UserController(IUserService userService) : base(userService)
        {
            
        }
    }
}

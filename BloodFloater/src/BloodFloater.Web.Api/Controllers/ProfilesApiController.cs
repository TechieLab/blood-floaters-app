using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BloodFloater.Services;
using BloodFloater.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Profile = BloodFloater.ViewModels.Profile;
using DomainModels = BloodFloater.Models;

namespace BloodFloater.Web.Api.Controllers
{
    [Route("api/profiles")]
    public class ProfilesApiController:BaseApiController
    {
        private readonly IProfileService _profileService;

        public ProfilesApiController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("{id}")]
        public Profile Get(int id)
        {
            return _profileService.Get(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Profile value)
        {
            try
            {
                return new OkObjectResult(new Result
                {
                    Success = _profileService.Create(Mapper.Map<Profile, DomainModels.Profile>(value)) != 0,
                    Message = "Profile Updated",
                    Content = _profileService.Create(Mapper.Map<Profile, DomainModels.Profile>(value))
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Result
                {
                    Success = _profileService.Update(Mapper.Map<Profile, DomainModels.Profile>(value)) != 0,
                    Message = "Profile Update Failed",
                    Content = ex.InnerException.Message
                });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Profile value)
        {
            try
            {
                return new OkObjectResult(new Result
                {
                    Success = _profileService.Update(Mapper.Map<Profile, DomainModels.Profile>(value)) != 0,
                    Message = "Profile Updated"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Result
                {
                    Success = false,
                    Message = "Profile Update Failed",
                    Content = ex.InnerException.Message
                });
            }
        }
    }
} 

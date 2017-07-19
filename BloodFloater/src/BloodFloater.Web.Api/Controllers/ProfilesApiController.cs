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
        public virtual void Post([FromBody]Profile value)
        {
            _profileService.Create(Mapper.Map<Profile, DomainModels.Profile>(value));
        }

        [HttpPut]
        public void Put([FromBody]Profile value)
        {
            _profileService.Update(Mapper.Map<Profile, DomainModels.Profile>(value));
        }
    }
}

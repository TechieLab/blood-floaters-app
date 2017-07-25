using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BloodFloater.Services;
using BloodFloater.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using DomainModels = BloodFloater.Models;

namespace BloodFloater.Web.Api.Controllers
{
    [Route("api/lookups")]
    public class LookupsApiController : BaseApiController
    {
        private readonly ILookupService _lookupService;

        public LookupsApiController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet]
        public List<Lookup> Get()
        {
            var key = HttpContext.Request.Query["key"].ToString();
            var value = HttpContext.Request.Query["value"].ToString();

            return _lookupService.GetByKeyValue(key, value);
        }
    }
}

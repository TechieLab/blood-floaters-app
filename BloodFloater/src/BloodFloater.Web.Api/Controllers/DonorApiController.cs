using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BloodFloater.Services;
using BloodFloater.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DomainModels = BloodFloater.Models;

namespace BloodFloater.Web.Api.Controllers
{
    [Route("api/donors")]
    public class DonorApiController:BaseApiController
    {
        private readonly IDonorService _donorService;

        public DonorApiController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        [HttpPost]
        public virtual void Post([FromBody]Donor value)
        {
            _donorService.Create(Mapper.Map<Donor, DomainModels.Donor>(value));
        }
    }
}

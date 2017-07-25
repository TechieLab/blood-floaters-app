using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BloodFloater.Services;
using BloodFloater.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DomainModels = BloodFloater.Models;

namespace BloodFloater.Web.Api.Controllers
{
    [Route("api/donors")]
    public class DonorsApiController:BaseApiController
    {
        private readonly IDonorService _donorService;

        public DonorsApiController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        [HttpGet]
        public Donor Get()
        {
            int profileId = Convert.ToInt32(HttpContext.Request.Query["profileId"].ToString());
            return _donorService.GetSingle(d => d.ProfileId == profileId);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Donor value)
        {
            try
            {
                return new OkObjectResult(new Result
                {
                    Success = _donorService.Create(Mapper.Map<Donor, DomainModels.Donor>(value)) != 0,
                    Message = "Donor created"
                });
            }
            catch (Exception ex)
            {
               return StatusCode(500,new Result
                {
                    Success = false,
                    Message = "Donor Creation Failed",
                    Content = ex.InnerException.Message
                });
            }
        }
    }
}

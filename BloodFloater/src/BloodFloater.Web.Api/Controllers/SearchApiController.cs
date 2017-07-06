using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.Services;
using BloodFloater.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BloodFloater.Web.Api.Controllers
{
    [Route("api/search")]
    [DisableCors]
    public class SearchApiController
    {
        private readonly ISearchService _searchService;

        public SearchApiController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        // POST api/values
        [HttpPost]
        public void Post(SearchCriteria criteria)
        {
            
        }
    }
}

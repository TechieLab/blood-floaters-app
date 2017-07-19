using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.DAL;
using BloodFloater.Models;
using Microsoft.Extensions.Logging.Abstractions;
using MongoDB.Driver;

namespace BloodFloater.Services.Impl
{
    public class LookupService:BaseService<Lookup, ViewModels.Lookup>, ILookupService
    {
        private readonly ILookupRepository _lookupRepository;
        public LookupService(ILookupRepository lookupRepository) : base(lookupRepository)
        {
            _lookupRepository = lookupRepository;
        }

        public List<Lookup> GetByKeyValue(string key, string value)
        {
            return null;
        }
    }
}

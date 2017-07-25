using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BloodFloater.DAL;
using BloodFloater.Models;

namespace BloodFloater.Services.Impl
{
    public class LookupService:BaseService<Lookup, ViewModels.Lookup>, ILookupService
    {
        private readonly ILookupRepository _lookupRepository;
        public LookupService(ILookupRepository lookupRepository) : base(lookupRepository)
        {
            _lookupRepository = lookupRepository;
        }

        public List<ViewModels.Lookup> GetByKeyValue(string key, string value)
        {
            List<ViewModels.Lookup> list;

            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                list =
                    Mapper.Map<List<Lookup>, List<ViewModels.Lookup>>(
                        _lookupRepository.Get(l => l.Key == key && l.Value == value).ToList());
            }
            else
            {
                list =
                    Mapper.Map<List<Lookup>, List<ViewModels.Lookup>>(
                        _lookupRepository.Get(l => l.Key == key).ToList());
            }

            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.Models;

namespace BloodFloater.Services
{
    public interface ILookupService: IBaseService<Lookup, ViewModels.Lookup>
    {
        List<ViewModels.Lookup> GetByKeyValue(string key, string value);
    }
}

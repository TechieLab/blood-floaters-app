using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.DAL;
using BloodFloater.Models;

namespace BloodFloater.Services.Impl
{
    public class ProfileService : BaseService<Profile, ViewModels.Profile>, IProfileService
    {
        public ProfileService(IProfileRepository repository) : base(repository)
        {
        }
    }
}

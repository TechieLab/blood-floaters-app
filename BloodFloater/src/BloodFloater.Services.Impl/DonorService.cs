using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.DAL;
using BloodFloater.Models;

namespace BloodFloater.Services.Impl
{
    public class DonorService : BaseService<Donor, ViewModels.Donor>, IDonorService
    {
        public DonorService(IDonorRepository repository) : base(repository)
        {
        }
    }
}

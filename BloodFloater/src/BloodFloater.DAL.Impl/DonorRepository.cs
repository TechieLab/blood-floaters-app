using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.Core;
using BloodFloater.Models;
using BloodFloater.DAL;

namespace BloodFloater.DAL.Impl
{
    public class DonorRepository  : BaseEntityRepository<Donor>, IDonorRepository
    {
        public DonorRepository(BloodFloaterContext context) : base(context)
        {
           
        }
    }
}

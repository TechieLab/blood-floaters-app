using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.Core;
using BloodFloater.Models;

namespace BloodFloater.DAL.Impl
{
    public class DonorRepository  : BaseRepository<Donor>, IDonorRepository
    {
        public DonorRepository(IMongoDbManager mongoDbManager) : base(mongoDbManager)
        {
            SetCollection(mongoDbManager.GetCollection<Donor>("donors"));
        }
    }
}

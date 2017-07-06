using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.DAL;
using BloodFloater.Models;

namespace BloodFloater.Services.Impl
{
    public class ReceiverService : BaseService<Receiver>, IReceiverService
    {
        public ReceiverService(IBaseRepository<Receiver> repository) : base(repository)
        {
        }
    }
}

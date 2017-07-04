using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.Core;
using BloodFloater.Models;

namespace BloodFloater.DAL.Impl
{
    public class ReceiverRepository  : BaseRepository<Receiver>, IReceiverRepository
    {
        public ReceiverRepository(IMongoDbManager mongoDbManager) : base(mongoDbManager)
        {
            SetCollection(mongoDbManager.GetCollection<Receiver>("profiles"));
        }
    }
}

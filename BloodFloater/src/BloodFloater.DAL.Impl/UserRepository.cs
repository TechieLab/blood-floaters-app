using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.Core;
using BloodFloater.Models;

namespace BloodFloater.DAL.Impl
{
    public class UserRepository  : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDbManager mongoDbManager) : base(mongoDbManager)
        {
        }
    }
}

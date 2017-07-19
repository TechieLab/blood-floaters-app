using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.Core;
using BloodFloater.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BloodFloater.DAL.Impl
{
    public class UserRepository  : BaseEntityRepository<User>, IUserRepository
    {
        public UserRepository(BloodFloaterContext context) : base(context)
        {

        }
    }
}

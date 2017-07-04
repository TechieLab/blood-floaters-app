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
    public class UserRepository  : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDbManager mongoDbManager) : base(mongoDbManager)
        {
            SetCollection(mongoDbManager.GetCollection<User>("users"));
        }

        public User GetByName(string userName)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Eq("UserName", userName);

            return Get(filter, null, null).FirstOrDefault();
        }
    }
}

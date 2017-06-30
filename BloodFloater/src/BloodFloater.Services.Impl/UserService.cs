using BloodFloater.Core;
using BloodFloater.Models;
using BloodFloater.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.DAL;

namespace BloodFloater.Services.Impl
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            
        }
    }
}

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
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public User ValidateUser(string userName, string pwd)
        {
            return _userRepository.GetByName(userName);
        }
    }
}

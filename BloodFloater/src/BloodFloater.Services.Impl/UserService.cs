using BloodFloater.Core;
using BloodFloater.Models;
using BloodFloater.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BloodFloater.Core.CustomExceptions;
using BloodFloater.DAL;
using DomainModels = BloodFloater.Models;

namespace BloodFloater.Services.Impl
{
    public class UserService : BaseService<User, ViewModels.User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;

        public UserService(IUserRepository userRepository, IProfileRepository profileRepository) : base(userRepository)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
        }

        public override int Create(User entity)
        {
            var userId = _userRepository.Add(entity);
            if (userId != 0)
            {
                var contacts = new List<DomainModels.Contact>
                {
                    new DomainModels.Contact
                    {
                        EmailId = entity.EmailId,
                        PhoneNumber = entity.PhoneNumber
                    }
                };

                var profile = new DomainModels.Profile
                {
                    UserId = userId,
                    FullName = entity.UserName,
                    Contacts = contacts,
                    DoB = new DateTime()
                };

                _profileRepository.Add(profile);
            }

            return userId;
        }

        public ViewModels.User ValidateUser(string userName, string pwd)
        {
            var user =  _userRepository.GetSingle(u => u.UserName.ToLower() == userName.ToLower());

            if (user != null)
            {
                if (user.HashedPassword == pwd)
                {
                    var result = Mapper.Map<User, ViewModels.User>(user);

                    var profile = _profileRepository.GetSingle(p => p.UserId == user.Id);

                    if (profile != null)
                    {
                        result.ProfileId = profile.Id;
                    }

                    return result;
                }
            }

            return null;
        }
    }
}

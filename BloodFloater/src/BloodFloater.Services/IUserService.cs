using BloodFloater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Services
{
   public interface IUserService : IBaseService<User, ViewModels.User>
   {
       ViewModels.User ValidateUser(string userName, string pwd);
   }
}

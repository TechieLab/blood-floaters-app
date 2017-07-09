using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.ViewModels
{
    public class User
    {
        public string Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public bool RememberMe { get; set; }
        public int PageSize { get; set; }
        public int Timeout { get; set; }
        public Profile Profile { get; set; }

        public User()
        {
            this.Profile = new Profile();
        }
    }
}

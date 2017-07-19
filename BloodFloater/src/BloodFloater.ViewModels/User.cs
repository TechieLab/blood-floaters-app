using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.ViewModels
{
    public class User
    {
        public int Id { get; set; }

        public int ProfileId { get; set; }

        public string UserName { get; set; }

        public string EmailId { get; set; }

        public string PhoneNumber { get; set; }

        public bool RememberMe { get; set; }

        public int PageSize { get; set; }

        public int Timeout { get; set; }
    }
}

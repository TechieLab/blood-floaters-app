using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public string HashedPassword { get; set; }

        public string EmailId { get; set; }

        public string PhoneNumber { get; set; }

        public bool RememberMe { get; set; }

        public int PageSize { get; set; }

        public int Timeout { get; set; }

        public string Salt { get; set; }

        public bool IsLocked { get; set; }
    }
}

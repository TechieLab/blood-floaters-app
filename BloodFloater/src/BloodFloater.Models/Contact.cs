using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public string LandLineNumber { get; set; }

        public string AltPhoneNumber { get; set; }

        public string EmailId { get; set; }

        public string AltEmailId { get; set; }

        public int ProfileId { get; set; }

        public virtual Profile Profile { get; set; }
    }
}

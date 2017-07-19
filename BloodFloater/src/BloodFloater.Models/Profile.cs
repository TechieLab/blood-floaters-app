using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public class Profile : BaseEntity
    {
        public string FullName { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public DateTime DoB { get; set; }

        public int AddressId { get; set; }

        public int ContactId { get; set; }

        public int MediaId { get; set; }

        public int UserId { get; set; }

        public virtual List<Address> Addresses { get; set; }

        public virtual List<Contact> Contacts { get; set; }

        public virtual List<Media> Photos { get; set; }

        public virtual User User { get; set; }
    }
}

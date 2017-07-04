using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public class Profile
    {
        public Address CurrentAddress { get; set; }

        public Address PermanentAddress { get; set; }

        public Contact Contact { get; set; }

        public Profile()
        {
            CurrentAddress = new Address();
            PermanentAddress = new Address();
            Contact = new Contact();
        }
    }
}

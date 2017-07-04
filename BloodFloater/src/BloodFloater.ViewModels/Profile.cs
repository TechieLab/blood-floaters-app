using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.ViewModels
{
    public class Profile
    {
        public string FullName { get; set; }
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

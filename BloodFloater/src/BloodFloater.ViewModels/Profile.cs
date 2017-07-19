using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.ViewModels
{
    public class Profile
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public Address Address { get; set; }

        public Contact Contact { get; set; }

        public Media Media { get; set; }

        public Profile()
        {
            Address = new Address();
            Contact = new Contact();
            Media = new Media();
        }
    }
}

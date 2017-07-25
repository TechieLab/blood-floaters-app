using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.ViewModels
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Landmark { get; set; }
        public bool IsOfficeAddress { get; set; }
        public bool IsPermanetAddress { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }

        public int ProfileId { get; set; }
    }
}

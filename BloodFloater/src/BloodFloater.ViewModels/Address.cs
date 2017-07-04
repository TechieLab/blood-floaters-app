using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.ViewModels
{
    public class Address
    {

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Landmark { get; set; }
        public string IsOfficeAddress { get; set; }
        public string IsPermanetAddress { get; set; }
        public string StateId { get; set; }
        public string CounntryId { get; set; }
    }
}

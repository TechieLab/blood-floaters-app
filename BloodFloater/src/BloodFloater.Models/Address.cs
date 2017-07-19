using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public class Address : BaseEntity
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Street { get; set; }


        public string City { get; set; }

        public string Landmark { get; set; }

        public string IsOfficeAddress { get; set; }

        public string IsPermanetAddress { get; set; }

        public string IsHomeAddress { get; set; }

        public int StateId { get; set; }
        public int CounntryId { get; set; }

        public string LongCord { get; set; }

        public string LatCord { get; set; }

        public virtual Lookup Country { get; set; }

        public virtual Lookup State { get; set; }

      
    }
}

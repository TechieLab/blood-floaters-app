using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public class Donor: BaseEntity
    {
        public int ProfileId { get; set; }

        public int DonationId { get; set; }

        public Profile Profile { get; set; }

        public virtual Donation Donation { get; set; }

        public virtual List<Donation> PastDonations { get; set; }
    }
}

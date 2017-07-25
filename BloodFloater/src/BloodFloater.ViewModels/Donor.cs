using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.ViewModels
{
    public class Donor
    {
        public int Id { get; set; }

        public int ProfileId { get; set; }

        public int DonationId { get; set; }

        public Donation Donation { get; set; }

        public List<Donation> PastDonations { get; set; }
    }
}

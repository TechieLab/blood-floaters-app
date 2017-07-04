using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public class Donor: BaseEntity
    {
        public string DonorId { get; set; }

        public string ProfileId { get; set; }

        public Donation Donation { get; set; }

        public List<DonorHistory> DonorHistories { get; set; }

        public Donor()
        {
            this.Donation = new Donation();
            this.DonorHistories = new List<DonorHistory>();
        }
    }
}

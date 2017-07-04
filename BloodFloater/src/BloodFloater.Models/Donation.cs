using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public class Donation
    {
        public DateTime DontatedOn { get; set; }

        public Location DonatedAt {get; set;}

        public Receiver Receipiant { get; set; }
    }
}

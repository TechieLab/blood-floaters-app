using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BloodFloater.ViewModels
{
    public class Donor
    {
        public ObjectId Id { get; set; }
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

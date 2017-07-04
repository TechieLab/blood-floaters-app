﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public class DonorHistory
    {
        public Donation Donation { get; set; }
        public DateTime LastDonatedOn { get; set; }
    }
}

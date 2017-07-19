﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.ViewModels
{
    public class Donation
    {
        public DateTime DontatedOn { get; set; }

        public Address DonatedAt {get; set;}

        public Receiver Receipiant { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.Models;

namespace BloodFloater.Services
{
    public interface ISearchService
    {
        List<Donor> FindDonor();
    }
}

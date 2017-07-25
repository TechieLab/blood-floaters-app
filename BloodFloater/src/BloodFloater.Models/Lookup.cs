using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public class Lookup : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

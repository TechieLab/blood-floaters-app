using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public class Profile : BaseEntity
    {
        public string FullName { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public DateTime DoB { get; set; }

        public int UserId { get; set; }
        
        public virtual Address Address { get; set; }

        public virtual Contact Contact { get; set; }

        public virtual List<Media> Photos { get; set; }

        public virtual User User { get; set; }
    }
}

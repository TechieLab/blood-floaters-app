using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public class Receiver : BaseEntity
    {
        public int ReceiverId { get; set; }

        public string ProfileId { get; set; }

        public Receiver()
        {
            
        }
    }
}

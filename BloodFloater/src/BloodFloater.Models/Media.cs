using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public class Media : BaseEntity
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public DateTime UploadedOn { get; set; }
    }
}

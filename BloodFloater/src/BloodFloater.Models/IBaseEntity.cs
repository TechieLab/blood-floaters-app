using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        DateTime CreatedOn { get; set; }

        int CreatedBy { get; set; }

        DateTime ModifiedOn { get; set; }

        int ModifiedBy { get; set; }
    }
}

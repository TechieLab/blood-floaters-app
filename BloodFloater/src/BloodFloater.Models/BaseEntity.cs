using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Models
{
    public class BaseEntity
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id{ get; set; }
               
    }
}

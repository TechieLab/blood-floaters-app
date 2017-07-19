using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Core.CustomExceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string user) : base("user")
        {
        }
    }
}

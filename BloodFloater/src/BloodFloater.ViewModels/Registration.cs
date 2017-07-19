using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.ViewModels
{
    public class Registration
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]

        [EmailAddress]
        public string EmailId { get; set; }

        public string PhoneNumber { get; set; }

        public bool RememberMe { get; set; }
    }
}

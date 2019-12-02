using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.BindingTargets
{
    public class UserForRegisterData
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "You must specify password between 3 and characters")]
        public string Password { get; set; }
    }
}

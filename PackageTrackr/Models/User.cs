using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PackageTrackr.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(30, MinimumLength = 4)]
        public string UserName { get; set; }
        [Required, StringLength(25, MinimumLength = 6)]
        public string Password { get; set; }
        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PackageTrackr.Models
{
    public class Package
    {
        public Package()
        {
            EnteredDate = DateTime.Now;
        }
        public int Id { get; set; }
        [Required, StringLength(11,MinimumLength = 11)]
        [Index("AWBIndex", IsUnique = true)]
        public string AWB { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnteredDate { get; private set; }

        [Display(Name = "Package Status")]
        public PackageStatus PackageStatus { get; set; }

        [Required]
        public byte PackageStatusId { get; set; }
    }

    
}
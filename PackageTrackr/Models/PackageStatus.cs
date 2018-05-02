using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PackageTrackr.Models
{
    public class PackageStatus
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Package> Packages { get; set; }
    }
}
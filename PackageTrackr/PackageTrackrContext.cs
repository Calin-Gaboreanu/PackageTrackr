using PackageTrackr.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace PackageTrackr
{
    public class PackageTrackrContext : DbContext
    {
        public PackageTrackrContext() : base("PackageTrackrContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageStatus> PackageStatuses { get; set; }
    }
}
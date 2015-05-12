using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppRent.DataAccess.Migrations;
using AppRent.Entities.Models;

using Microsoft.AspNet.Identity.EntityFramework;


namespace AppRent.DataAccess.Contexts
{
    public class ApartmentContext : IdentityDbContext<ApplicationUser>
    {
        public ApartmentContext()
            : base("ApartmentRentConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApartmentContext, Configuration>());
        }

        public static ApartmentContext Create()
        {
            return new ApartmentContext();
        }

        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<Metro> Metros { get; set; }

        public DbSet<Street> Streets { get; set; }

        public DbSet<House> Houses { get; set; }

       
    }
}

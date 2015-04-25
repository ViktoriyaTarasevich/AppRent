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
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApartmentContext, Configuration>());
        }

        public static ApartmentContext Create()
        {
            return new ApartmentContext();
        }
    }
}

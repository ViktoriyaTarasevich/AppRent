using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppRent.DataAccess.Contexts;


namespace AppRent.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApartmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApartmentContext context)
        {
            
        }
    }
}


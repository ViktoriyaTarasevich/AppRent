using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRent.Entities.Models
{
    public class House : BaseEntity
    {
        public int Number { get; set; }

        public int? Corp { get; set; }

        public int StreetId { get; set; }

        public virtual Street Street { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; } 
    }
}

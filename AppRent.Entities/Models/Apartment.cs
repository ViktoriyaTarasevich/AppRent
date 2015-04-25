using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRent.Entities.Models
{
    public class Apartment : BaseEntity
    {
        public string Description { get; set; }

        public int RoomsNumbers { get; set; }

        public int Price { get; set; }

        public int ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Photo> Photos { get; set; } 

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Column("ApplicationUser_Id")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        [Column("House_Id")]
        public int HouseId { get; set; }

        public virtual House House { get; set; }

    }
}

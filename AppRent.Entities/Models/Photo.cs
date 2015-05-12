using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRent.Entities.Models
{
    public class Photo: BaseEntity
    {
        public string Path { get; set; }

        public string Description { get; set; }

        public bool IsMain { get; set; }

        [Column("Apartment_Id")]
        public int? ApartmentId { get; set; }

        public virtual Apartment Apartment { get; set; } 
    }
}

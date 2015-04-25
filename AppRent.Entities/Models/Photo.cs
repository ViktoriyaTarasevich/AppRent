using System;
using System.Collections.Generic;
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

        public Apartment Apartment { get; set; } 
    }
}

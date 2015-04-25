using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRent.Entities.Models
{
    public class District : BaseEntity
    {
        public string Title { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}

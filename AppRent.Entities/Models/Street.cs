using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRent.Entities.Models
{
    public class Street : BaseEntity
    {
        public string Title { get; set; }

        public int DistrictId { get; set; }

        public District District { get; set; }
    }
}

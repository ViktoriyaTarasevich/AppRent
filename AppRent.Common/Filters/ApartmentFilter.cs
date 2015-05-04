using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRent.Common.Filters
{
    public class ApartmentFilter
    {
        public CityFilter CityFilter { get; set; }

        public PriceFilter PriceFilter { get; set; }

        public RoomsCountFilter RoomsCountFilter { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppRent.Common.Enums;


namespace AppRent.Common.Filters
{
    public class CityFilter : SearchFilter
    {
        public string City { get; set; }
    }
}

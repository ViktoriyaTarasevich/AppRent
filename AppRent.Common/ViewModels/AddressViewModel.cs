using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRent.Common.ViewModels
{
    public class AddressViewModel
    {
        public string City { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public int HouseNumber { get; set; }

        public string Corpus { get; set; }
    }
}

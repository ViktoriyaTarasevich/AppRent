using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRent.Common.ViewModels
{
    public class ApartmentViewModel
    {
        public int Id { get; set; }

        public string PathToPhoto { get; set; }

        public string Street { get; set; }

        public int House { get; set; }

        public int Price { get; set; }

        public int RoomsCount { get; set; }
    }
}

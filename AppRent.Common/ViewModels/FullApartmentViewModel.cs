using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRent.Common.ViewModels
{
    public class FullApartmentViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int RoomsCount { get; set; }

        public UserViewModel User { get; set; }

        public AddressViewModel Address { get; set; }

        public IEnumerable<PhotoViewModel> Photos { get; set; } 
    }
}

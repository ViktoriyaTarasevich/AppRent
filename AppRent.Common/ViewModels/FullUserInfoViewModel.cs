using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRent.Common.ViewModels
{
    public class FullUserInfoViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Rolename { get; set; }

        public IEnumerable<ApartmentViewModel> Apartments { get; set; }
  
  
    }
}

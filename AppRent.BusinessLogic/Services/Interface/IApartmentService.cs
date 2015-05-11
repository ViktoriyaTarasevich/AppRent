using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppRent.Common.ViewModels;
using AppRent.Entities.Models;


namespace AppRent.BusinessLogic.Services.Interface
{
    public interface IApartmentService
    {
        IEnumerable<ApartmentViewModel> GetApartments();

        FullApartmentViewModel GetApartmentById(int id);

        void Save(FullApartmentViewModel viewModel);

        IEnumerable<ApartmentViewModel> GetApartmentsByUserId(string userId);

        ApartmentViewModel MapToViewModel(Apartment model);
    }
}

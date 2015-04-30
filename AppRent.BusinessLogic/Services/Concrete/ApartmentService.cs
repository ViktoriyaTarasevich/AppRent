using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppRent.BusinessLogic.Services.Interface;
using AppRent.Common.ViewModels;
using AppRent.DataAccess.Repositories.Interface;
using AppRent.DataAccess.UnitOfWork.Interface;
using AppRent.Entities.Models;


namespace AppRent.BusinessLogic.Services.Concrete
{
    public class ApartmentService : IApartmentService
    {
        private readonly IBaseRepository<Apartment,int> _apartmentRepository;
        public ApartmentService(IUnitOfWork unitOfWork)
        {
            _apartmentRepository = unitOfWork.GetRepository<Apartment,int>();
        }

        public IEnumerable<ApartmentViewModel> GetApartments()
        {
            return _apartmentRepository.GetAll().Select(MapToViewModel);
        }

        private ApartmentViewModel MapToViewModel(Apartment model)
        {
            var viewModel = new ApartmentViewModel
            {
                Id = model.Id,
                Price = model.Price,
                RoomsCount = model.RoomsNumbers,
                Street = model.House.Street.Title,
                House = model.House.Number,
                PathToPhoto = model.Photos.FirstOrDefault(x=>x.IsMain).Path

            };
            return viewModel;
        }
    }
}

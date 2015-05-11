using System.Collections.Generic;
using System.Linq;

using AppRent.BusinessLogic.Services.Interface;
using AppRent.Common.ViewModels;
using AppRent.DataAccess.Repositories.Interface;
using AppRent.DataAccess.UnitOfWork.Interface;
using AppRent.Entities.Models;

using Microsoft.AspNet.Identity;


namespace AppRent.BusinessLogic.Services.Concrete
{
    public class ApartmentService : IApartmentService
    {
        private readonly IBaseRepository<Apartment,int> _apartmentRepository;
        private readonly IUserService _userService;
        public ApartmentService(IUnitOfWork unitOfWork, IUserService userService)
        {
            _apartmentRepository = unitOfWork.GetRepository<Apartment,int>();
            _userService = userService;
        }

        public IEnumerable<ApartmentViewModel> GetApartments()
        {
            var result = _apartmentRepository.GetAll().ToList().Select(MapToViewModel);
            return result;
        }

        public ApartmentViewModel MapToViewModel(Apartment model)
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

        public FullApartmentViewModel GetApartmentById(int id)
        {
            var apartment = _apartmentRepository.GetById(id);
            
            return MapToFullViewModel(apartment);
        }

        public FullApartmentViewModel MapToFullViewModel(Apartment model)
        {
            var apartmentViewModel = new FullApartmentViewModel
            {
                Id = model.Id,
                Description = model.Description,
                Price = model.Price,
                RoomsCount = model.RoomsNumbers,
                User = _userService.MapToUserViewModel(model.ApplicationUser),
                Photos = model.Photos.ToList().Select(MapToPhotoViewModel),
                Address = MapToAddressViewModel(model.House)
            };
            return apartmentViewModel;
        }

        
        public PhotoViewModel MapToPhotoViewModel(Photo model)
        {
            var photoViewModel = new PhotoViewModel
            {
                Id = model.Id,
                Description = model.Description,
                IsMain = model.IsMain,
                Path = model.Path
            };
            return photoViewModel;
        }

        public AddressViewModel MapToAddressViewModel(House house)
        {
            var street = house.Street;
            var district = street.District;
            var city = district.City;
            var addressViewModel = new AddressViewModel
            {
                HouseNumber = house.Number,
                Corpus = house.Corp.ToString(),
                Street = street.Title,
                District = district.Title,
                City = city.Title
                
            };
            return addressViewModel;
        }

        public void Save(FullApartmentViewModel viewModel)
        {
            var address = viewModel.Address;
            

        }

        public IEnumerable<ApartmentViewModel> GetApartmentsByUserId(string userId)
        {
            var apartments = _apartmentRepository.GetAll().ToList().Where(x => x.ApplicationUserId == userId);
            return apartments.Select(MapToViewModel);
        } 
    }
}

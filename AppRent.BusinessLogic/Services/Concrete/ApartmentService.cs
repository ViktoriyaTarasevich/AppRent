using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using AppRent.BusinessLogic.Services.Interface;
using AppRent.Common.Enums;
using AppRent.Common.Filters;
using AppRent.Common.ViewModels;
using AppRent.DataAccess.Repositories.Interface;
using AppRent.DataAccess.UnitOfWork.Interface;
using AppRent.Entities.Models;

using Microsoft.AspNet.Identity;


namespace AppRent.BusinessLogic.Services.Concrete
{
    public class ApartmentService : IApartmentService
    {
        private readonly IBaseRepository<Apartment, int> _apartmentRepository;
        private readonly IUserService _userService;
        private readonly IBaseRepository<City, int> _cityRepository;
        private readonly IBaseRepository<District, int> _districtRepository;
        private readonly IBaseRepository<Street, int> _streetRepository;
        private readonly IBaseRepository<House, int> _houseRepository;
        private readonly IBaseRepository<Photo, int> _photoRepository; 
        private readonly IUnitOfWork _unitOfWork;
 
        public ApartmentService(IUnitOfWork unitOfWork, IUserService userService)
        {
            _apartmentRepository = unitOfWork.GetRepository<Apartment,int>();
            _cityRepository = unitOfWork.GetRepository<City, int>();
            _districtRepository = unitOfWork.GetRepository<District, int>();
            _streetRepository = unitOfWork.GetRepository<Street, int>();
            _houseRepository = unitOfWork.GetRepository<House, int>();
            _photoRepository = unitOfWork.GetRepository<Photo, int>();

            _unitOfWork = unitOfWork;

            _userService = userService;
        }

        public IEnumerable<ApartmentViewModel> GetApartments(ApartmentFilter filter)
        {
            if (filter == null || filter.CityFilter == null || filter.PriceFilter == null || filter.RoomsCountFilter == null)
            {
                var result = _apartmentRepository.GetAll().ToList().Select(MapToViewModel);
                return result;
            }
            else
            {
                var chain = _apartmentRepository.GetAll().ToList();
                if (!String.IsNullOrEmpty(filter.CityFilter.City))
                {
                    if (filter.CityFilter.ComparisonType == ComparisonType.CONTAINS)
                    {
                        chain =  chain.Where(x => x.House.Street.District.City.Title.Contains(filter.CityFilter.City)).ToList();
                    }
                    if (filter.CityFilter.ComparisonType == ComparisonType.EQUAL)
                    {
                        chain = chain.Where(x => x.House.Street.District.City.Title == filter.CityFilter.City).ToList();
                    }
                    if (filter.CityFilter.ComparisonType == ComparisonType.NOT_EQUAL)
                    {
                        chain = chain.Where(x => x.House.Street.District.City.Title != filter.CityFilter.City).ToList();
                    }
                }
                if (filter.PriceFilter.Price != 0)
                {
                    if (filter.PriceFilter.ComparisonType == ComparisonType.LESS)
                    {
                        chain = chain.Where(x => x.Price < filter.PriceFilter.Price).ToList();
                    }
                    if (filter.PriceFilter.ComparisonType == ComparisonType.EQUAL)
                    {
                        chain = chain.Where(x => x.Price == filter.PriceFilter.Price).ToList();
                    }
                    if (filter.PriceFilter.ComparisonType == ComparisonType.MORE)
                    {
                        chain = chain.Where(x => x.Price > filter.PriceFilter.Price).ToList();
                    }
                    if (filter.PriceFilter.ComparisonType == ComparisonType.NOT_EQUAL)
                    {
                        chain = chain.Where(x => x.Price != filter.PriceFilter.Price).ToList();
                    }
                }
                if (filter.RoomsCountFilter.RoomsCount != 0)
                {
                    if (filter.RoomsCountFilter.ComparisonType == ComparisonType.LESS)
                    {
                        chain = chain.Where(x => x.RoomsNumbers < filter.RoomsCountFilter.RoomsCount).ToList();
                    }
                    if (filter.RoomsCountFilter.ComparisonType == ComparisonType.EQUAL)
                    {
                        chain = chain.Where(x => x.RoomsNumbers == filter.RoomsCountFilter.RoomsCount).ToList();
                    }
                    if (filter.RoomsCountFilter.ComparisonType == ComparisonType.MORE)
                    {
                        chain = chain.Where(x => x.RoomsNumbers > filter.RoomsCountFilter.RoomsCount).ToList();
                    }
                    if (filter.RoomsCountFilter.ComparisonType == ComparisonType.NOT_EQUAL)
                    {
                        chain = chain.Where(x => x.RoomsNumbers != filter.RoomsCountFilter.RoomsCount).ToList();
                    }
                }
                return chain.Select(MapToViewModel);
            }

            
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

            var houseId = SaveHouse(address, SaveStreet(address, SaveDistrict(address, SaveCity(address))));

            _apartmentRepository.Insert(new Apartment
            {
                Description = viewModel.Description,
                HouseId = houseId,
                Price = viewModel.Price,
                ApplicationUserId = viewModel.User.Id,
                RoomsNumbers = viewModel.RoomsCount,
                Photos = viewModel.Photos.Select(MapToPhoto).ToList()
            });
        }

        private Photo MapToPhoto(PhotoViewModel viewModel)
        {
            SavePhoto(viewModel);
            var photo = new Photo()
            {
                Description = viewModel.Description,
                Path = @"../Content/photos/" + viewModel.Name,
                IsMain = true
            };


            _photoRepository.Insert(photo);
            _unitOfWork.Save();
            return photo;
        }


        private void SavePhoto(PhotoViewModel viewModel)
        {
            var base64Only = Regex.Split(viewModel.Base64, "base64,");
            File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory+ @"\Content\photos\" + viewModel.Name, Convert.FromBase64String(base64Only[1]));
        }

        private int SaveCity(AddressViewModel address)
        {
            var city = _cityRepository.GetAll().FirstOrDefault(x => x.Title == address.City);
            int cityId;
            if (city != null)
            {
                cityId = city.Id;
            }
            else
            {
                var tempcity = _cityRepository.Insert(new City()
                {
                    Title = address.City
                });
                _unitOfWork.Save();
                cityId = tempcity.Id;
            }
            
            return cityId;
        }

        private int SaveDistrict(AddressViewModel address,int cityId)
        {
            var district = _districtRepository.GetAll().FirstOrDefault(x => x.Title == address.District);
            int id;
            if (district != null)
            {
                id = district.Id;
            }
            else
            {
                var temp = _districtRepository.Insert(new District(){
                    Title = address.District,
                    CityId = cityId
                });
                _unitOfWork.Save();
                id = temp.Id;
            }

            return id;
        }

        private int SaveStreet(AddressViewModel address, int districtId)
        {
            var street = _streetRepository.GetAll().FirstOrDefault(x => x.Title == address.Street);
            int id;
            if (street != null)
            {
                id = street.Id;
            }
            else
            {
                var temp = _streetRepository.Insert(new Street()
                {
                    Title = address.Street,
                    DistrictId =  districtId
                });
                _unitOfWork.Save();
                id = temp.Id;
            }

            return id;
        }

        private int SaveHouse(AddressViewModel address,int streetId)
        {
            int id;
            var temp = _houseRepository.Insert(new House
            {
                Number = address.HouseNumber,
                Corp = Int32.Parse(address.Corpus),
                StreetId = streetId

            });
            _unitOfWork.Save();
            id = temp.Id;

            return id;
        }

        public void Update(int id, ApartmentInfoViewModel viewModel)
        {
            var apartment = _apartmentRepository.GetById(id);
            if (apartment != null)
            {
                apartment.Description = viewModel.Description;
                apartment.RoomsNumbers = viewModel.RoomsCount;
                apartment.Price = viewModel.Price;
                _apartmentRepository.Update(id,apartment);
            }
        }

        public void Delete(int id)
        {
            var apartment = _apartmentRepository.GetById(id);
            

            if (apartment != null)
            {
                var photos = _photoRepository.GetAll().ToList().Where(x => x.ApartmentId == id).ToList();
                foreach (var photo in photos)
                {
                    _photoRepository.Delete(photo);
                }
                _apartmentRepository.Delete(apartment);
            }
        }

        public IEnumerable<ApartmentViewModel> GetApartmentsByUserId(string userId)
        {
            var apartments = _apartmentRepository.GetAll().ToList().Where(x => x.ApplicationUserId == userId);
            return apartments.Select(MapToViewModel);
        } 
    }
}

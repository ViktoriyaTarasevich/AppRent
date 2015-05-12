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

using Microsoft.AspNet.Identity;


namespace AppRent.BusinessLogic.Services.Concrete
{
    public class UserService : IUserService
    {
       
        private readonly IBaseRepository<ApplicationUser,string> _userRepository;
        UserViewModel IUserService.MapToUserViewModel(ApplicationUser model)
        {
            return MapToUserViewModel(model);
        }

        public UserService(IUnitOfWork unitOfWork)
        {
            _userRepository = unitOfWork.GetRepository<ApplicationUser, string>();
        }

        public UserViewModel MapToUserViewModel(ApplicationUser model)
        {
            var userViewModel = new UserViewModel
            {
                Id = model.Id,
                Email = model.Email,
                Name = model.UserName,
                Role = model.Roles.FirstOrDefault() != null ? new RoleViewModel() { Id = model.Roles.FirstOrDefault().RoleId } : null
            };
            return userViewModel;
        }

        public UserViewModel GetUserById(string id)
        {
            return MapToUserViewModel(_userRepository.GetById(id));
        }

        public IEnumerable<FullUserInfoViewModel> GetUsers()
        {
            var users = _userRepository.GetAll();
            return users.ToList().Select(MapToFullUserInfoViewModel);
        }

        public FullUserInfoViewModel MapToFullUserInfoViewModel(ApplicationUser model)
        {
            var viewModel = new FullUserInfoViewModel
            {
                Id = model.Id,
                Name = model.UserName,
                Email = model.Email,
                Rolename = model.Roles.First().RoleId,
                Apartments = model.Apartments != null ?  model.Apartments.ToList().Select(MapToApartmentViewModel) : null
            };

            return viewModel;
        }

        public void Delete(string userId)
        {
            var user = _userRepository.GetById(userId);
            if (user != null)
            {
                _userRepository.Delete(user);
            }
        }

        public ApartmentViewModel MapToApartmentViewModel(Apartment model)
        {
            var viewModel = new ApartmentViewModel
            {
                Id = model.Id,
                Price = model.Price,
                RoomsCount = model.RoomsNumbers,
                Street = model.House.Street.Title,
                House = model.House.Number,
                PathToPhoto = model.Photos.FirstOrDefault(x => x.IsMain).Path

            };
            return viewModel;
        }

    }
}

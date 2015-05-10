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

    }
}

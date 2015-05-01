using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppRent.Common.ViewModels;
using AppRent.Entities.Models;


namespace AppRent.BusinessLogic.Services.Interface
{
    public interface IUserService
    {
        UserViewModel MapToUserViewModel(ApplicationUser model);

        UserViewModel GetUserById(string id);
    }
}

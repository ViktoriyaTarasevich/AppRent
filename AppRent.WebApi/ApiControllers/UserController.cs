using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Antlr.Runtime.Misc;

using AppRent.BusinessLogic.Services.Interface;
using AppRent.Common.ViewModels;
using AppRent.DataAccess.UnitOfWork.Interface;

using Microsoft.AspNet.Identity;


namespace AppRent.WebApi.ApiControllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }


        [Route("api/User/CheckCurrentUser")]
        public bool CheckCurrentUser(string userId)
        {
            if (User.Identity.GetUserId() == userId)
            {
                return true;
            }
            return false;
        }

        [Route("api/User/CurrentUser")]
        public UserViewModel GetCurrentUser()
        {
            var user = User;
            return _userService.GetUserById(User.Identity.GetUserId());
        }


        // GET: api/User
        public IEnumerable<FullUserInfoViewModel> Get()
        {
            return _userService.GetUsers();
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(string id)
        {
            _userService.Delete(id);
            _unitOfWork.Save();
        }
    }
}

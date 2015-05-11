using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using AppRent.BusinessLogic.Services.Interface;

using Microsoft.AspNet.Identity;


namespace AppRent.WebApi.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CurrentUser()
        {
            return Json(_userService.GetUserById(User.Identity.GetUserId()),JsonRequestBehavior.AllowGet);
        }


        

    }
}

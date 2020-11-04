using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CategoryApp.Business.Abstract;
using CategoryApp.Business.Concrete;
using CategoryApp.Core.Results;
using CategoryApp.DataAccess.Concrete.EntityFramework;
using CategoryApp.Entities.Dtos;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace CategoryApp.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController()
        {
            _userService = new UserManager(new EfUserDal());
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View(new UserForLoginDto());
        }
        [HttpPost]
        public ActionResult Login(UserForLoginDto model)
        {
            var result = _userService.Login(model);
            if (result.Success)
            {
                TempData["userInfo"] = JsonConvert.SerializeObject(result.Data);
                return Redirect("/Account/Confirm");
            }
            ViewBag.Message = result.Message;
            return View();
        }

        [HttpGet]
        public ActionResult Confirm()
        {
            return View();
        }
        //FormsAuthentication.SetAuthCookie(result.Data.Username, false);
        [HttpPost]
        public ActionResult Confirm(LoginConfirmDto model)
        {
            var result  = JsonConvert.DeserializeObject<LoginDtoForResponse>(TempData["userInfo"].ToString());
            var req = _userService.Confirm(model,result.Code);
            if (req.Success)
            {
                FormsAuthentication.SetAuthCookie(result.Username, false);
                return Redirect("/Category/Index");
            }
            ViewBag.Message = req.Message;
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserForRegisterDto model)
        {
            var result = _userService.Register(model);
            ViewBag.Message = result.Message;
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
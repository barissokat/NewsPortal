using NewsPortal.Core.Infrastructure;
using NewsPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Admin.Controllers
{
    public class AccountController : Controller
    {
        #region User
        private readonly IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var useR = _userRepository.GetMany(x => x.Email == user.Email && x.Password == user.Password && x.Active == true).SingleOrDefault();
            if (useR != null)
            {
                if (useR.Role.RoleName == "Admin")
                {
                    Session["UserEmail"] = useR.Email;
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Message = "Yetkisiz Kullanıcı";
                return View();
            }
            ViewBag.Message = "Kullanıcı Bulunamadı";
            return View();
        }
    }
}
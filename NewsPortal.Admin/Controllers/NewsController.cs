using NewsPortal.Admin.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Admin.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        #region Create News
        [HttpGet]
        [LoginFilter]
        public ActionResult Create()
        {
            return View();
        }
        #endregion
    }
}
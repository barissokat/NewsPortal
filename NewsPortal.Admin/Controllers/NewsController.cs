using NewsPortal.Admin.CustomFilter;
using NewsPortal.Core.Infrastructure;
using NewsPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Admin.Controllers
{
    public class NewsController : Controller
    {
        #region Database
        private readonly INewsRepository _newsRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        public NewsController(INewsRepository newsRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _newsRepository = newsRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        #region Create News
        [HttpGet]
        [LoginFilter]
        public ActionResult Create()
        {
            SetCategoryList();
            return View();
        }
        #endregion

        #region Set Category
        public void SetCategoryList()
        {
            var CategoryList = _categoryRepository.GetMany(x => x.ParentId == 0).ToList();
            ViewBag.Category = CategoryList;
        }
        #endregion
    }
}
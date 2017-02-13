using NewsPortal.Admin.Classes;
using NewsPortal.Core.Infrastructure;
using NewsPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Admin.Controllers
{
    public class CategoryController : Controller
    {
        #region Category
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Category category)
        {
            try
            {
                _categoryRepository.Insert(category);
                _categoryRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Kategori başarıyla eklenmiştir." });
            }
            catch (Exception)
            {
                return Json(new ResultJson { Success = false, Message = "Kategori ekleme sırasında bir hata oluştur." });
            }
        }
    }
}
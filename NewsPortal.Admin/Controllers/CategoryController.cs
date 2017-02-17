using NewsPortal.Admin.Classes;
using NewsPortal.Core.Infrastructure;
using NewsPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using NewsPortal.Admin.CustomFilter;

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

        #region List Category
        public ActionResult Index(int page = 1)
        {
            return View(_categoryRepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(page, 10));
        }
        #endregion

        #region Create Category
        [HttpGet]
        public ActionResult Create()
        {
            SetCategoryList();
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
        #endregion

        #region Delete Category
        public JsonResult Delete(int id)
        {
            Category category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return Json(new ResultJson { Success = false, Message = "İşlem sırasında hata oluştu." });
            }
            _categoryRepository.Delete(id);
            _categoryRepository.Save();

            return Json( new ResultJson { Success=true, Message="Kategori başarıyla silinmiştir." });
        }
        #endregion

        #region Edit Category
        [HttpGet]
        [LoginFilter]
        public ActionResult Edit(int id)
        {
            Category category = _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new Exception("Kategori bulunamadı.");
            }
            SetCategoryList();
            return View(category);
        }
        [HttpPost]
        [LoginFilter]
        public JsonResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                Category cat = _categoryRepository.GetById(category.ID);
                cat.Name = category.Name;
                cat.ParentId = category.ParentId;
                cat.Url = category.Url;
                cat.Active = category.Active;
                _categoryRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Kategori başarıyla düzenlenmiştir." });
            }
            return Json(new ResultJson { Success = false, Message = "Kategori düzenleme sırasında bir hata oluştur." });
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
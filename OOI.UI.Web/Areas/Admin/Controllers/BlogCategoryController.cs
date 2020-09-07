using OOI.Business.Manager.Repository;
using OOI.Data.Entities;
using OOI.UI.Web.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OOI.UI.Web.Areas.Admin.Controllers
{
    public class BlogCategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            List<BlogCategoryVM> categoryList = unit.BlogCategoryRepo.GetAllQuery().Select(x => new BlogCategoryVM()
            {
                ID = x.ID,
                Name = x.Name,
                Description = x.Description
            }
            ).ToList();
            return View(categoryList);
        }
        public ActionResult AddCategory()
        {
            return View(new BlogCategoryVM());
        }
        [HttpPost]
        public ActionResult AddCategory(BlogCategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                BlogCategory category = new BlogCategory();
                category.Name = categoryVM.Name;
                category.Description = categoryVM.Description;
                unit.BlogCategoryRepo.Add(category);
                return RedirectToAction("Index");   
            }
            return View(categoryVM);
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            BlogCategory category = unit.BlogCategoryRepo.FirstOrDefault(x => x.ID == id);
            BlogCategoryVM categoryVM = new BlogCategoryVM();
            categoryVM.ID = category.ID;
            categoryVM.Name = category.Name;
            categoryVM.Description = category.Description;
            return View(categoryVM);
        }
        [HttpPost]
        public ActionResult UpdateCategory(BlogCategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                BlogCategory category = unit.BlogCategoryRepo.FirstOrDefault(x => x.ID == categoryVM.ID);
                category.ID = categoryVM.ID;
                category.Name = categoryVM.Name;
                category.Description = categoryVM.Description;
                unit.Save();
                return RedirectToAction("Index");
            }
            return View(categoryVM);
        }
        [HttpGet]
        public ActionResult CategoryDetail(int id)
        {
            BlogCategory category = unit.BlogCategoryRepo.FirstOrDefault(x => x.ID == id);
            BlogCategoryVM categoryVM = new BlogCategoryVM();
            categoryVM.ID = category.ID;
            categoryVM.Name = category.Name;
            categoryVM.Description = category.Description;
            return View(categoryVM);
        }
        [HttpGet]
        public ActionResult RemoveCategory(int id)
        {
            unit.BlogCategoryRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
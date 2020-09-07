using OOI.Data.Entities;
using OOI.UI.Web.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Areas.Admin.Controllers
{
    public class ProjectCategoryController : BaseController
    {
        // GET: Admin/ProjectCategory
        public ActionResult Index()
        {
            List<ProjectCategoryVM> projectCategories = unit.ProjectCategoryRepo.GetAllQuery().Select(x => new ProjectCategoryVM()
            {
                ID = x.ID,
                Title = x.Title,
                Name = x.Name,
                Description = x.Description
            }
            ).ToList();
            return View(projectCategories);
        }



        public ActionResult AddCategory()
        {
            return View(new ProjectCategoryVM());
        }

        [HttpPost]
        public ActionResult AddCategory(ProjectCategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                ProjectCategory projectCategory = new ProjectCategory();
                projectCategory.Title = categoryVM.Title;
                projectCategory.Name = categoryVM.Name;
                projectCategory.Description = categoryVM.Description;
                unit.ProjectCategoryRepo.Add(projectCategory);
                return RedirectToAction("Index");
            }
            return View(categoryVM);
        }



        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            ProjectCategory projectCategory = unit.ProjectCategoryRepo.FirstOrDefault(x => x.ID == id);
            ProjectCategoryVM categoryVM = new ProjectCategoryVM();
            categoryVM.ID = projectCategory.ID;
            categoryVM.Title = projectCategory.Title;
            categoryVM.Name = projectCategory.Name;
            categoryVM.Description = projectCategory.Description;
            return View(categoryVM);
        }

        [HttpPost]
        public ActionResult UpdateCategory(ProjectCategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                ProjectCategory projectCategory = unit.ProjectCategoryRepo.FirstOrDefault(x => x.ID == categoryVM.ID);
                projectCategory.ID = categoryVM.ID;
                projectCategory.Title = categoryVM.Title;
                projectCategory.Name = categoryVM.Name;
                projectCategory.Description = categoryVM.Description;
                unit.Save();
                return RedirectToAction("Index");
            }
            return View(categoryVM);
        }



        [HttpGet]
        public ActionResult CategoryDetail(int id)
        {
            ProjectCategory projectCategory = unit.ProjectCategoryRepo.FirstOrDefault(x => x.ID == id);
            ProjectCategoryVM categoryVM = new ProjectCategoryVM();
            categoryVM.ID = projectCategory.ID;
            categoryVM.Title = projectCategory.Title;
            categoryVM.Name = projectCategory.Name;
            categoryVM.Description = projectCategory.Description;
            return View(categoryVM);
        }



        [HttpGet]
        public ActionResult RemoveCategory(int id)
        {
            unit.ProjectCategoryRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
using OOI.Data.Entities;
using OOI.UI.Web.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Areas.Admin.Controllers
{
    public class BlogController : BaseController
    {
        public ActionResult Index()
        {
            List<BlogVM> blogList = unit.BlogRepo.GetAllQuery().Select(x => new BlogVM()
            {
                ID = x.ID,
                Title = x.Title,
                Description = x.Description,
                CategoryName = x.Category.Name,
                CategoryID = x.CategoryID
            }).ToList();
            return View(blogList);
        }
        [HttpGet]
        public ActionResult AddBlog()
        {
            BlogVM blogVM = new BlogVM();
            blogVM.drpBlogCategoryList = unit.BlogCategoryRepo.GetAllQuery().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();
            return View(blogVM);
        }
        [HttpPost]
        public ActionResult AddBlog(BlogVM blogVM)
        {
            if (ModelState.IsValid)
            {
                Blog blog = new Blog();
                blog.ID = blogVM.ID;
                blog.Title = blogVM.Title;
                blog.Description = blogVM.Description;
                blog.CategoryID = blogVM.CategoryID;
                unit.BlogRepo.Add(blog);
                return RedirectToAction("Index");
            }
            return View(blogVM);
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = unit.BlogRepo.FirstOrDefault(x => x.ID == id);
            BlogVM blogVM = new BlogVM();
            blogVM.ID = blog.ID;
            blogVM.Title = blog.Title;
            blogVM.Description = blog.Description;
            blogVM.CategoryID = blog.CategoryID;
            blogVM.drpBlogCategoryList = unit.BlogCategoryRepo.GetAllQuery().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();
            return View(blogVM);
        }
        [HttpPost]
        public ActionResult UpdateBlog(BlogVM blogVM)
        {
            if (ModelState.IsValid)
            {
                Blog blog = unit.BlogRepo.FirstOrDefault(x => x.ID == blogVM.ID);
                blog.ID = blogVM.ID;
                blog.Title = blogVM.Title;
                blog.Description = blogVM.Description;
                blog.CategoryID = blogVM.CategoryID;
                unit.Save();
                return RedirectToAction("Index");
            }
            return View(blogVM);
        }
        [HttpGet]
        public ActionResult BlogDetail(int id)
        {
            Blog blog = unit.BlogRepo.FirstOrDefault(x => x.ID == id);
            BlogVM blogVM = new BlogVM();
            blogVM.ID = blog.ID;
            blogVM.Title = blog.Title;
            blogVM.Description = blog.Description;
            blogVM.CategoryName = blog.Category.Name;
            return View(blogVM);
        }
        [HttpGet]
        public ActionResult RemoveBlog(int id)
        {
            unit.BlogRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
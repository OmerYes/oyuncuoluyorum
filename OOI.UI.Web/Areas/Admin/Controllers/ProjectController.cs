using OOI.UI.Web.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Areas.Admin.Controllers
{
    public class ProjectController : BaseController
    {
        // GET: Admin/Project
        public ActionResult Index()
        {
            List<ProjectVM> model = unit.ProjectRepo.GetAllQuery().Select(x => new ProjectVM()
            {
                ID = x.ID,
                Title = x.Title,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                CategoryName = x.ProjectCategory.Name,
                Description = x.Description
            }).ToList();
            return View(model);
        }
    }
}
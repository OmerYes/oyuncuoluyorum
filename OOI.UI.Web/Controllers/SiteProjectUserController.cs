using OOI.Data.Entities;
using OOI.UI.Web.Areas.Admin.Models.VM;
using OOI.UI.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Controllers
{
    [Authorize]
    public class SiteProjectUserController : BaseController
    {
        public ActionResult ProjectApply()
        {
            List<ProjectApplyDetailVM> model = new List<ProjectApplyDetailVM>();

            int webuserid = GetWebUserID();
            List<ProjectApply> projectsapply = unit.ProjectApplyRepo.GetAllQuerableWithQuery(q => q.WebUserID == webuserid).ToList();

            foreach (var item in projectsapply)
            {
                Project project = unit.ProjectRepo.FirstOrDefault(q => q.ID == item.ProjectID);
                ProjectApplyDetailVM papplaydetailvm = new ProjectApplyDetailVM();
                if (project !=null)
                {
                    papplaydetailvm.CoverPhoto = project.CoverPhoto;
                    papplaydetailvm.Title = project.Title;
                    papplaydetailvm.CategoryName = project.ProjectCategory.Name;
                    papplaydetailvm.StartDateString = project.StartDate.ToString("dd MMMM yyyy, dddd");
                    papplaydetailvm.EndDateString = project.EndDate.ToString("dd MMMM yyyy, dddd");
                    papplaydetailvm.Description = project.Description;
                    papplaydetailvm.ID = project.ID;
                    papplaydetailvm.ApplyDateString = item.ApplyDate.ToString("dd MMMM yyyy, dddd");

                    model.Add(papplaydetailvm);
                }
            }

            return View(model);
        }


        public JsonResult CancelProject(int id)
        {
            int webuserid = GetWebUserID();
            ProjectApply projectapply = unit.ProjectApplyRepo.FirstOrDefault(q => q.ProjectID == id && q.WebUserID == webuserid);
            if (projectapply != null)
            {
                unit.ProjectApplyRepo.Delete(projectapply.ID);
            }
            return Json("");
        }
    }
}
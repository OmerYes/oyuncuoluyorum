using OOI.Data.Entities;
using OOI.UI.Web.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Areas.Admin.Controllers
{
    public class AdminProjectApplyController : BaseController
    {
        public ActionResult Index(int id)
        {
            List<ProjectApplyUserVM> userList = new List<ProjectApplyUserVM>();

            List<ProjectApply> projectApplyUsers = unit.ProjectApplyRepo.GetAllQuerableWithQuery(x => x.ProjectID == id).ToList();

            foreach (var item in projectApplyUsers)
            {
                WebUser user = unit.WebUserRepo.FirstOrDefault(q => q.ID == item.WebUserID);
                ProjectApplyUserVM puser = new ProjectApplyUserVM();
                puser.UserName = user.Name;
                puser.UserLastName = user.LastName;
                userList.Add(puser);
            }
            return View(userList);
        }
    }
}
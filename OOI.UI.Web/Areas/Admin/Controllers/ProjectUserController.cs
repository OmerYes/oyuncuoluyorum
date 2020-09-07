using OOI.Data.Entities;
using OOI.UI.Web.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Areas.Admin.Controllers
{
    public class ProjectUserController : BaseController
    {
        public ActionResult Index(int id)
        {
            List<ProjectUserVM> userList = new List<ProjectUserVM>();

            List<ProjectUser> projectUsers = unit.ProjectUserRepo.GetAllQuerableWithQuery(q => q.ProjectId == id).ToList();

            foreach (var item in projectUsers)
            {
                WebUser user = unit.WebUserRepo.FirstOrDefault(q => q.ID == item.WebUserId);
                ProjectUserVM puser = new ProjectUserVM();
                puser.UserID = user.ID;
                puser.UserName = user.Name;
                puser.UserLastName = user.LastName;
                userList.Add(puser);
            }
            return View(userList);
        }
    }
}
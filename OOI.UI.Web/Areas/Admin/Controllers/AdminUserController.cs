using OOI.Business.Manager.Repository;
using OOI.Data.Context;
using OOI.Data.Entities;
using OOI.UI.Web.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OOI.UI.Web.Areas.Admin.Controllers
{
    public class AdminUserController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                AdminUser adminUser = unit.AdminUserRepo.FirstOrDefault(x => x.Email.ToLower() == loginVM.Email && x.Password == loginVM.Password);
                if(adminUser != null) 
                {
                    FormsAuthentication.SetAuthCookie(loginVM.Email, true);
                    return RedirectToAction("Index", "AdminHome");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
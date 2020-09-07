using OOI.Business.Manager.Repository;
using OOI.Data.Entities;
using OOI.UI.Web.Models.Types.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Controllers
{

    public class BaseController : Controller
    {
        public UnitOfWork unit;
        bool loginStatus;
        public BaseController()
        {
            unit = new UnitOfWork();
        }

        protected override void Dispose(bool disposing)
        {
            unit.Dispose();
            base.Dispose(disposing);
        }

        public string GetWebUserEMail()
        {
            string email = HttpContext.User.Identity.Name;
            return email;
        }
        public int GetWebUserID()
        {
            string email = HttpContext.User.Identity.Name;
            var webuser = unit.WebUserRepo.FirstOrDefault(q => q.Email == email);
            if (webuser == null)
            {
                var company = unit.CompanyRepo.FirstOrDefault(q => q.Email == email);
                if (company == null)
                {
                    return 0;
                }
                return company.ID;
            }
            return webuser.ID;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                loginStatus = false;
            }
            else
            {
                loginStatus = true;
            }
            ViewBag.Loginstatus = loginStatus;
            ViewBag.LoginCategory = LoginCategory();
            ViewBag.CreditStatus = CreditStatus();
        }

        public EnumLoginCategory LoginCategory()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                string email = HttpContext.User.Identity.Name;
                var webuser = unit.WebUserRepo.FirstOrDefault(q => q.Email == email);
                if (webuser != null)
                {
                    return EnumLoginCategory.UserLogin;

                }
                var company = unit.CompanyRepo.FirstOrDefault(q => q.Email == email);
                if (company != null)
                {
                    return EnumLoginCategory.CompanyLogin;
                }
            }
            return EnumLoginCategory.Anonymous;
        }
        public bool LoginControl()
        {
            try
            {
                if (HttpContext != null)
                {
                    if (HttpContext.User.Identity.IsAuthenticated)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public int CreditStatus()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                string email = HttpContext.User.Identity.Name;
                var webuser = unit.WebUserRepo.FirstOrDefault(q => q.Email == email);
                if (webuser != null)
                {
                    if (webuser.Credits > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                var company = unit.CompanyRepo.FirstOrDefault(q => q.Email == email);
                if (company != null)
                {
                    if (company.Credits > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 1;
        }

    }
}
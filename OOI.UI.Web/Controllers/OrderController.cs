using OOI.Data.Entities;
using OOI.UI.Web.Models.Types;
using OOI.UI.Web.Models.Types.Enums;
using OOI.UI.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Controllers
{

    public class OrderController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderHistory()
        {
            int webuserid = GetWebUserID();
            OrderHistoryVM model = new OrderHistoryVM();

            WebUser entity = unit.WebUserRepo.FirstOrDefault(q => q.ID == webuserid);
            if (entity != null)
            {
                model.IsFirm = false;
                model.Credit = entity.Credits;
                model.FullName = entity.Name + " " + entity.LastName;
                model.PurchasedCredit = 0;
                if (!String.IsNullOrEmpty(entity.ProfilePhoto))
                    model.Photo = entity.ProfilePhoto;
                else
                    model.Photo = "profileempty.jpg";

                return View(model);
            }

            Company company = unit.CompanyRepo.FirstOrDefault(q => q.ID == webuserid);
            if (company != null)
            {
                model.IsFirm = true;
                model.Credit = company.Credits;
                model.PurchasedCredit = 0;
                if (!String.IsNullOrEmpty(company.LogoPath))
                    model.Photo = company.LogoPath;
                else
                    model.Photo = "profileempty.jpg";

                return View(model);
            }

            return RedirectToAction("Index","Home");

        }

        public ActionResult CheckOut(int id)
        {
            EnumLoginCategory usercategory = LoginCategory();
            CheckOutGetVM model = new CheckOutGetVM();
            model.drpCities = unit.CityRepo.GetAll().Select(q => new SelectListItem()
            {
                Text = q.Name,
                Value = q.ID.ToString()
            }).ToList();
            int userid = GetWebUserID();

            if (usercategory == EnumLoginCategory.UserLogin)
            {
                WebUser webuser = unit.WebUserRepo.FirstOrDefault(q => q.ID == userid);
                model.FullName = webuser.Name + " " + webuser.LastName;
                model.EMail = webuser.Email;
            }
            if (usercategory == EnumLoginCategory.CompanyLogin)
            {
                Company company = unit.CompanyRepo.FirstOrDefault(q => q.ID == userid);
                model.EMail = company.Email;
            }

            if (id == Convert.ToInt32(EnumCreditPackageLevel.Start))
            {
                model.OrderType = OrderTypes.Basic;
                model.TotalPrice = PackageValues.Basic;
            }
            else if (id == Convert.ToInt32(EnumCreditPackageLevel.Normal))
            {
                model.OrderType = OrderTypes.Normal;
                model.TotalPrice = PackageValues.Normal;
            }
            else if (id == Convert.ToInt32(EnumCreditPackageLevel.High))
            {
                model.OrderType = OrderTypes.High;
                model.TotalPrice = PackageValues.High;
            }

            return View(model);
        }
    }
}
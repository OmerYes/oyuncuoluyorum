using OOI.Data.Entities;
using OOI.UI.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Controllers
{
    [Authorize]
    public class SiteCompanyController : BaseController
    {
        public ActionResult Update()
        {
            int companyid = GetWebUserID();
            Company company = unit.CompanyRepo.FirstOrDefault(q => q.ID == companyid);

            CompanyVM model = new CompanyVM();
            model.CompanyName = company.CompanyName;
            model.Email = company.Email;
            model.ID = company.ID;
            model.Phone = company.Phone;
            model.LogoPath = company.LogoPath;
            model.Address = company.Address;
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(CompanyVM model,HttpPostedFileBase logo)
        {
            if (ModelState.IsValid)
            {
                Company company = unit.CompanyRepo.FirstOrDefault(q => q.ID == model.ID);

                if (logo != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(logo.FileName);
                    string ex = Path.GetExtension(logo.FileName);
                    if (ex == ".png" || ex == ".jpg" || ex == ".jpeg" || ex == ".PNG" || ex == ".JPG" || ex == ".JPEG")
                    {
                        string guid = Guid.NewGuid().ToString();
                        string sqlref = "~/Content/SiteCompany/Logo/" + guid + ex;
                        fileName = Path.Combine(Server.MapPath(sqlref));
                        logo.SaveAs(fileName);
                        company.LogoPath = guid + ex;
                    }
                }

                company.ID = model.ID;
                company.CompanyName = model.CompanyName;
                company.Email = model.Email;
                company.Phone = model.Phone;
                company.Address = model.Address;

                unit.CompanyRepo.Update(company);

                model.LogoPath = company.LogoPath;
             
            }
            return View(model);

        }
    }
}
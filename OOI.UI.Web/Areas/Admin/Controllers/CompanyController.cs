using OOI.Data.Entities;
using OOI.UI.Web.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Areas.Admin.Controllers
{
    public class CompanyController : BaseController
    {
        // GET: Admin/Company
        public ActionResult Index()
        {
            List<CompanyVM> companyList = unit.CompanyRepo.GetAllQuery().Select(x => new CompanyVM()
            {
                ID = x.ID,
                CompanyName = x.CompanyName,
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone,
                CategoryName = x.CompanyCategory.Name,
                CategoryID = x.CategoryID
            }
            ).ToList();
            return View(companyList);
        }



        [HttpGet]
        public ActionResult CompanyDetail(int id)
        {
            Company company = unit.CompanyRepo.FirstOrDefault(x => x.ID == id);
            CompanyVM companyVM = new CompanyVM();
            companyVM.ID = company.ID;
            companyVM.CompanyName = company.CompanyName;
            companyVM.Address = company.Address;
            companyVM.Email = company.Email;
            companyVM.Phone = company.Phone;
            companyVM.CategoryName = company.CompanyCategory.Name;
            return View(companyVM);
        }



        [HttpGet]
        public ActionResult RemoveCompany(int id)
        {
            unit.CompanyRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
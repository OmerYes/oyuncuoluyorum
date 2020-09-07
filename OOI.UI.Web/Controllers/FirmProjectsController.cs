using OOI.Data.Entities;
using OOI.UI.Web.Models.Types;
using OOI.UI.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Controllers
{
    public class FirmProjectsController : BaseController
    {
        public ActionResult Index()
        {
            int webuserid = GetWebUserID();
            List<FirmProjectVM> model = new List<FirmProjectVM>();

            List<ProjectVM> projects = unit.ProjectRepo.GetAllQuerableWithQuery(x => x.CompanyID == webuserid).Select(q => new ProjectVM() {
                Title = q.Title,
                StartDateString = q.StartDate.ToString("dd MMMM yyyy, dddd"),
                EndDateString = q.EndDate.ToString("dd MMMM yyyy, dddd"),
                CategoryName = q.ProjectCategory.Name,
                Description = q.Description,
                ID = q.ID
            }).ToList();

            foreach (var item in projects)
            {
                FirmProjectVM firmprojectvm = new FirmProjectVM();
                firmprojectvm.Project = item;
                List<ProjectUser> userids = unit.ProjectUserRepo.GetAllQuerableWithQuery(q => q.ProjectId == item.ID).ToList();
                //firmprojectvm.ProjectPhotos = 
            }

            return View();
        }

        public ActionResult ManageProject(int id)
        {
            FirmProjectVM firmProjectVM = new FirmProjectVM();
            firmProjectVM.Project = unit.ProjectRepo.GetByID(x => x.ID == id).Select(x => new ProjectVM() // detayı açılan proje 
            {

                Title = x.Title,
                StartDateString = x.StartDate.ToString("dd MMMM yyyy, dddd"),
                EndDateString = x.EndDate.ToString("dd MMMM yyyy, dddd"),
                CategoryName = x.ProjectCategory.Name,
                Description = x.Description,
                ID = x.ID,
                MainPhoto = x.CoverPhoto
            }).FirstOrDefault();



            var basvuranlar = unit.ProjectApplyRepo.GetAllQuerableWithQuery(x => x.ProjectID == id).ToList() ;

            firmProjectVM.ProjectUsers = new List<ProjectUserVM>();

            foreach (var item in basvuranlar)
            {
                var basvuranBilgisi = unit.WebUserRepo.FirstOrDefault(x => x.ID == item.WebUserID);

                ProjectUserVM kullaniciVm = new ProjectUserVM();
                kullaniciVm.ID = basvuranBilgisi.ID;
                kullaniciVm.Name = basvuranBilgisi.Name;
                kullaniciVm.SurName= basvuranBilgisi.LastName;
                kullaniciVm.MainPhoto = basvuranBilgisi.ProfilePhoto;
                kullaniciVm.ProjectApplyCategoryID = basvuranlar.FirstOrDefault(x => x.WebUserID == basvuranBilgisi.ID).ProjectApplyCategoryID;
                firmProjectVM.ProjectUsers.Add(kullaniciVm);

            }

            return View(firmProjectVM);
        }

        public JsonResult ExitProject(int ProjectID,int WebUserID)
        {
            
            ProjectApply exitProje = unit.ProjectApplyRepo.FirstOrDefault(x => x.ProjectID == ProjectID && x.WebUserID == WebUserID);
            if (exitProje != null)
            {
                unit.ProjectApplyRepo.Delete(exitProje.ID);
                return Json(new ResultJsonDTO() { Status="1",Messages="Silme İşlemi Başarılı"},JsonRequestBehavior.AllowGet);
            }


            return Json(new ResultJsonDTO() { Status = "2", Messages = "Silme İşlemi Sırasında Hata Oluştu" }, JsonRequestBehavior.AllowGet);
        }
    }
}
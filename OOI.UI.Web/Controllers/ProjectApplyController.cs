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
    public class ProjectApplyController : BaseController
    {
        public JsonResult Apply(int id)
        {
            var loginstatus = LoginControl();
            if (loginstatus)
            {
                int webuserid = GetWebUserID();
                WebUser webuser = unit.WebUserRepo.FirstOrDefault(q => q.ID == webuserid);
                int credit = Convert.ToInt32(EnumCredit.ProjectApply);
                if (webuser.Credits >= credit)
                {
                    bool basvurudurum = unit.ProjectApplyRepo.Any(q => q.ProjectID == id && q.WebUserID == webuserid);
                    if (!basvurudurum)
                    {

                        webuser.Credits = webuser.Credits - credit;
                        unit.Save();

                        ProjectApply projectapply = new ProjectApply();
                        projectapply.ProjectID = id;
                        projectapply.WebUserID = webuserid;
                        projectapply.ApplyDate = DateTime.Now;

                        unit.ProjectApplyRepo.Add(projectapply);

                        return Json(new ResultJsonDTO()
                        {
                            Status = "1",
                            Messages = "Proje başvurunuz başarılı bir şekilde gerçekleşmiştir."
                        });
                    }
                    else
                    {
                        return Json(new ResultJsonDTO()
                        {
                            Status = "2",
                            Messages = "Daha önce bu projeye başvurduğunuz için tekrar başvuramazsınız"
                        });
                    }
                }
                else
                {
                    return Json(new ResultJsonDTO()
                    {
                        Status = "3",
                        Messages = "Yeterli krediniz bulunmamaktadır. Lütfen kredi yükleyiniz"
                    });

                }

            }
            else
            {
                return Json(new ResultJsonDTO()
                {
                    Status = "4",
                    Messages = "Lüften üye girişi yapınız."
                });
            }

        }


        public JsonResult CompanyProjects(int id)
        {
            var loginstatus = LoginControl();
            if (loginstatus)
            {

                var CompanyID = unit.CompanyRepo.FirstOrDefault(x => x.Email == User.Identity.Name).ID;
                var applyProjectList = unit.ProjectApplyRepo.GetAll(); // başvurulan ve eklenen projeleri bulduk
                List<ProjectApplyDetailVM> companyProjectList = unit.ProjectRepo.GetAll(/*x => x.CompanyID == CompanyID*/).Select(x => new ProjectApplyDetailVM()
                {
                    Title = x.Title,

                    StartDateString = x.StartDate.ToString("dd MMMM yyyy, dddd"),
                    EndDateString = x.EndDate.ToString("dd MMMM yyyy, dddd"),  // Login olan şirkete ait projeleri bulduk ve json için serilize ettik. 
                    CompanyID = x.CompanyID,
                    ProjectID = x.ID,
                    IsAdded = false

                }).Where(x=>x.CompanyID==CompanyID).ToList();

                List<int> listem = new List<int>();

                foreach (var item in companyProjectList) // Şirket projelerinde dönüp  , detayına baktığı oyuncu başvuru tablosunda var mı kontrolu
                {
                    if (applyProjectList.Any(x => x.ProjectID == item.ProjectID && x.WebUserID == id))
                    {
                        listem.Add(item.ProjectID.Value);
                    }
                }

                foreach (var item in listem) // ilk bulunan  şirket projelerini ekrana gönderdiğimizde checkbox lar işaretli olması için özelliği true yapıyoruz.
                {
                    if (companyProjectList.Any(x => x.ProjectID.Value == item))
                    {
                        var proje = companyProjectList.FirstOrDefault(x => x.ProjectID == item);
                        proje.IsAdded = true;
                    }
                }

                return Json(companyProjectList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResultJsonDTO()
                {
                    Status = "4",
                    Messages = "Lüften üye girişi yapınız."
                }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult CompanyApply(int[] ProjectIDs, int WebUserID)
        {

            try
            {
                if (ProjectIDs == null)
                {
                    return Json(new ResultJsonDTO() { Status = "2", Messages = "Oyuncuyu Eklemek için Proje Seçmelisiniz." }, JsonRequestBehavior.AllowGet);
                }

                List<ProjectApply> applyProjects = unit.ProjectApplyRepo.GetAll();

                for (int i = 0; i < ProjectIDs.Length; i++)
                {


                    if (!applyProjects.Any(x => x.ProjectID == ProjectIDs[i] && x.WebUserID == WebUserID))
                        unit.ProjectApplyRepo.Add(new ProjectApply() { ProjectID = ProjectIDs[i], WebUserID = WebUserID, ProjectApplyCategoryID = 1, ApplyDate = DateTime.Now });
                }

                return Json(new ResultJsonDTO() { Status = "1", Messages = "Projeye Eklendi" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new ResultJsonDTO() { Status = "3", Messages = "Eklenemedi" }, JsonRequestBehavior.AllowGet);

            }

        }
    }

    //public class DenemeVM
    //{
    //    //Baslik = item.Title, Ad = item.Name, foto = item.CoverPhoto, SirketID = item.CompanyID, ProjeID = item.ID, eklenmismi
    //    public string Baslik { get; set; }
    //    public string Ad { get; set; }

    //    public int SirketID { get; set; }
    //    public int ProjeID { get; set; }
    //    public bool eklenmismi { get; set; }
    //    public string BaslangicTarihi { get; set; }
    //    public string BitisTarihi { get; set; }

    //}
}
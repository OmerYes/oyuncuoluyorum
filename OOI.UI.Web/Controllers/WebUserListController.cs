using OOI.StringExt.Date;
using OOI.UI.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Controllers
{
    public class WebUserListController : BaseController
    {
        [Route("Oyuncu-Listesi/")]
        public ActionResult Index(string gender)
        {
            List<WebUserListVM> webusers;
            webusers = unit.WebUserRepo.GetAll().Select(q => new WebUserListVM()
            {
                Name = q.Name,
                FullName = q.Name + " " + q.LastName,
                Yas =q.BirthDate!=null?Convert.ToInt32(DateTimeManager.CalculateYourAge(q.BirthDate)):0,
                City = q.City?.Name,
                ID = q.ID,
                Gender=q.Gender,
                ProfilePic = q.ProfilePhoto == "" || q.ProfilePhoto == null ? "profileempty.jpg" : q.ProfilePhoto
            }).ToList();

            ViewBag.drpCities = unit.CityRepo.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();

            if (gender != null)
            {
                if (gender == "Kadın-Oyuncular")
                {
                    webusers = webusers.Where(x => x.Yas > 18 && x.Gender == "Kadın").ToList();
                }
                else if (gender == "Erkek-Oyuncular")
                {
                    webusers = webusers.Where(x => x.Yas > 18 && x.Gender == "Erkek").ToList();
                }
                else if (gender == "Cocuk_K")
                {
                    webusers = webusers.Where(x => x.Yas < 18 && x.Gender == "Kadın").ToList();
                }
                else
                {
                    webusers = webusers.Where(x => x.Yas < 18 && x.Gender == "Erkek").ToList();
                }

            }


            return View(webusers);
        }
        public ActionResult FilterUsers(WebUserListFilterVM filters)
        {

            int yas1 = Convert.ToInt32(filters.yas.Substring(0, filters.yas.IndexOf(',')));
            int yas2 = Convert.ToInt32(filters.yas.Substring(filters.yas.IndexOf(',') + 1));

            int kilo1 = Convert.ToInt32(filters.kilo.Substring(0, filters.kilo.IndexOf(',')));
            int kilo2 = Convert.ToInt32(filters.kilo.Substring(filters.kilo.IndexOf(',') + 1));

            int boy1 = Convert.ToInt32(filters.boy.Substring(0, filters.boy.IndexOf(',')));
            int boy2 = Convert.ToInt32(filters.boy.Substring(filters.boy.IndexOf(',') + 1));

            List<WebUserListVM> webusers;

            webusers = unit.WebUserRepo.GetAll().Select(q => new WebUserListVM()
            {
                Name = q.Name,
                FullName = q.Name + " " + q.LastName,
                Yas = Convert.ToInt32(DateTimeManager.CalculateYourAge(q.BirthDate)),
                City = q.City?.Name,
                CityID = q.CityID.Value,
                ID = q.ID,
                Height = q.Height,
                Weight = q.Weight,
                Gender = q.Gender,
                ProfilePic = q.ProfilePhoto == "" || q.ProfilePhoto == null ? "profileempty.jpg" : q.ProfilePhoto
            }).ToList();


            if (filters.cinsiyet != "farketmez")
            {
                webusers = webusers.Where(x => x.Gender.ToLower() == filters.cinsiyet).ToList();
            }

            if (filters.sehir != 0)
            {
                webusers = webusers.Where(x => x.CityID == filters.sehir).ToList();
            }

            if (filters.oyuncu_tur != "farketmez")
            {
                if (filters.oyuncu_tur == "yetiskin")
                {
                    webusers = webusers.Where(x => x.Yas >= 18).ToList();
                }
                else if (filters.oyuncu_tur == "cocuk")
                {
                    webusers = webusers.Where(x => x.Yas < 18).ToList();
                }
            }
           webusers = webusers.Where(x => (x.Yas >= yas1 && x.Yas <= yas2) && (x.Height >= boy1 && x.Height <= boy2) && (x.Weight >= kilo1 && x.Weight <= kilo2)).ToList();

            if (webusers.Count > 0)
            {
                return PartialView("~/Views/WebUserList/Partial/WebUserFilter.cshtml", webusers);
            }

            return Json("");
            
        }

    }
}
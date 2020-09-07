using OOI.Data.Entities;
using OOI.UI.Web.Models;
using OOI.UI.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Controllers
{

    public class WebUserController : BaseController
    {
        [Authorize]
        [HttpGet]
        public ActionResult WebUserGet(int? id)
        {
            int webuserid = id ?? GetWebUserID();

            WebUserGetVM model = GetWebUser(webuserid);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult InfoUpdate(WebUserGetVM model)
        {
            WebUser webUser = unit.WebUserRepo.FirstOrDefault(x => x.ID == model.ID);

            if (webUser != null)
            {
                webUser.Name = model.Name;
                webUser.LastName = model.LastName;
                webUser.Email = model.Email;
                webUser.Gender = model.Gender;
                webUser.BirthDate = model.BirthDate;
                webUser.DriverLicense = model.DriverLicense;
                webUser.CityID = model.CityID;
                webUser.University = model.University;
                webUser.Branch = model.Branch;
                webUser.Address = model.Address;
                webUser.Phone = model.Phone;

                if (model.mainfile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.mainfile.FileName);
                    string ex = Path.GetExtension(model.mainfile.FileName);
                    if (ex == ".png" || ex == ".jpg" || ex == ".jpeg" || ex == ".PNG" || ex == ".JPG" || ex == ".JPEG")
                    {
                        string guid = Guid.NewGuid().ToString();
                        string sqlref = "~/Content/WebUser/MainPhotos/" + guid + ex;
                        fileName = Path.Combine(Server.MapPath(sqlref));
                        model.mainfile.SaveAs(fileName);

                        webUser.ProfilePhoto = guid + ex;
                    }
                }

                unit.Save();
                TempData["IslemDurum"]= EnumIslemDurum.IslemBasarili;
            }

            return RedirectToAction("WebUserGet", "WebUser", new { id = webUser.ID });
        }

        [Authorize]
        [HttpPost]
        public ActionResult FeaturesUpdate(WebUserGetVM getModel)
        {
            WebUser webUser = unit.WebUserRepo.FirstOrDefault(x => x.ID == getModel.ID);

            if (webUser != null)
            {
                webUser.BodySize = getModel.BodySize;
                webUser.Height = getModel.Height;
                webUser.Weight = getModel.Weight;
                webUser.DressSize = getModel.DressSize;
                webUser.SkinColor = getModel.SkinColor;
                webUser.HairStyle = getModel.HairStyle;
                webUser.HairColor = getModel.HairColor;
                webUser.EyeColor = getModel.EyeColor;
                webUser.ShoeSize = getModel.ShoeSize;
                unit.Save();
                ViewBag.IslemDurum = EnumIslemDurum.IslemBasarili;
            }
            return RedirectToAction("WebUserGet", "WebUser", new { id = webUser.ID });
        }

        [Authorize]
        [HttpPost]
        public ActionResult PhotoUpdate(WebUserPhotosVM model)
        {
            int webuserid = GetWebUserID();
            int sayac = 0;
            foreach (var item in model.file)
            {
                if (item != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(item.FileName);
                    string ex = Path.GetExtension(item.FileName);
                    if (ex == ".png" || ex == ".jpg" || ex == ".jpeg" || ex == ".PNG" || ex == ".JPG" || ex == ".JPEG")
                    {
                        string guid = Guid.NewGuid().ToString();
                        string sqlref = "~/Content/WebUser/Photos/" + guid + ex;
                        fileName = Path.Combine(Server.MapPath(sqlref));
                        item.SaveAs(fileName);


                        if (model.photoid[sayac] != 0)
                        {
                            int id = model.photoid[sayac];
                            WebUserPhoto photo = unit.WebUserPhotoRepo.FirstOrDefault(q => q.ID == id);
                            photo.ImagePath = guid + ex;
                            unit.Save();
                        }
                        else
                        {
                            WebUserPhoto photo = new WebUserPhoto();
                            photo.ImagePath = guid + ex;
                            photo.WebUserID = webuserid;

                            unit.WebUserPhotoRepo.Add(photo);
                            unit.Save();

                        }
                    }
                }
                sayac++;

            }
            ViewBag.IslemDurum = EnumIslemDurum.IslemBasarili;
            return RedirectToAction("WebUserGet", "WebUser", new { id = webuserid });

        }
        [Route("Oyuncu-Listesi/Detay/{id}")]
        public ActionResult Detail(int id)
        {
            WebUserGetVM model = GetWebUser(id);
            return View(model);
        }

        public WebUserGetVM GetWebUser(int id)
        {

            WebUserGetVM model = new WebUserGetVM();

            model.ID = id;

            WebUser webUser = unit.WebUserRepo.FirstOrDefault(x => x.ID == model.ID);

            model.Name = webUser.Name;
            model.LastName = webUser.LastName;
            model.BirthDateString = webUser.BirthDate?.ToString("yyyy.MM.dd");
            model.Birthplace = webUser.Birthplace;
            model.DriverLicense = webUser.DriverLicense;
            model.University = webUser.University;
            model.Branch = webUser.Branch;
            model.Address = webUser.Address;
            model.Gender = webUser.Gender;
            model.Weight = webUser.Weight;
            model.Height = webUser.Height;
            model.DressSize = webUser.DressSize;
            model.SkinColor = webUser.SkinColor;
            model.BodySize = webUser.BodySize;
            model.ShoeSize = webUser.ShoeSize;
            model.HairColor = webUser.HairColor;
            model.HairStyle = webUser.HairStyle;
            model.EyeColor = webUser.EyeColor;
            model.Email = webUser.Email;
            model.Phone = webUser.Phone;
            model.CityID = webUser.CityID;
            model.BirthDate = webUser.BirthDate;
            model.IsRegisteredAagency = webUser.IsRegisteredAagency;
            if (String.IsNullOrEmpty(webUser.ProfilePhoto))
                model.ProfilePhoto = "empty.jpg";
            else
                model.ProfilePhoto = webUser.ProfilePhoto;

            model.drpCities = unit.CityRepo.GetAllQuery().Select(q => new SelectListItem()
            {
                Text = q.Name,
                Value = q.ID.ToString()
            }).ToList();
            model.UserPhotos = webUser.WebUserPhotos.Select(q => new WebUserPhotosVM()
            {
                ID = q.ID,
                Path = q.ImagePath
            }).ToList();

            if (model.UserPhotos.Count < 5)
            {
                int count = model.UserPhotos.Count;

                for (int i = 0; i < 5 - count; i++)
                {
                    model.UserPhotos.Add(new WebUserPhotosVM() { Path = "profileempty.jpg" });
                }
            }

            model.UserExperiences = unit.UserExperienceRepo.GetAll().Where(x => x.WebUserID == id && x.Deleted == false).Select(q => new UserExperienceVM()
            {
                ID = q.ID,
                Name = q.Name,
                Description=q.Description,
                //CreatedDateString=q.CreatedDate.ToString("dd MMMM yyyy, dddd"),
                //FinishedDateString=q.FinishedDate.ToString("dd MMMM yyyy, dddd"),
                ProjectDate=q.ProjectDate
            }).ToList();

            return model;
        }

        [HttpPost]
        public ActionResult AddUserExperience(UserExperienceVM model)
        {
            if (ModelState.IsValid)
            {
                UserExperience userExperience = new UserExperience();
                userExperience.Name = model.Name;
                userExperience.Description = model.Description;
                userExperience.CreatedDate = model.CreatedDate;
                //userExperience.FinishedDate = model.FinishedDate;
                userExperience.ProjectDate = model.ProjectDate;
                userExperience.WebUserID = model.ID;

                unit.UserExperienceRepo.Add(userExperience);
                ViewBag.IslemDurum = EnumIslemDurum.IslemBasarili;
            }
            return RedirectToAction("WebUserGet");
        }

        public ActionResult DeleteUserExperience(int id)
        {
            UserExperience userExperience = unit.UserExperienceRepo.FirstOrDefault(q => q.ID == id);
            if (userExperience != null)
            {
                userExperience.Deleted = true;
                userExperience.DeletedDate = DateTime.Now;
                unit.Save();
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}
using OOI.Data.Entities;
using OOI.StringExt.Date;
using OOI.UI.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Controllers
{
    public class AdvertController : BaseController
    {
        //[Route("dizi-film-reklam-kirala-sat")]
        public ActionResult Index()
        {
            List<AdvertVM> model = unit.AdvertRepo.GetAll().Select(q => new AdvertVM() {
                ID = q.ID,
                CategoryName=q.AdvertCategory.Name,
                AdvertCategoryID = q.AdvertCategoryID,
                Name = q.Name,
                Description = q.Description,
                CreatedDate = q.CreatedDate,
                AdvertPhone = q.AdvertPhone,
                MainPhoto = q.MainPhoto

            }).ToList();
            return View(model);
        }

        [Route("dizi-film-reklam-kirala-sat/{ilandetay}/{id}")]
        public ActionResult AdvertDetail(int id)
        {
            AdvertDetailVM model = GetAdvertDetailVM(id);
            return View(model);
        }
        public ActionResult Add()
        {
            return View(GetAdvertVM());
        }

        [HttpPost]
        public ActionResult Add(AdvertVM model, HttpPostedFileBase mainphoto, List<HttpPostedFileBase> advertphotos)
        {
            if (ModelState.IsValid)
            {
                Advert advert = new Advert();
                advert.Name = model.Name;
                advert.CreatedDate = model.CreatedDate;
                advert.AdvertCategoryID = model.AdvertCategoryID;
                advert.Description = model.Description;
                advert.AdvertPhone = model.AdvertPhone;
                advert.Price = model.Price;
                if (mainphoto != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(mainphoto.FileName);
                    string ex = Path.GetExtension(mainphoto.FileName);
                    if (ex == ".png" || ex == ".jpg" || ex == ".jpeg" || ex == ".PNG" || ex == ".JPG" || ex == ".JPEG")
                    {
                        string guid = Guid.NewGuid().ToString();
                        string sqlref = "~/Content/Advert/MainPhotos/" + guid + ex;
                        fileName = Path.Combine(Server.MapPath(sqlref));
                        mainphoto.SaveAs(fileName);
                        advert.MainPhoto = guid + ex;
                    }
                }
                Advert entity = unit.AdvertRepo.Add(advert);

                if (advertphotos != null)
                {
                    foreach (var item in advertphotos)
                    {
                        if (item != null)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(item.FileName);
                            string ex = Path.GetExtension(item.FileName);
                            if (ex == ".png" || ex == ".jpg" || ex == ".jpeg" || ex == ".PNG" || ex == ".JPG" || ex == ".JPEG")
                            {
                                string guid = Guid.NewGuid().ToString();
                                string sqlref = "~/Content/Advert/Photos/" + guid + ex;
                                fileName = Path.Combine(Server.MapPath(sqlref));
                                item.SaveAs(fileName);

                                AdvertPhoto advertPhoto = new AdvertPhoto();
                                advertPhoto.ImagePath = guid + ex;
                                advertPhoto.AdvertID = entity.ID;

                                unit.AdvertPhotoRepo.Add(advertPhoto);
                            }
                        }

                    }
                }

            }
            return View(GetAdvertVM());
        }

        AdvertDetailVM GetAdvertDetailVM(int id)
        {
            
            Advert advert = unit.AdvertRepo.FirstOrDefault(q => q.ID == id);
            AdvertDetailVM model = new AdvertDetailVM();

            if (advert != null)
            {
                model.CategoryName = advert.AdvertCategory?.Name;
                model.Name = advert.Name;
                model.AdvertPhone = advert.AdvertPhone;
                model.Description = advert.Description;
                model.CreatedDate = advert.CreatedDate.ToString("dd MMMM yyyy, dddd");
                string mainphoto = "";
                if (!String.IsNullOrEmpty(advert.MainPhoto))
                    mainphoto = advert.MainPhoto;
                else
                    mainphoto = "empty.jpg";

                model.MainPhoto = mainphoto;
                model.Photos = unit.AdvertPhotoRepo.GetAllQuerableWithQuery(x => x.AdvertID == id).Select(q => q.ImagePath).ToList();
                
                #region advertphotos
                model.AdvertPhotos = advert.AdvertPhotos.Select(q => new AdvertPhotosVM()
                {
                    ID = q.ID,
                    Path = q.ImagePath
                }).ToList();

                if (model.AdvertPhotos.Count < 5)
                {
                    int count = model.AdvertPhotos.Count;

                    for (int i = 0; i < 5 - count; i++)
                    {
                        model.AdvertPhotos.Add(new AdvertPhotosVM() { Path = "empty.jpg" });
                    }
                }
                #endregion

            }
            return model;
        }



        AdvertVM GetAdvertVM()
        {
            AdvertVM model = new AdvertVM();
            model.drpAdvertCategories = unit.AdvertCategoryRepo.GetAllQuery().Select(q => new SelectListItem()
            {
                Text = q.Name,
                Value = q.ID.ToString()
            }).ToList();

            return model;
        }

        public ActionResult ListAdvert()
        {

            List<AdvertVM> model = unit.AdvertRepo.GetAll().Where(q=>q.Deleted==false).Select(q => new AdvertVM()
            {
                Name = q.Name,
                StartDateString = q.CreatedDate.ToString("dd MMMM yyyy, dddd"),
                Description = q.Description,
                AdvertPhone=q.AdvertPhone,
                ID = q.ID
            }).ToList();

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            Advert advert = unit.AdvertRepo.FirstOrDefault(q => q.ID == id);
            if (advert != null)
            {
                advert.Deleted = true;
                advert.DeletedDate = DateTime.Now;
                unit.Save();
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }
    }

   
}
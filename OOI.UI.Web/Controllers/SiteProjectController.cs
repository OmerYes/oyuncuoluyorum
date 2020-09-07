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
    public class SiteProjectController : BaseController
    {
        public ActionResult Index()
        {
            int webuserid = GetWebUserID();
            List<ProjectVM> model = unit.ProjectRepo.GetAll().Select(q => new ProjectVM()
            {
                CompanyID = q.CompanyID,
                MainPhoto = q.CoverPhoto,
                Title = q.Title,
                //StartDateString = q.StartDate.ToString("dd MMMM yyyy, dddd"),
                EndDateString = q.EndDate.ToString("dd MMMM yyyy, dddd"),
                CategoryName = q.ProjectCategory.Name,
                Description = q.Description,
                ID = q.ID
            }).ToList();

            foreach (var item in model)
            {
                item.MainPhoto = (item.MainPhoto == "" || item.MainPhoto == null) ? "empty.jpg" : item.MainPhoto;
                item.ApplyStatus = unit.ProjectApplyRepo.Any(q => q.ProjectID == item.ID && q.WebUserID == webuserid);
                item.FirmName = unit.CompanyRepo.FirstOrDefault(q => q.ID == item.CompanyID)?.CompanyName;
            }

            return View(model);
        }
        public ActionResult ProjectDetail(int id)
        {
            ProjectDetailVM model = GetProjectDetailVM(id);
            return View(model);
        }

        //[Authorize]
        public ActionResult Add()
        {
            return View(GetProjectVM());
        }

        //[Authorize]
        [HttpPost]
        public ActionResult Add(ProjectVM model, HttpPostedFileBase mainphoto, List<HttpPostedFileBase> projectphotos)
        {
            if (ModelState.IsValid)
            {
                Project project = new Project();
                project.Title = model.Title;
                project.StartDate = model.StartDate;
                project.EndDate = model.EndDate;
                project.ProjectCategoryID = model.ProjectCategoryID;
                project.Description = model.Description;
                project.CompanyID = GetWebUserID();

                if (mainphoto != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(mainphoto.FileName);
                    string ex = Path.GetExtension(mainphoto.FileName);
                    if (ex == ".png" || ex == ".jpg" || ex == ".jpeg" || ex == ".PNG" || ex == ".JPG" || ex == ".JPEG")
                    {
                        string guid = Guid.NewGuid().ToString();
                        string sqlref = "~/Content/Projects/MainPhotos/" + guid + ex;
                        fileName = Path.Combine(Server.MapPath(sqlref));
                        mainphoto.SaveAs(fileName);
                        project.CoverPhoto = guid + ex;
                    }
                }
                Project entity = unit.ProjectRepo.Add(project);

                if (projectphotos != null)
                {
                    foreach (var item in projectphotos)
                    {
                        if (item != null)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(item.FileName);
                            string ex = Path.GetExtension(item.FileName);
                            if (ex == ".png" || ex == ".jpg" || ex == ".jpeg" || ex == ".PNG" || ex == ".JPG" || ex == ".JPEG")
                            {
                                string guid = Guid.NewGuid().ToString();
                                string sqlref = "~/Content/Projects/Photos/" + guid + ex;
                                fileName = Path.Combine(Server.MapPath(sqlref));
                                item.SaveAs(fileName);

                                ProjectPhoto projectphoto = new ProjectPhoto();
                                projectphoto.ImagePath = guid + ex;
                                projectphoto.ProjectID = entity.ID;

                                unit.ProjectPhotoRepo.Add(projectphoto);
                            }
                        }

                    }
                }

            }
            return View(GetProjectVM());
        }

        ProjectVM GetProjectVM()
        {
            ProjectVM model = new ProjectVM();
            model.drpProjectCategories = unit.ProjectCategoryRepo.GetAllQuery().Select(q => new SelectListItem()
            {
                Text = q.Name,
                Value = q.ID.ToString()
            }).ToList();

            return model;
        }

        public ActionResult SiteProjectAddUsers()
        {
            List<WebUserListVM> webusers = unit.WebUserRepo.GetAll().Select(q => new WebUserListVM()
            {
                FullName = q.Name + " " + q.LastName,
                Age = DateTimeManager.CalculateYourAge(q.BirthDate),
                City = q.City?.Name,
                ID = q.ID,
                ProfilePic = q.ProfilePhoto
            }).ToList();

            return View(webusers);
        }

        public ActionResult Edit(int id)
        {
            return View(GetProjectVM());
        }

        ProjectDetailVM GetProjectDetailVM(int id)
        {
            int webuserid = GetWebUserID();
            Project project = unit.ProjectRepo.FirstOrDefault(q => q.ID == id);
            ProjectDetailVM model = new ProjectDetailVM();

            if (project != null)
            {
                model.CompanyName = unit.CompanyRepo.FirstOrDefault(q => q.ID == project.CompanyID)?.CompanyName;
                model.Title = project.Title;
                model.Description = project.Description;
                model.StartDateString = project.StartDate.ToString("dd MMMM yyyy, dddd");
                model.EndDateString = project.EndDate.ToString("dd MMMM yyyy, dddd");
                string mainphoto = "";
                if (!String.IsNullOrEmpty(project.CoverPhoto))
                    mainphoto = project.CoverPhoto;
                else
                    mainphoto = "empty.jpg";

                model.MainPhoto = mainphoto;
                model.Photos = unit.ProjectPhotoRepo.GetAllQuerableWithQuery(x => x.ProjectID == id).Select(q => q.ImagePath).ToList();
                model.CategoryName = project.ProjectCategory.Name;
                model.ApplyStatus = unit.ProjectApplyRepo.Any(q => q.ProjectID == id && q.WebUserID == webuserid);
                #region projectuser
                List<ProjectUserVM> projectusers = new List<ProjectUserVM>();

                List<ProjectUser> userids = unit.ProjectUserRepo.GetAllQuerableWithQuery(q => q.ProjectId == id).ToList();

                foreach (var item in userids)
                {
                    WebUser webuser = unit.WebUserRepo.FirstOrDefault(q => q.ID == item.WebUserId);

                    ProjectUserVM puser = new ProjectUserVM();
                    puser.Name = webuser.Name;
                    puser.SurName = webuser.LastName;
                    puser.MainPhoto = webuser.ProfilePhoto;

                    projectusers.Add(puser);
                }

                model.ProjectUsers = projectusers;
                #endregion

                #region projectphotos
                model.ProjectPhotos = project.ProjectPhotos.Select(q => new ProjectPhotosVM()
                {
                    ID = q.ID,
                    Path = q.ImagePath
                }).ToList();

                if (model.ProjectPhotos.Count < 5)
                {
                    int count = model.ProjectPhotos.Count;

                    for (int i = 0; i < 5 - count; i++)
                    {
                        model.ProjectPhotos.Add(new ProjectPhotosVM() { Path = "empty.jpg" });
                    }
                }
                #endregion

            }
            return model;
        }

        public ActionResult FirmProject()
        {
            int companyid = GetWebUserID();
            List<ProjectVM> model = unit.ProjectRepo.GetAll().Where(x => x.CompanyID == companyid).Select(q => new ProjectVM()
            {
                Title = q.Title,
                StartDateString = q.StartDate.ToString("dd MMMM yyyy, dddd"),
                EndDateString = q.EndDate.ToString("dd MMMM yyyy, dddd"),
                CategoryName = q.ProjectCategory.Name,
                Description = q.Description,
                ID = q.ID
            }).ToList();

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            int companyid = GetWebUserID();
            Project project = unit.ProjectRepo.FirstOrDefault(q => q.ID == id && q.CompanyID == companyid);
            if (project != null)
            {
                project.Deleted = true;
                unit.Save();
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }


    }
}
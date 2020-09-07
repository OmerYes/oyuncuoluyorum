using OOI.Data.Entities;
using OOI.UI.Web.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Areas.Admin.Controllers
{
    public class InterviewController : BaseController
    {
        // GET: Admin/Interview
        [HttpGet]
        public ActionResult AddInterview()
        {
            InterviewVM interviewVM = new InterviewVM();
            return View(interviewVM);
        }

        [HttpPost]
        public ActionResult AddInterview(InterviewVM model, HttpPostedFileBase mainphoto)
        {
            if (ModelState.IsValid)
            {
                Interview interview = new Interview();
                interview.Name = model.Name;
                interview.Description = model.Description;

                if (mainphoto != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(mainphoto.FileName);
                    string ex = Path.GetExtension(mainphoto.FileName);
                    if (ex == ".png" || ex == ".jpg" || ex == ".jpeg" || ex == ".PNG" || ex == ".JPG" || ex == ".JPEG")
                    {
                        string guid = Guid.NewGuid().ToString();
                        string sqlref = "~/Areas/Admin/Content/Interview/MainPhoto/" + guid + ex;
                        fileName = Path.Combine(Server.MapPath(sqlref));
                        mainphoto.SaveAs(fileName);
                        interview.MainPhoto = guid + ex;
                    }
                }


                unit.InterviewRepo.Add(interview);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Index()
        {
           List<InterviewVM> model = unit.InterviewRepo.GetAllQuery().Select(q => new InterviewVM()
            {
                ID = q.ID,
                Name = q.Name,
                Description = q.Description,
            }).ToList();
            return View(model);
        }

        public ActionResult InterviewDetail(int id)
        {
            InterviewVM model = new InterviewVM();
            Interview interview = unit.InterviewRepo.FirstOrDefault(q => q.ID == id);

            if (interview != null)
            {
                model.ID = interview.ID;
                model.Name = interview.Name;
                model.Description = interview.Description;

                return View(model);

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateInterview(int id)
        {
            Interview interview = unit.InterviewRepo.FirstOrDefault(q => q.ID == id);
            InterviewVM model = new InterviewVM();

            model.ID = interview.ID;
            model.Name = interview.Name;
            model.Description = interview.Description;
           
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateInterview(InterviewVM model)
        {
            Interview interview = unit.InterviewRepo.FirstOrDefault(q => q.ID == model.ID);

            interview.Name = model.Name;
            interview.Description = model.Description;
            unit.InterviewRepo.Update(interview);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveInterview(int id)
        {
            unit.InterviewRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
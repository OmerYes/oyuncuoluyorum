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
    public class OpportunityController : BaseController
    {
        // GET: Admin/Opportunity
        public ActionResult Index()
        {
            List<OpportunityVM> model = unit.OpportunityRepo.GetAllQuery().Select(q => new OpportunityVM()
            {
                ID = q.ID,
                Name = q.Name,
                Description = q.Description,
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddOpportunity()
        {
            OpportunityVM opportunityVM = new OpportunityVM();
            return View(opportunityVM);
        }

        [HttpPost]
        public ActionResult AddOpportunity(OpportunityVM model, HttpPostedFileBase mainphoto)
        {
            if (ModelState.IsValid)
            {
                Opportunity opportunity = new Opportunity();
                opportunity.Name = model.Name;
                opportunity.Description = model.Description;


                if (mainphoto != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(mainphoto.FileName);
                    string ex = Path.GetExtension(mainphoto.FileName);
                    if (ex == ".png" || ex == ".jpg" || ex == ".jpeg" || ex == ".PNG" || ex == ".JPG" || ex == ".JPEG")
                    {
                        string guid = Guid.NewGuid().ToString();
                        string sqlref = "~/Areas/Admin/Content/Opportunity/MainPhoto/" + guid + ex;
                        fileName = Path.Combine(Server.MapPath(sqlref));
                        mainphoto.SaveAs(fileName);
                        opportunity.MainPhoto = guid + ex;
                    }
                }


                unit.OpportunityRepo.Add(opportunity);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult OpportunityDetail(int id)
        {
            OpportunityVM model = new OpportunityVM();
            Opportunity opportunity = unit.OpportunityRepo.FirstOrDefault(q => q.ID == id);

            if (opportunity != null)
            {
                model.ID = opportunity.ID;
                model.Name = opportunity.Name;
                model.Description = opportunity.Description;

                return View(model);

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateOpportunity(int id)
        {
            Opportunity opportunity = unit.OpportunityRepo.FirstOrDefault(q => q.ID == id);
            OpportunityVM model = new OpportunityVM();

            model.ID = opportunity.ID;
            model.Name = opportunity.Name;
            model.Description = opportunity.Description;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateOpportunity(InterviewVM model)
        {
            Opportunity opportunity = unit.OpportunityRepo.FirstOrDefault(q => q.ID == model.ID);


            opportunity.Name = model.Name;
            opportunity.Description = model.Description;
            unit.OpportunityRepo.Update(opportunity);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveOpportunity(int id)
        {
            unit.OpportunityRepo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
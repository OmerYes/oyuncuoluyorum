using OOI.Data.Entities;
using OOI.UI.Web.Models.Attributes;
using OOI.UI.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            HomeVM model = new HomeVM();

            List<ProjectVM> projects = unit.ProjectRepo.GetAll().Select(q => new ProjectVM()
            {
                MainPhoto = q.CoverPhoto,
                Title = q.Title,
                StartDateString = q.StartDate.ToString("dd MMMM yyyy, dddd"),
                EndDateString = q.EndDate.ToString("dd MMMM yyyy, dddd"),
                CategoryName = q.ProjectCategory.Name,
                Description = q.Description,
                ID = q.ID
            }).Take(4).ToList();


            List<Areas.Admin.Models.VM.InterviewVM> interviews = unit.InterviewRepo.GetAll().Select(q => new Areas.Admin.Models.VM.InterviewVM()
            {
                Name=q.Name,
                MainPhoto = q.MainPhoto,
                StartDateString = q.CreatedDate.ToString("dd MMMM yyyy, dddd"),
                Description = q.Description,
                ID = q.ID
            }).Take(3).ToList();

            List<Areas.Admin.Models.VM.OpportunityVM> opportunities = unit.OpportunityRepo.GetAll().Select(q => new Areas.Admin.Models.VM.OpportunityVM()
            {
                Name = q.Name,
                MainPhoto = q.MainPhoto,
                StartDateString = q.CreatedDate.ToString("dd MMMM yyyy, dddd"),
                Description = q.Description,
                ID = q.ID
            }).Take(3).ToList();

            model.Projects = projects;
            model.Interviews = interviews;
            model.Opportunities = opportunities;

            return View(model);
        }

        [Route("Home/Roportaj-Soylesi/{id}")]
        public ActionResult InterviewDetail(int id)
        {
            HomeVM homeVM = new HomeVM();

            OOI.UI.Web.Areas.Admin.Models.VM.InterviewVM interviewVM = new OOI.UI.Web.Areas.Admin.Models.VM.InterviewVM();

            Interview model = unit.InterviewRepo.FirstOrDefault(q => q.ID == id);

            interviewVM.ID = model.ID;
            interviewVM.Name = model.Name;
            interviewVM.Description = model.Description;
            interviewVM.StartDateString = model.CreatedDate.ToString("dd MMMM yyyy, dddd");
            interviewVM.MainPhoto = model.MainPhoto;
         
            List<Areas.Admin.Models.VM.InterviewVM> interviews = unit.InterviewRepo.GetAll().Select(q => new Areas.Admin.Models.VM.InterviewVM()
            {
                Name = q.Name,
                MainPhoto = q.MainPhoto,
                StartDateString = q.CreatedDate.ToString("dd MMMM yyyy, dddd"),
                Description = q.Description,
                ID = q.ID
            }).Take(5).ToList();

            homeVM.Interviews = interviews;
            homeVM.Interview = interviewVM;
            return View(homeVM);
        }

        [Route("Home/firsat-kampanya/{id}")]
        public ActionResult OpportunityDetail(int id)
        {
            HomeVM homeVM = new HomeVM();

            OOI.UI.Web.Areas.Admin.Models.VM.OpportunityVM opportunityVM = new OOI.UI.Web.Areas.Admin.Models.VM.OpportunityVM();

            Opportunity model = unit.OpportunityRepo.FirstOrDefault(q => q.ID == id);

            opportunityVM.ID = model.ID;
            opportunityVM.Name = model.Name;
            opportunityVM.Description = model.Description;
            opportunityVM.StartDateString = model.CreatedDate.ToString("dd MMMM yyyy, dddd");
            opportunityVM.MainPhoto = model.MainPhoto;

            List<Areas.Admin.Models.VM.OpportunityVM> opportunities = unit.OpportunityRepo.GetAll().Select(q => new Areas.Admin.Models.VM.OpportunityVM()
            {
                Name = q.Name,
                MainPhoto = q.MainPhoto,
                StartDateString = q.CreatedDate.ToString("dd MMMM yyyy, dddd"),
                Description = q.Description,
                ID = q.ID
            }).Take(5).ToList();

            homeVM.Opportunities = opportunities;
            homeVM.Opportunity = opportunityVM;
            return View(homeVM);
        }

        public ActionResult SecurityInfoPage()
        {
            return View("Guvenlik");
        }
    }
}
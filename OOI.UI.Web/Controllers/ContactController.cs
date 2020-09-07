using OOI.Data.Entities;
using OOI.UI.Web.Models;
using OOI.UI.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace OOI.UI.Web.Controllers
{
    public class ContactController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactVM model)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new Contact();
                contact.Name = model.Name;
                contact.SurName = model.SurName;
                contact.Message = model.Message;
                contact.Phone = model.Phone;
                contact.EMail = model.EMail;

                unit.ContactRepo.Add(contact);

                ViewBag.IslemDurum = EnumIslemDurum.IslemBasarili;
            }
            else
            {
                ViewBag.IslemDurum = EnumIslemDurum.ValidationHata;
            }
            return View();
        }


    }
}

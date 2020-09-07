using OOI.UI.Web.Areas.Admin.Models.VM;
using OOI.UI.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OOI.UI.Web.Areas.Admin.Controllers
{
    public class AdvertController :BaseController
    {
        // GET: Admin/Advert
        public ActionResult Index()
        {
            List<AdvertVM> model = unit.AdvertRepo.GetAll().Select(q => new AdvertVM()
            {
                ID = q.ID,
                AdvertCategoryID = q.AdvertCategoryID,
                Name = q.Name,
                Description = q.Description,
                CreatedDate = q.CreatedDate,
                AdvertPhone = q.AdvertPhone,
                MainPhoto = q.MainPhoto

            }).ToList();
            return View(model);
        }
    }
}
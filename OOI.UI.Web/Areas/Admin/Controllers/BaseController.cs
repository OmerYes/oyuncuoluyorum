using OOI.Business.Manager.Repository;
using OOI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public UnitOfWork unit;

        public BaseController()
        {
            unit = new UnitOfWork();
        }

        protected override void Dispose(bool disposing)
        {
            unit.Dispose();
            base.Dispose(disposing);
        }
    }
}
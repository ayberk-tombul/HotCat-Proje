using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotCat_Proje.Models.Entity;

namespace HotCat_Proje.Controllers
{
    public class TablesController : Controller
    {
        // GET: Tables
        HotCatDbEntities db = new HotCatDbEntities();
        public ActionResult Table()
        {
            var values = db.Tables.ToList();
            return View(values);
        }
    }
}
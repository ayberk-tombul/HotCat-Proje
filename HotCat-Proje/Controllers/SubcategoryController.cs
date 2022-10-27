using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotCat_Proje.Models.Entity;

namespace HotCat_Proje.Controllers
{
    public class SubcategoryController : Controller
    {
        // GET: Subcategory
        HotCatDbEntities db = new HotCatDbEntities();

        public ActionResult subCategories()
        {
            var values = db.subCategories.ToList();
            return View(values);
        }
    }
}
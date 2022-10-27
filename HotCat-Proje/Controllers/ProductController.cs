using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotCat_Proje.Models.Entity;


namespace HotCat_Proje.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        HotCatDbEntities db = new HotCatDbEntities();

        public ActionResult Products()
        {
            var values = db.Products.ToList();
            return View(values);
        }
    }
}
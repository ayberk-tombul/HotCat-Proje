using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using HotCat_Proje.Models.Entity;

namespace HotCat_Proje.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        // Eğer view ismini değiştirseniz actionresult methodundaki Indexide değiştirmeniz lazım.

        HotCatDbEntities db = new HotCatDbEntities();

        public ActionResult CategoryList()
        {
            var values = db.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCategory(Categories c1)
        {
            db.Categories.Add(c1);
            db.SaveChanges();
            return View();
        }
    }
}
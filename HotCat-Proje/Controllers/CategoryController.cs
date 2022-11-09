using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using HotCat_Proje.Models.Entity;
using PagedList;
using PagedList.Mvc;

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
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.Categories.Add(c1);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public ActionResult GetCategory(int id)
        {
            var category = db.Categories.Find(id);
            return View("GetCategory",category);
        }
        public ActionResult Update(Categories c1)
        {
            var ctgr = db.Categories.Find(c1.CategoryID);
            ctgr.Category_Name = c1.Category_Name;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}
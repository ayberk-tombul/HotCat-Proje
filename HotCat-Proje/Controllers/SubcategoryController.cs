using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using HotCat_Proje.Models.Entity;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using PagedList;
using PagedList.Mvc;

namespace HotCat_Proje.Controllers
{
    public class SubcategoryController : Controller
    {
        // GET: Subcategory
        HotCatDbEntities db = new HotCatDbEntities();

        public ActionResult subCategories(int page=1)
        {
            //var values = db.subCategories.ToList();
            var values = db.subCategories.ToList().ToPagedList(page, 10);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewsubCategories()
        {
            List<SelectListItem> degerler = (from i in db.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Category_Name,
                                                 Value= i.CategoryID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult NewsubCategories(subCategories s1)
        {
            db.subCategories.Add(s1);
            db.SaveChanges();
            return RedirectToAction("subCategories");
        }
        public ActionResult GetSubCategory(int id)
        {
            var sub = db.subCategories.Find(id);

            List<SelectListItem> degerler = (from i in db.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Category_Name,
                                                 Value = i.CategoryID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("GetSubCategory",sub);
        }
        public ActionResult Update(subCategories s1)
        {
            var subc = db.subCategories.Find(s1.Subcategory_ID);
            subc.SubCategoryName = s1.SubCategoryName;
            subc.category_id = s1.category_id;
            db.SaveChanges();
            return RedirectToAction("subCategories");
        }
    }
}
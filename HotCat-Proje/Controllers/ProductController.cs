using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotCat_Proje.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace HotCat_Proje.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        HotCatDbEntities db = new HotCatDbEntities();

        public ActionResult Products(int page=1)
        {
            //var values = db.Products.ToList();
            var values = db.Products.ToList().ToPagedList(page, 10);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewProduct() 
        {
            List<SelectListItem> degerler = (from i in db.subCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.SubCategoryName,
                                                 Value = i.Subcategory_ID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(Products p1)
        {
            db.Products.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Products");
        }
        public ActionResult GetProduct(int id)
        {
            var pro = db.Products.Find(id);

            List<SelectListItem> degerler = (from i in db.subCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.SubCategoryName,
                                                 Value = i.Subcategory_ID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("GetProduct", pro);
        }
        public ActionResult Update(Products p1)
        {
            var prod = db.Products.Find(p1.ProductID);
            prod.Product_Name = p1.Product_Name;
            prod.Subcategory_id = p1.Subcategory_id;
            prod.price = p1.price;
            prod.product_stock = p1.product_stock;
            prod.image = p1.image;
            db.SaveChanges();
            return RedirectToAction("Products");
        }
    }
}
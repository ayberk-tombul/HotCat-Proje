using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotCat_Proje.Models.Entity;

namespace HotCat_Proje.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        HotCatDbEntities db = new HotCatDbEntities();
        public ActionResult Order()
        {
            var values = db.Orders.ToList();
            return View(values);
        }
    }
}
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
        [HttpGet]
        public ActionResult NewTable()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewTable(Tables t1)
        {
            db.Tables.Add(t1);
            db.SaveChanges();
            return RedirectToAction("Table");
        }
        public ActionResult SIL(int id)
        {
            var table = db.Tables.Find(id);
            db.Tables.Remove(table);
            db.SaveChanges();
            return RedirectToAction("Table");
        }
        public ActionResult GetTable(int id)
        {
            var tab = db.Tables.Find(id);
            return View("GetTable",tab);
        }
        public ActionResult Update(Tables t1)
        {
            var table = db.Tables.Find(t1.TableID);
            table.code = t1.code;
            db.SaveChanges();
            return RedirectToAction("Table");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotCat_Proje.Models.Entity;

namespace HotCat_Proje.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        HotCatDbEntities db = new HotCatDbEntities();
        public ActionResult Employee()
        {
            var values = db.Employees.ToList();
            return View(values);
        }
    }
}
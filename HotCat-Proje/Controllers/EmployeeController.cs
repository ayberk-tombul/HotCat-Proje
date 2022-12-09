using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotCat_Proje.Models.Entity;
using PagedList;
using PagedList.Mvc;
using System.Web.Security;

namespace HotCat_Proje.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        HotCatDbEntities db = new HotCatDbEntities();

        [Authorize]
        public ActionResult Employee(int page=1)
        {
            //var values = db.Employees.ToList();
            var values = db.Employees.ToList().ToPagedList(page, 10);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewEmployee()
        {
            List<SelectListItem> degerler = (from i in db.Roles.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.RoleName,
                                                 Value = i.Roles_ID.ToString()
                                             }).ToList();
            ViewBag.dgr = new SelectList(degerler, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult NewEmployee(Employees e1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewEmployee");
            }

            db.Employees.Add(e1);
            db.SaveChanges();
            return RedirectToAction("Employee");
        }
        public ActionResult SIL(int id)
        {
            var employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Employee");
        }
        public ActionResult GetEmployee(int id)
        {
            var emp = db.Employees.Find(id);
            return View("GetEmployee",emp);
        }
        public ActionResult Update(Employees e1)
        {
            var emplo = db.Employees.Find(e1.EmployeeID);
            emplo.First_Name = e1.First_Name;
            emplo.Last_Name = e1.Last_Name;
            emplo.Email = e1.Email;
            db.SaveChanges();
            return RedirectToAction("Employee");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employees e1)
        {
            var bilgiler = db.Employees.FirstOrDefault(x => x.Email == e1.Email && x.Password == e1.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Email, false);
                return RedirectToAction("CategoryList", "Category");
            }
            else
            {
                
                return View();
            }
        }

    }
}
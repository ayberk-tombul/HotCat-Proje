using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotCat_Proje.Models.Entity;
using Newtonsoft.Json;

namespace HotCat_Proje.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        // GET: Orders
        HotCatDbEntities db = new HotCatDbEntities();
        public ActionResult Order()
        {
            List<SelectListItem> degerler = (from i in db.Tables.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.code,
                                                 Value = i.TableID.ToString()
                                             }).ToList();
            ViewBag.masalar = degerler;
            var values = db.Orders.ToList();
            return View(values);
        }


        [HttpPost]
        public Object SipariseUrunEkle(string masaId , string productId ,int quantity = 1)
        {
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Error = (sender, args) =>
                {
                    args.ErrorContext.Handled = true;
                },
            };
            var product = db.Products.First(pr => pr.ProductID.ToString() == productId);
            if (product.product_stock >= quantity)
            { 
            var userId = db.Employees.First(e => e.Email == User.Identity.Name);
            if (db.Orders.Where(ord => ord.table_id.ToString() == masaId && ord.status).Count() != 0)
            {
                var order = db.Orders.First(ord => ord.table_id.ToString() == masaId && ord.status);
                     //eğer satır varsa quantity update etmek
                    if (db.order_products.Where(ord => ord.order_id == order.Order_ID && ord.product_id == product.ProductID).Count() != 0)
                {
                        var order_product = db.order_products.First(ord => ord.order_id == order.Order_ID && ord.product_id == product.ProductID);
                        order_product.quantity = order_product.quantity + quantity;
                        db.SaveChanges();
                        return JsonConvert.SerializeObject(order_product, settings);
                    }
                    else
                    {
                        var orderProduct = new order_products();
                        orderProduct.product_id = Convert.ToInt32(productId);
                        orderProduct.order_id = Convert.ToInt32(order.Order_ID);
                        orderProduct.quantity = quantity;
                        db.order_products.Add(orderProduct);
                        product.product_stock = product.product_stock - quantity;
                        db.SaveChanges();

                        return JsonConvert.SerializeObject(orderProduct, settings);
                    }
                }
                
               
            else
            {
                var newOrder = new Orders();
                newOrder.employee_id = userId.EmployeeID;
                newOrder.table_id = Convert.ToInt32(masaId);
                newOrder.status = true;
                db.Orders.Add(newOrder);
                db.SaveChanges();
                var orderProduct = new order_products();
                orderProduct.product_id = Convert.ToInt32(productId);
                orderProduct.order_id = Convert.ToInt32(newOrder.Order_ID);
                orderProduct.quantity = quantity;
                db.order_products.Add(orderProduct);
                product.product_stock = product.product_stock - quantity;
                db.SaveChanges();
                return JsonConvert.SerializeObject(orderProduct, settings);

                }
            }
            else
            {
                return Json("Stokta yeterli Ürün yok", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult SiparisGir(int id)
        {
            List<SelectListItem> categories = (from i in db.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Category_Name,
                                                 Value = i.CategoryID.ToString()
                                             }).ToList();
            List<SelectListItem> subCategories = (from i in db.subCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.SubCategoryName,
                                                 Value = i.Subcategory_ID.ToString() + "/" + i.category_id
                                             }).ToList();
            List<SelectListItem> products = (from i in db.Products.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.Product_Name + ":   " + i.price +" TL",
                                                      Value = i.ProductID.ToString() + "/" + i.Subcategory_id
                                                  }).ToList();  
            
            if (db.Orders.Where(ord => ord.table_id == id && ord.status).Count() != 0)
            {
                var order =  db.Orders.First(ord => ord.table_id == id && ord.status);
                var active_order_products = db.order_products.Where(op => op.order_id == order.Order_ID).ToList();
                var NewActiveList = new SelectList(active_order_products, "product_id", "quantity");
                var order_Products = new List<Products>();
                foreach (var item in active_order_products)
                {
                    var product = db.Products.First(pro => pro.ProductID == item.product_id);
                    order_Products.Add(product);
                }
                ViewBag.orderProducts = JsonConvert.SerializeObject(order, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }

            ViewBag.categories = categories;
            ViewBag.subCategories = subCategories;
            ViewBag.products = products;
            ViewBag.masaId=id;
            return View();
        }


        public ActionResult SiparisUrunSil(int order_id , int product_id)
        {
            var product = db.Products.First(pr => pr.ProductID == product_id);
            var order_product = db.order_products.First(ord => ord.order_id == order_id && ord.product_id == product_id);
            product.product_stock = product.product_stock + order_product.quantity;
            db.order_products.Remove(order_product);
            db.SaveChanges();

            return Json("Ürün Silindi", JsonRequestBehavior.AllowGet);
        }

        public ActionResult OdemeYap(int order_id , float total)
        {
            var userId = db.Employees.First(e => e.Email == User.Identity.Name).EmployeeID;
            var newReceipt = new Receipt();
            newReceipt.order_id = order_id;
            newReceipt.price = total;
            newReceipt.employee_id = userId;
            db.Receipt.Add(newReceipt);
            var order = db.Orders.First(ord => ord.Order_ID == order_id);
            order.status = false;
            db.SaveChanges();


            return Json("Siparis ödenmiştir", JsonRequestBehavior.AllowGet);
        }
    }
   

}


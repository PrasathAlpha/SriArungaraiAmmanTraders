using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using SriArungaraiAmmanTraders.Models;

namespace SriArungaraiAmmanTraders.Controllers
{
    public class ProductsController : Controller
    {
        private readonly NutritionDBContext dB;
        public ProductsController()
        {
             dB = new NutritionDBContext();
        }


        public ActionResult index()
        {
            Product product = new Product();
            var result = product.ListProducts();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                dB.Products.Add(product);
                dB.SaveChanges();
                return RedirectToAction("ProductList");
            }

            return View(product);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var singleProduct = dB.Products.SingleOrDefault(x => x.Prod_Code == id);

            if(singleProduct == null)
            {
                return HttpNotFound();
            }

            return View(singleProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                dB.Entry(product).State = EntityState.Modified;
                dB.SaveChanges();
                return RedirectToAction("ProductList");
            }

            return View(product);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var singleProduct = dB.Products.FirstOrDefault(x => x.Prod_Code == id);

            if(singleProduct==null)
            {
                return HttpNotFound();
            }

            return View(singleProduct);
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            if(ModelState.IsValid)
            {
                dB.Products.Remove(product);
                dB.SaveChanges();
                return RedirectToAction("ProductList");
            }

            return View(product);
        }
    }

}
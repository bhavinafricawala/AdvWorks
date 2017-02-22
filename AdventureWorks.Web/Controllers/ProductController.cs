using AdventureWorks.Business.Product;
using AdventureWorks.Data.ProductData;
using AdventureWorks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DbConnection db = new DbConnection();
        public ActionResult Index()
        {
            try
            {
                IList<Product> products = new ProductAccess(db).GetAllProducts();

                return View(products);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                Product product = new ProductAccess(db).GetProductById(id);

                return View(product);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    new ProductAccess(db).UpdateProduct(product);
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Create()
        {
            Product product = new Product();

            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    new ProductAccess(db).InsertProduct(product);
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Product product = new ProductAccess(db).GetProductById(id);
                return View(product);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Product product = new ProductAccess(db).GetProductById(id);

                if (ModelState.IsValid)
                {
                    new ProductAccess(db).DeleteProduct(product);

                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                Product product = new ProductAccess(db).GetProductById(id);

                return View(product);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
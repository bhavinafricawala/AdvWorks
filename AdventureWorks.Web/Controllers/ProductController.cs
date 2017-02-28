using AdventureWorks.Business.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using AdventureWorks.Web.ProductService;

namespace AdventureWorks.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
     
        Service1Client client = new Service1Client();

        public ActionResult Index()
        {
            try
            {

                IList<Product> products = client.GetAllProducts();
                //IList<Product> products = new ProductAccess(db, log).GetAll();

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
                Product product = client.GetProductById(id);

                return View(product);
            }
            catch (Exception ex)
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
                    client.UpdateProduct(product);
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception ex)
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
                    client.InsertProduct(product);
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
                Product product = client.GetProductById(id);
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
                Product product = client.GetProductById(id);

                if (ModelState.IsValid)
                {
                    client.DeleteProduct(product);

                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Details(int id)
        {
            try
            { //aa
                Product product = client.GetProductById(id);

                return View(product);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
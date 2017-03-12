using AdventureWorks.Entities.Product;
using AdventureWorks.Factory;
using System;
using System.Collections.Generic;

namespace AdventureWorks.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ProductFacade : IService1
    {
        ProductFactory factory = new ProductFactory();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public IList<Product> GetAllProducts()
        {
            var repo = factory.InvokeProductAccess();
            return repo.GetAll();
        }

        public Product GetProductById(int id)
        {
            var repo = factory.InvokeProductAccess();
            return repo.GetById(id);
        }

        public int InsertProduct(Product product)
        {
            var repo = factory.InvokeProductAccess();
            return repo.Insert(product);
        }

        public int UpdateProduct(Product product)
        {
            var repo = factory.InvokeProductAccess();
            return repo.Update(product);
        }

        public int DeleteProduct(Product product)
        {
            var repo = factory.InvokeProductAccess();
            return repo.Delete(product);
        }
    }
}

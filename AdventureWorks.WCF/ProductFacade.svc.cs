using AdventureWorks.Business.Product;
using AdventureWorks.Data.Interfaces;
using AdventureWorks.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

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
            IRepository<Product> repo = factory.GetProductAccess();
            return repo.GetAll();
        }

        public Product GetProductById(int id)
        {
            IRepository<Product> repo = factory.GetProductAccess();
            return repo.GetById(id);
        }

        public int InsertProduct(Product product)
        {
            IRepository<Product> repo = factory.GetProductAccess();
            return repo.Insert(product);
        }

        public int UpdateProduct(Product product)
        {
            IRepository<Product> repo = factory.GetProductAccess();
            return repo.Update(product);
        }

        public int DeleteProduct(Product product)
        {
            IRepository<Product> repo = factory.GetProductAccess();
            return repo.Delete(product);
        }
    }
}

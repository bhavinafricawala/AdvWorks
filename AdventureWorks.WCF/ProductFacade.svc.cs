using AdventureWorks.Business.Product;
using AdventureWorks.Data;
using AdventureWorks.Data.Interfaces;
using AdventureWorks.Data.Other;
using AdventureWorks.Data.ProductData;
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
        IConnection db = new DbConnection();
        ILogs log = new Logs();
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
            return new ProductAccess(db, log).GetAll();
        }

        public Product GetProductById(int id)
        {
            return new ProductAccess(db, log).GetById(id);
        }

        public int InsertProduct(Product product)
        {
            return new ProductAccess(db, log).Insert(product);
        }

        public int UpdateProduct(Product product)
        {
            return new ProductAccess(db, log).Update(product);
        }

        public int DeleteProduct(Product product)
        {
            return new ProductAccess(db, log).Delete(product);
        }
    }
}

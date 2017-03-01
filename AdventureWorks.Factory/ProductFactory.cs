using AdventureWorks.Business.Product;
using AdventureWorks.Data;
using AdventureWorks.Data.Interfaces;
using AdventureWorks.Data.Other;
using AdventureWorks.Data.ProductData;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Factory
{
    public static class ProductFactory
    {
        private static Container container = new Container();

        static ProductFactory()
        {
            container.Register<IConnection, DbConnection>(Lifestyle.Singleton);
            container.Register<ILogs, Logs>(Lifestyle.Singleton);
            //container.Register<IRepository<Product>>((factory) => new ProductAccess(container.GetInstance<IConnection>(),
            //    container.GetInstance<ILogs>()));   
        }

        public static IRepository<Product> GetProductAccess()
        {
            IRepository<Product> product=(ProductAccess)container.GetInstance(typeof(IRepository<Product>));

            return product;
        }
    }
}

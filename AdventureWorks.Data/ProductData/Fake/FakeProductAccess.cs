using AdventureWorks.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using AdventureWorks.Business.Product;

namespace AdventureWorks.Data.ProductData.Fake
{
    public class FakeProductAccess : IProductAccess
    {
        private readonly IDbConnection _db;
        public FakeProductAccess(IConnection db)
        {
            _db = db.GetConnection();
        }

        public int DeleteProduct(Product product)
        {
            return 1;
        }

        public IList<Product> GetAllProducts()
        {
            return new List<Product>();
        }

        public Product GetProductById(int productId)
        {
            return new Product();
        }

        public int InsertProduct(Product product)
        {
            return 1;
        }

        public int UpdateProduct(Product product)
        {
            return 1;
        }
    }
}

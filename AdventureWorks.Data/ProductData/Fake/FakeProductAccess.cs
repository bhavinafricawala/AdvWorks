using AdventureWorks.Data.Interfaces;
using System.Collections.Generic;
using System.Data;
using AdventureWorks.Business.Product;

namespace AdventureWorks.Data.ProductData.Fake
{
    public class FakeProductAccess : IRepository<Product>
    {
        private readonly IDbConnection _db;
        private readonly ILogs _log;
        public FakeProductAccess(IConnection db, ILogs log)
        {
            _db = db.GetConnection();
            _log = log;
        }

        public int Delete(Product product)
        {
            return 1;
        }

        public IList<Product> GetAll()
        {
            return new List<Product>();
        }

        public Product GetById(int productId)
        {
            return new Product();
        }

        public int Insert(Product product)
        {
            return 1;
        }

        public int Update(Product product)
        {
            return 1;
        }
    }
}

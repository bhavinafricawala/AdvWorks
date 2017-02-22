using AdventureWorks.Business.Product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using AdventureWorks.Data.Interfaces;
// aaaa

namespace AdventureWorks.Data.ProductData
{
    public class ProductAccess : IRepository<Product>
    {
        private readonly IDbConnection _db;
        private readonly ILogs _log;

        public ProductAccess(IConnection db, ILogs log)
        {
            _db = db.GetConnection();
            _log = log;
        }
        public IList<Product> GetAll()
        {
            try
            {
                string query = "[dbo].[sp_Get_All_Products]";

                return _db.Query<Product>(query).ToList();
            }
            catch (Exception ex)
            {
                _log.Handle(ex);
                return new List<Product>();
            }
        }

        public Product GetById(int productId)
        {
            try
            {

                string query = "[dbo].[sp_Get_Product_By_ID] @ProductID";

                return _db.Query<Product>(query, new { ProductID = productId }).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _log.Handle(ex);
                return new Product();
            }
        }

        public int Insert(Product product)
        {
            try
            {
                string query = "[dbo].[sp_Insert_Product] @Name, @ProductNumber, @MakeFlag, @FinishedGoodsFlag,@Color," +
                        "@SafetyStockLevel,@ReorderPoint,@StandardCost,@ListPrice,@Size";

                return _db.Execute(query, product);
            }
            catch (Exception ex)
            {
                _log.Handle(ex);
                return -1;
            }
        }

        public int Update(Product product)
        {
            try
            {
                string query = "[dbo].[sp_Update_Product] @ProductID, @Name, @ProductNumber, @MakeFlag, @FinishedGoodsFlag,@Color," +
                        "@SafetyStockLevel,@ReorderPoint,@StandardCost,@ListPrice,@Size";

                return _db.Execute(query, product);
            }
            catch (Exception ex)
            {
                _log.Handle(ex);
                return -1;
            }
        }

        public int Delete(Product product)
        {
            try
            {
                string query = "[dbo].[sp_Delete_Product] @ProductID";

                return _db.Execute(query, product);
            }
            catch (Exception ex)
            {
                _log.Handle(ex);
                return -1;
            }
        }
    }
}

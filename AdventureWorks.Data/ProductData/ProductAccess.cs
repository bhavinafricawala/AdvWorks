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
    public class ProductAccess : IProductAccess
    {
        private readonly IDbConnection _db;
        public ProductAccess(IConnection db)
        {
            _db = db.GetConnection();
        }
        public IList<Product> GetAllProducts()
        {
            string query = "[dbo].[sp_Get_All_Products]";

            return _db.Query<Product>(query).ToList();
        }

        public Product GetProductById(int productId)
        {
            string query = "[dbo].[sp_Get_Product_By_ID] @ProductID";

            return _db.Query<Product>(query, new { ProductID = productId }).SingleOrDefault();
        }

        public int InsertProduct(Product product)
        {
            string query = "[dbo].[sp_Insert_Product] @Name, @ProductNumber, @MakeFlag, @FinishedGoodsFlag,@Color," +
                        "@SafetyStockLevel,@ReorderPoint,@StandardCost,@ListPrice,@Size";

            return _db.Execute(query, product);
        }

        public int UpdateProduct(Product product)
        {
                string query = "[dbo].[sp_Update_Product] @ProductID, @Name, @ProductNumber, @MakeFlag, @FinishedGoodsFlag,@Color," +
                            "@SafetyStockLevel,@ReorderPoint,@StandardCost,@ListPrice,@Size";

                return _db.Execute(query, product);
        }

        public int DeleteProduct(Product product)
        {
                string query = "[dbo].[sp_Delete_Product] @ProductID";

                return _db.Execute(query, product);
        }
    }
}

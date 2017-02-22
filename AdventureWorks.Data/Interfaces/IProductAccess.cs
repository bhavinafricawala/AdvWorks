using AdventureWorks.Business.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Interfaces
{
    public interface IProductAccess
    {
        IList<Product> GetAllProducts();

        Product GetProductById(int productId);

        int InsertProduct(Product product);

        int UpdateProduct(Product product);

        int DeleteProduct(Product product);

    }
}

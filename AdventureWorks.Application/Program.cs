using AdventureWorks.Business.Product;
using AdventureWorks.Data;
using AdventureWorks.Data.ProductData;
using AdventureWorks.Data.ProductData.Fake;
using System;
using System.Collections.Generic;

namespace AdventureWorks.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            Console.WriteLine("Enter Product Name");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter Product Number");
            product.ProductNumber = Console.ReadLine();
            Console.WriteLine("Enter Product Color");
            product.Color = Console.ReadLine();
            Console.WriteLine("Enter Product List Price");
            product.ListPrice = decimal.Parse(Console.ReadLine());

            new FakeProductAccess(new DbConnection()).InsertProduct(product);
            new ProductAccess(new DbConnection()).InsertProduct(product);

            Console.WriteLine("");
            Console.WriteLine("");

            IList<Product> products = new ProductAccess(new DbConnection()).GetAllProducts();
            
            foreach (Product p in products)
            {
                Console.WriteLine("Product Name         : " + p.Name);
                Console.WriteLine("Product Number       : " + p.ProductNumber);
                Console.WriteLine("Product Color        : " + p.Color);
                Console.WriteLine("Product List Price   : " + p.ListPrice.ToString());
                Console.WriteLine("__________________________________________________");
            }

            Console.ReadLine();
        }
    }
}

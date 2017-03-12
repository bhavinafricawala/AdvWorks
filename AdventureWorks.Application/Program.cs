using AdventureWorks.Entities.Product;
using AdventureWorks.Data;
using AdventureWorks.Data.Interfaces;
using AdventureWorks.Data.Other;
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

            ILogs log = new Logs();
            DbConnection db = new DbConnection();

            new FakeProductAccess(db, log).Insert(product);
            new ProductAccess(db,log).Insert(product);

            Console.WriteLine("");
            Console.WriteLine("");

            IList<Product> products = new ProductAccess(db, log).GetAll();
            
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

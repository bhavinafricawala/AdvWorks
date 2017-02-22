namespace AdventureWorks.Business.Product
{
    public class Product
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string ProductNumber { get; set; }

        public bool MakeFlag { get; set; }

        public bool FinishedGoodsFlag { get; set; }

        public string Color { get; set; }

        public int SafetyStockLevel { get; set; }

        public int ReorderPoint { get; set; }

        public decimal StandardCost { get; set; }

        public decimal ListPrice { get; set; }

        public string Size { get; set; }
    }
}

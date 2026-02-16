using Linq_ASSIGMENT_1_.Models;

namespace Linq_ASSIGMENT_1_
{
    public static class ListGenerators
    {
        public static List<Product> GetProductList()
        {
            return new List<Product>
            {
                new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 39 },
                new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
                new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 },
                new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.0000M, UnitsInStock = 53 },
                new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments", UnitPrice = 21.3500M, UnitsInStock = 0 },
                new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25.0000M, UnitsInStock = 120 },
                new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce", UnitPrice = 30.0000M, UnitsInStock = 15 },
                new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", Category = "Condiments", UnitPrice = 40.0000M, UnitsInStock = 6 },
                new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97.0000M, UnitsInStock = 29 },
                new Product { ProductID = 10, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.0000M, UnitsInStock = 31 },
                new Product { ProductID = 11, ProductName = "Queso Cabrales", Category = "Dairy Products", UnitPrice = 21.0000M, UnitsInStock = 22 },
                new Product { ProductID = 12, ProductName = "Queso Manchego La Pastora", Category = "Dairy Products", UnitPrice = 38.0000M, UnitsInStock = 86 },
                new Product { ProductID = 13, ProductName = "Konbu", Category = "Seafood", UnitPrice = 6.0000M, UnitsInStock = 24 },
                new Product { ProductID = 14, ProductName = "Tofu", Category = "Produce", UnitPrice = 23.2500M, UnitsInStock = 35 },
                new Product { ProductID = 15, ProductName = "Genen Shouyu", Category = "Condiments", UnitPrice = 15.5000M, UnitsInStock = 39 },
                new Product { ProductID = 16, ProductName = "Pavlova", Category = "Confections", UnitPrice = 17.4500M, UnitsInStock = 29 },
                new Product { ProductID = 17, ProductName = "Alice Mutton", Category = "Meat/Poultry", UnitPrice = 39.0000M, UnitsInStock = 0 },
                new Product { ProductID = 18, ProductName = "Carnarvon Tigers", Category = "Seafood", UnitPrice = 62.5000M, UnitsInStock = 42 },
                new Product { ProductID = 19, ProductName = "Teatime Chocolate Biscuits", Category = "Confections", UnitPrice = 9.2000M, UnitsInStock = 25 },
                new Product { ProductID = 20, ProductName = "Sir Rodney's Marmalade", Category = "Confections", UnitPrice = 81.0000M, UnitsInStock = 40 },
                new Product { ProductID = 21, ProductName = "Sir Rodney's Scones", Category = "Confections", UnitPrice = 10.0000M, UnitsInStock = 3 },
                new Product { ProductID = 22, ProductName = "Gustaf's Knäckebröd", Category = "Grains/Cereals", UnitPrice = 21.0000M, UnitsInStock = 104 },
                new Product { ProductID = 23, ProductName = "Tunnbröd", Category = "Grains/Cereals", UnitPrice = 9.0000M, UnitsInStock = 61 },
                new Product { ProductID = 24, ProductName = "Guaraná Fantástica", Category = "Beverages", UnitPrice = 4.5000M, UnitsInStock = 20 },
                new Product { ProductID = 25, ProductName = "NuNuCa Nuß-Nougat-Creme", Category = "Confections", UnitPrice = 14.0000M, UnitsInStock = 76 },
                new Product { ProductID = 26, ProductName = "Gumbär Gummibärchen", Category = "Confections", UnitPrice = 31.2300M, UnitsInStock = 15 },
                new Product { ProductID = 27, ProductName = "Schoggi Schokolade", Category = "Confections", UnitPrice = 43.9000M, UnitsInStock = 49 },
                new Product { ProductID = 28, ProductName = "Rössle Sauerkraut", Category = "Produce", UnitPrice = 45.6000M, UnitsInStock = 26 },
                new Product { ProductID = 29, ProductName = "Thüringer Rostbratwurst", Category = "Meat/Poultry", UnitPrice = 123.7900M, UnitsInStock = 0 },
                new Product { ProductID = 30, ProductName = "Nord-Ost Matjeshering", Category = "Seafood", UnitPrice = 25.8900M, UnitsInStock = 10 }
            };
        }

        public static List<Customer> GetCustomerList()
        {
            return new List<Customer>
            {
                new Customer 
                { 
                    CustomerID = "ALFKI", 
                    CompanyName = "Alfreds Futterkiste", 
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10643, OrderDate = new DateTime(1997, 8, 25), Total = 814.50M },
                        new Order { OrderID = 10692, OrderDate = new DateTime(1997, 10, 3), Total = 878.00M },
                        new Order { OrderID = 10702, OrderDate = new DateTime(1997, 10, 13), Total = 330.00M }
                    }
                },
                new Customer 
                { 
                    CustomerID = "ANATR", 
                    CompanyName = "Ana Trujillo Emparedados y helados", 
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10308, OrderDate = new DateTime(1996, 9, 18), Total = 88.80M },
                        new Order { OrderID = 10625, OrderDate = new DateTime(1997, 8, 8), Total = 479.75M }
                    }
                },
                new Customer 
                { 
                    CustomerID = "ANTON", 
                    CompanyName = "Antonio Moreno Taquería", 
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10365, OrderDate = new DateTime(1996, 11, 27), Total = 403.20M },
                        new Order { OrderID = 10507, OrderDate = new DateTime(1997, 4, 15), Total = 749.06M },
                        new Order { OrderID = 10535, OrderDate = new DateTime(1997, 5, 13), Total = 1940.85M },
                        new Order { OrderID = 10573, OrderDate = new DateTime(1997, 6, 19), Total = 2082.00M },
                        new Order { OrderID = 10677, OrderDate = new DateTime(1997, 9, 22), Total = 813.37M },
                        new Order { OrderID = 10682, OrderDate = new DateTime(1997, 9, 25), Total = 375.50M },
                        new Order { OrderID = 10856, OrderDate = new DateTime(1998, 1, 28), Total = 1267.50M }
                    }
                },
                new Customer 
                { 
                    CustomerID = "AROUT", 
                    CompanyName = "Around the Horn", 
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10355, OrderDate = new DateTime(1996, 11, 15), Total = 480.00M },
                        new Order { OrderID = 10383, OrderDate = new DateTime(1996, 12, 16), Total = 899.00M },
                        new Order { OrderID = 10453, OrderDate = new DateTime(1997, 2, 21), Total = 407.70M },
                        new Order { OrderID = 10558, OrderDate = new DateTime(1997, 6, 4), Total = 320.00M },
                        new Order { OrderID = 10707, OrderDate = new DateTime(1997, 10, 16), Total = 1641.00M },
                        new Order { OrderID = 10741, OrderDate = new DateTime(1997, 11, 14), Total = 228.00M },
                        new Order { OrderID = 10743, OrderDate = new DateTime(1997, 11, 17), Total = 319.20M },
                        new Order { OrderID = 10768, OrderDate = new DateTime(1997, 12, 8), Total = 1477.00M },
                        new Order { OrderID = 10793, OrderDate = new DateTime(1997, 12, 24), Total = 191.10M },
                        new Order { OrderID = 10864, OrderDate = new DateTime(1998, 2, 2), Total = 282.00M },
                        new Order { OrderID = 10920, OrderDate = new DateTime(1998, 3, 3), Total = 390.00M },
                        new Order { OrderID = 10953, OrderDate = new DateTime(1998, 3, 16), Total = 4441.25M }
                    }
                },
                new Customer 
                { 
                    CustomerID = "BERGS", 
                    CompanyName = "Berglunds snabbköp", 
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10278, OrderDate = new DateTime(1996, 8, 12), Total = 1488.80M },
                        new Order { OrderID = 10280, OrderDate = new DateTime(1996, 8, 14), Total = 613.20M },
                        new Order { OrderID = 10384, OrderDate = new DateTime(1996, 12, 16), Total = 2222.40M },
                        new Order { OrderID = 10444, OrderDate = new DateTime(1997, 2, 12), Total = 1031.70M },
                        new Order { OrderID = 10445, OrderDate = new DateTime(1997, 2, 13), Total = 174.90M },
                        new Order { OrderID = 10524, OrderDate = new DateTime(1997, 5, 1), Total = 3192.65M },
                        new Order { OrderID = 10572, OrderDate = new DateTime(1997, 6, 18), Total = 1501.08M },
                        new Order { OrderID = 10626, OrderDate = new DateTime(1997, 8, 11), Total = 1503.60M },
                        new Order { OrderID = 10654, OrderDate = new DateTime(1997, 9, 2), Total = 601.83M },
                        new Order { OrderID = 10672, OrderDate = new DateTime(1997, 9, 17), Total = 3815.25M },
                        new Order { OrderID = 10689, OrderDate = new DateTime(1997, 10, 1), Total = 472.50M },
                        new Order { OrderID = 10721, OrderDate = new DateTime(1997, 10, 29), Total = 923.87M },
                        new Order { OrderID = 10795, OrderDate = new DateTime(1997, 12, 24), Total = 2158.00M },
                        new Order { OrderID = 10837, OrderDate = new DateTime(1998, 1, 16), Total = 1064.00M },
                        new Order { OrderID = 10857, OrderDate = new DateTime(1998, 1, 28), Total = 2048.21M },
                        new Order { OrderID = 10866, OrderDate = new DateTime(1998, 2, 3), Total = 1096.20M },
                        new Order { OrderID = 10875, OrderDate = new DateTime(1998, 2, 6), Total = 709.55M },
                        new Order { OrderID = 10924, OrderDate = new DateTime(1998, 3, 4), Total = 1835.70M }
                    }
                }
            };
        }
    }
}

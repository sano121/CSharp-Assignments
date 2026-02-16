namespace assigment_2
{
    public static class DataSource
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00m, UnitsInStock = 39 },
                new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.00m, UnitsInStock = 17 },
                new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.00m, UnitsInStock = 13 },
                new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.00m, UnitsInStock = 53 },
                new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments", UnitPrice = 21.35m, UnitsInStock = 0 },
                new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25.00m, UnitsInStock = 120 },
                new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce", UnitPrice = 30.00m, UnitsInStock = 15 },
                new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", Category = "Condiments", UnitPrice = 40.00m, UnitsInStock = 6 },
                new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97.00m, UnitsInStock = 29 },
                new Product { ProductID = 10, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.00m, UnitsInStock = 31 },
                new Product { ProductID = 11, ProductName = "Queso Cabrales", Category = "Dairy Products", UnitPrice = 21.00m, UnitsInStock = 22 },
                new Product { ProductID = 12, ProductName = "Queso Manchego La Pastora", Category = "Dairy Products", UnitPrice = 38.00m, UnitsInStock = 0 },
                new Product { ProductID = 13, ProductName = "Konbu", Category = "Seafood", UnitPrice = 6.00m, UnitsInStock = 24 },
                new Product { ProductID = 14, ProductName = "Tofu", Category = "Produce", UnitPrice = 23.25m, UnitsInStock = 35 },
                new Product { ProductID = 15, ProductName = "Genen Shouyu", Category = "Condiments", UnitPrice = 15.50m, UnitsInStock = 39 }
            };
        }

        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer 
                { 
                    CustomerID = "ALFKI", 
                    CompanyName = "Alfreds Futterkiste", 
                    Region = "Berlin",
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10643, OrderDate = new DateTime(2023, 8, 25), Total = 814.50m },
                        new Order { OrderID = 10692, OrderDate = new DateTime(2023, 10, 3), Total = 878.00m },
                        new Order { OrderID = 10702, OrderDate = new DateTime(2023, 10, 13), Total = 330.00m }
                    }
                },
                new Customer 
                { 
                    CustomerID = "ANATR", 
                    CompanyName = "Ana Trujillo Emparedados y helados", 
                    Region = "Mexico",
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10308, OrderDate = new DateTime(2023, 9, 18), Total = 88.80m },
                        new Order { OrderID = 10625, OrderDate = new DateTime(2023, 8, 8), Total = 479.75m }
                    }
                },
                new Customer 
                { 
                    CustomerID = "ANTON", 
                    CompanyName = "Antonio Moreno Taquería", 
                    Region = "Mexico",
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10365, OrderDate = new DateTime(2023, 11, 27), Total = 403.20m },
                        new Order { OrderID = 10507, OrderDate = new DateTime(2023, 4, 15), Total = 749.06m }
                    }
                },
                new Customer 
                { 
                    CustomerID = "LAZYK", 
                    CompanyName = "Lazy K Kountry Store", 
                    Region = "WA",
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10482, OrderDate = new DateTime(2023, 3, 21), Total = 147.00m },
                        new Order { OrderID = 10545, OrderDate = new DateTime(2023, 5, 22), Total = 210.00m },
                        new Order { OrderID = 10574, OrderDate = new DateTime(2023, 6, 19), Total = 764.30m },
                        new Order { OrderID = 10577, OrderDate = new DateTime(2023, 6, 23), Total = 569.00m }
                    }
                },
                new Customer 
                { 
                    CustomerID = "TRAIH", 
                    CompanyName = "Trail's Head Gourmet Provisioners", 
                    Region = "WA",
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10574, OrderDate = new DateTime(2023, 6, 19), Total = 764.30m },
                        new Order { OrderID = 10577, OrderDate = new DateTime(2023, 6, 23), Total = 569.00m },
                        new Order { OrderID = 10822, OrderDate = new DateTime(2023, 1, 8), Total = 237.90m },
                        new Order { OrderID = 10952, OrderDate = new DateTime(2023, 3, 16), Total = 471.20m }
                    }
                },
                new Customer 
                { 
                    CustomerID = "WHITC", 
                    CompanyName = "White Clover Markets", 
                    Region = "WA",
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10269, OrderDate = new DateTime(2023, 7, 31), Total = 642.20m },
                        new Order { OrderID = 10344, OrderDate = new DateTime(2023, 11, 1), Total = 2296.00m },
                        new Order { OrderID = 10469, OrderDate = new DateTime(2023, 3, 10), Total = 1125.00m },
                        new Order { OrderID = 10483, OrderDate = new DateTime(2023, 3, 24), Total = 668.00m }
                    }
                }
            };
        }
    }
}

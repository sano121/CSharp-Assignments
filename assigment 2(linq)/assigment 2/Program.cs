namespace assigment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = DataSource.GetProducts();
            var customers = DataSource.GetCustomers();

            Console.WriteLine("=== LINQ - SET OPERATORS ===\n");
            SetOperators(products, customers);

            Console.WriteLine("\n=== LINQ - PARTITIONING OPERATORS ===\n");
            PartitioningOperators(customers);

            Console.WriteLine("\n=== LINQ - QUANTIFIERS ===\n");
            Quantifiers(products);

            Console.WriteLine("\n=== LINQ - GROUPING OPERATORS ===\n");
            GroupingOperators();
        }

        static void SetOperators(List<Product> products, List<Customer> customers)
        {
            Console.WriteLine("1. Unique Category Names:");
            var uniqueCategories = products.Select(p => p.Category).Distinct();
            foreach (var category in uniqueCategories)
            {
                Console.WriteLine($"   {category}");
            }

            Console.WriteLine("\n2. Unique first letters from both Product and Customer names:");
            var productFirstLetters = products.Select(p => p.ProductName[0]);
            var customerFirstLetters = customers.Select(c => c.CompanyName[0]);
            var uniqueFirstLetters = productFirstLetters.Union(customerFirstLetters).OrderBy(c => c);
            Console.WriteLine($"   {string.Join(", ", uniqueFirstLetters)}");

            Console.WriteLine("\n3. Common first letters from both Product and Customer names:");
            var commonFirstLetters = productFirstLetters.Intersect(customerFirstLetters).OrderBy(c => c);
            Console.WriteLine($"   {string.Join(", ", commonFirstLetters)}");

            Console.WriteLine("\n4. First letters of Products NOT in Customer names:");
            var productOnlyLetters = productFirstLetters.Except(customerFirstLetters).Distinct().OrderBy(c => c);
            Console.WriteLine($"   {string.Join(", ", productOnlyLetters)}");

            Console.WriteLine("\n5. Last three characters of all Product and Customer names (with duplicates):");
            var productLastThree = products.Select(p => p.ProductName.Length >= 3 ? p.ProductName.Substring(p.ProductName.Length - 3) : p.ProductName);
            var customerLastThree = customers.Select(c => c.CompanyName.Length >= 3 ? c.CompanyName.Substring(c.CompanyName.Length - 3) : c.CompanyName);
            var allLastThree = productLastThree.Concat(customerLastThree);
            foreach (var last3 in allLastThree)
            {
                Console.WriteLine($"   {last3}");
            }
        }

        static void PartitioningOperators(List<Customer> customers)
        {
            Console.WriteLine("1. First 3 orders from customers in Washington:");
            var first3Orders = customers
                .Where(c => c.Region == "WA")
                .SelectMany(c => c.Orders)
                .Take(3);
            foreach (var order in first3Orders)
            {
                Console.WriteLine($"   OrderID: {order.OrderID}, Date: {order.OrderDate:yyyy-MM-dd}, Total: ${order.Total}");
            }

            Console.WriteLine("\n2. All but first 2 orders from customers in Washington:");
            var skipFirst2Orders = customers
                .Where(c => c.Region == "WA")
                .SelectMany(c => c.Orders)
                .Skip(2);
            foreach (var order in skipFirst2Orders)
            {
                Console.WriteLine($"   OrderID: {order.OrderID}, Date: {order.OrderDate:yyyy-MM-dd}, Total: ${order.Total}");
            }

            Console.WriteLine("\n3. Elements from beginning until number < position:");
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var takeWhileResult = numbers.TakeWhile((n, index) => n >= index);
            Console.WriteLine($"   {string.Join(", ", takeWhileResult)}");

            Console.WriteLine("\n4. Elements starting from first element divisible by 3:");
            int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var skipUntilDiv3 = numbers2.SkipWhile(n => n % 3 != 0);
            Console.WriteLine($"   {string.Join(", ", skipUntilDiv3)}");

            Console.WriteLine("\n5. Elements starting from first element less than its position:");
            int[] numbers3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var skipUntilLess = numbers3.SkipWhile((n, index) => n >= index);
            Console.WriteLine($"   {string.Join(", ", skipUntilLess)}");
        }

        static void Quantifiers(List<Product> products)
        {
            Console.WriteLine("1. Check if dictionary contains words with 'ei':");
            string dictionaryPath = "dictionary_english.txt";
            
            if (File.Exists(dictionaryPath))
            {
                string[] words = File.ReadAllLines(dictionaryPath);
                bool hasEI = words.Any(w => w.Contains("ei", StringComparison.OrdinalIgnoreCase));
                Console.WriteLine($"   Dictionary contains words with 'ei': {hasEI}");
                
                var exampleWords = words.Where(w => w.Contains("ei", StringComparison.OrdinalIgnoreCase)).Take(5);
                Console.WriteLine($"   Examples: {string.Join(", ", exampleWords)}");
            }
            else
            {
                Console.WriteLine($"   Dictionary file not found. Creating sample...");
                string[] sampleWords = { "receive", "deceive", "either", "neither", "their", "weird", "ceiling", "protein", "seize" };
                File.WriteAllLines(dictionaryPath, sampleWords);
                bool hasEI = sampleWords.Any(w => w.Contains("ei", StringComparison.OrdinalIgnoreCase));
                Console.WriteLine($"   Sample dictionary contains words with 'ei': {hasEI}");
                Console.WriteLine($"   Examples: {string.Join(", ", sampleWords.Take(5))}");
            }

            Console.WriteLine("\n2. Categories with at least one product out of stock:");
            var categoriesWithOutOfStock = products
                .GroupBy(p => p.Category)
                .Where(g => g.Any(p => p.UnitsInStock == 0))
                .Select(g => new { Category = g.Key, Products = g.ToList() });
            
            foreach (var group in categoriesWithOutOfStock)
            {
                Console.WriteLine($"   Category: {group.Category}");
                foreach (var product in group.Products)
                {
                    Console.WriteLine($"      - {product.ProductName} (Stock: {product.UnitsInStock})");
                }
            }

            Console.WriteLine("\n3. Categories with all products in stock:");
            var categoriesAllInStock = products
                .GroupBy(p => p.Category)
                .Where(g => g.All(p => p.UnitsInStock > 0))
                .Select(g => new { Category = g.Key, Products = g.ToList() });
            
            foreach (var group in categoriesAllInStock)
            {
                Console.WriteLine($"   Category: {group.Category}");
                foreach (var product in group.Products)
                {
                    Console.WriteLine($"      - {product.ProductName} (Stock: {product.UnitsInStock})");
                }
            }
        }

        static void GroupingOperators()
        {
            Console.WriteLine("1. Numbers grouped by remainder when divided by 5:");
            List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var groupedByRemainder = numbers.GroupBy(n => n % 5);
            
            foreach (var group in groupedByRemainder.OrderBy(g => g.Key))
            {
                Console.WriteLine($"   Numbers with remainder {group.Key} when divided by 5:");
                Console.WriteLine($"      {string.Join(", ", group)}");
            }

            Console.WriteLine("\n2. Words grouped by first letter:");
            string dictionaryPath = "dictionary_english.txt";
            
            if (File.Exists(dictionaryPath))
            {
                string[] words = File.ReadAllLines(dictionaryPath);
                var groupedByFirstLetter = words
                    .Where(w => !string.IsNullOrWhiteSpace(w))
                    .GroupBy(w => w[0])
                    .OrderBy(g => g.Key)
                    .Take(5); 
                
                foreach (var group in groupedByFirstLetter)
                {
                    Console.WriteLine($"   Words starting with '{group.Key}':");
                    Console.WriteLine($"      {string.Join(", ", group.Take(10))}..."); 
                }
            }
            else
            {
                Console.WriteLine("   Using sample words...");
                string[] sampleWords = { "apple", "apricot", "banana", "blueberry", "cherry", "cranberry" };
                var groupedByFirstLetter = sampleWords.GroupBy(w => w[0]).OrderBy(g => g.Key);
                
                foreach (var group in groupedByFirstLetter)
                {
                    Console.WriteLine($"   Words starting with '{group.Key}':");
                    Console.WriteLine($"      {string.Join(", ", group)}");
                }
            }

            Console.WriteLine("\n3. Words grouped by anagram (same characters):");
            string[] arr = { "from", "salt", "earn", "last", "near", "form" };
            var groupedByAnagram = arr.GroupBy(w => w, new AnagramEqualityComparer());
            
            foreach (var group in groupedByAnagram)
            {
                Console.WriteLine($"   Anagram group: {string.Join(", ", group)}");
            }
        }
    }
}

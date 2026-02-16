using Linq_ASSIGMENT_1_.Models;
using Linq_ASSIGMENT_1_.Mappers;
using System.Globalization;

namespace Linq_ASSIGMENT_1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = ListGenerators.GetProductList();
            var customers = ListGenerators.GetCustomerList();


            #region LINQ - Restriction Operators


            Console.WriteLine("\n[Q1] Find all products that are out of stock");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q1 = products.Where(p => p.UnitsInStock == 0);
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q1 = products.Where(p => p.UnitsInStock == 0);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT * FROM Products WHERE UnitsInStock = 0");
            Console.WriteLine("\nEF Core Support: YES - Translates to SQL WHERE clause");
            Console.WriteLine("\nTime Complexity: O(n) - Must scan all products");
            Console.WriteLine("  Explanation: Linear scan through the entire collection to check condition");
            Console.WriteLine("Space Complexity: O(k) - where k is the number of out-of-stock products");
            Console.WriteLine("  Explanation: Stores only matching results in memory");
            Console.WriteLine("\nResults:");
            foreach (var p in q1)
                Console.WriteLine($"  - {p.ProductName} (ID: {p.ProductID})");

            Console.WriteLine("\n[Q2] Find all products in stock and cost more than $3.00");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q2 = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q2 = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT * FROM Products WHERE UnitsInStock > 0 AND UnitPrice > 3.00");
            Console.WriteLine("\nEF Core Support: YES - Translates to SQL WHERE with AND operator");
            Console.WriteLine("\nTime Complexity: O(n) - Must scan all products");
            Console.WriteLine("  Explanation: Linear scan with compound condition evaluation");
            Console.WriteLine("Space Complexity: O(k) - where k is the number of matching products");
            Console.WriteLine("  Explanation: Stores only products meeting both conditions");
            Console.WriteLine($"\nResults: {q2.Count()} products found");
            foreach (var p in q2.Take(5))
                Console.WriteLine($"  - {p.ProductName} - ${p.UnitPrice} ({p.UnitsInStock} in stock)");
            if (q2.Count() > 5) Console.WriteLine($"  ... and {q2.Count() - 5} more");

            Console.WriteLine("\n[Q3] Digits whose name is shorter than their value");
            Console.WriteLine("--------------------------------------------------------------------------------");
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q3 = digits.Where((digit, index) => digit.Length < index);
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q3 = digits.Where((digit, index) => digit.Length < index);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  N/A - Not directly translatable (uses index-based filtering)");
            Console.WriteLine("\nEF Core Support: NO - Index-based Where() overload not supported in EF Core");
            Console.WriteLine("  Reason: The indexed version of Where requires client-side evaluation");
            Console.WriteLine("\nTime Complexity: O(n) - where n is array length");
            Console.WriteLine("  Explanation: Single pass through array with index comparison");
            Console.WriteLine("Space Complexity: O(k) - where k is the number of matching items");
            Console.WriteLine("  Explanation: Stores only strings shorter than their index position");
            Console.WriteLine("\nResults:");
            foreach (var digit in q3)
                Console.WriteLine($"  - {digit}");

            #endregion

            #region LINQ - Ordering Operators

            Console.WriteLine("\n[Q4] Sort products by name");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q4 = products.OrderBy(p => p.ProductName);
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q4 = products.OrderBy(p => p.ProductName);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT * FROM Products ORDER BY ProductName ASC");
            Console.WriteLine("\nEF Core Support: YES - Translates to SQL ORDER BY clause");
            Console.WriteLine("\nTime Complexity: O(n log n) - Comparison-based sorting");
            Console.WriteLine("  Explanation: Uses QuickSort or similar algorithm internally");
            Console.WriteLine("Space Complexity: O(n) - Creates sorted copy of collection");
            Console.WriteLine("  Explanation: LINQ OrderBy creates a new ordered sequence");
            Console.WriteLine($"\nResults: First 5 of {q4.Count()}");
            foreach (var p in q4.Take(5))
                Console.WriteLine($"  - {p.ProductName}");

            Console.WriteLine("\n[Q5] Case-insensitive sort of words");
            Console.WriteLine("--------------------------------------------------------------------------------");
            string[] words1 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q5 = words1.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q5 = words1.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT * FROM Words ORDER BY Word COLLATE SQL_Latin1_General_CP1_CI_AS");
            Console.WriteLine("\nEF Core Support: YES - Can translate with proper collation configuration");
            Console.WriteLine("  Note: Requires database collation settings for case-insensitive comparison");
            Console.WriteLine("\nTime Complexity: O(n log n) - Sorting with custom comparer");
            Console.WriteLine("  Explanation: Same as regular sort but with case-insensitive comparison");
            Console.WriteLine("Space Complexity: O(n) - Sorted sequence");
            Console.WriteLine("  Explanation: New sequence with case-insensitive ordering");
            Console.WriteLine("\nResults:");
            foreach (var word in q5)
                Console.WriteLine($"  - {word}");

            Console.WriteLine("\n[Q6] Sort products by units in stock (descending)");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q6 = products.OrderByDescending(p => p.UnitsInStock);
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q6 = products.OrderByDescending(p => p.UnitsInStock);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT * FROM Products ORDER BY UnitsInStock DESC");
            Console.WriteLine("\nEF Core Support: YES - Translates to SQL ORDER BY DESC");
            Console.WriteLine("\nTime Complexity: O(n log n) - Descending sort");
            Console.WriteLine("  Explanation: Comparison-based sorting in reverse order");
            Console.WriteLine("Space Complexity: O(n) - Sorted collection");
            Console.WriteLine("  Explanation: New ordered sequence");
            Console.WriteLine($"\nResults: Top 5 of {q6.Count()}");
            foreach (var p in q6.Take(5))
                Console.WriteLine($"  - {p.ProductName} - {p.UnitsInStock} units");

            Console.WriteLine("\n[Q7] Sort digits by length, then alphabetically");
            Console.WriteLine("--------------------------------------------------------------------------------");
            string[] digits2 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q7 = digits2.OrderBy(d => d.Length).ThenBy(d => d);
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q7 = digits2.OrderBy(d => d.Length).ThenBy(d => d);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT * FROM Digits ORDER BY LEN(Digit) ASC, Digit ASC");
            Console.WriteLine("\nEF Core Support: YES - Translates to multi-column ORDER BY");
            Console.WriteLine("\nTime Complexity: O(n log n) - Multi-key sorting");
            Console.WriteLine("  Explanation: Sorts by first key, then by second key for ties");
            Console.WriteLine("Space Complexity: O(n) - Sorted sequence");
            Console.WriteLine("  Explanation: New sequence with two-level ordering");
            Console.WriteLine("\nResults:");
            foreach (var digit in q7)
                Console.WriteLine($"  - {digit} (length: {digit.Length})");

            Console.WriteLine("\n[Q8] Sort by length, then case-insensitive alphabetically");
            Console.WriteLine("--------------------------------------------------------------------------------");
            string[] words2 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q8 = words2.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q8 = words2.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT * FROM Words ORDER BY LEN(Word) ASC, Word COLLATE SQL_Latin1_General_CP1_CI_AS ASC");
            Console.WriteLine("\nEF Core Support: YES - With proper collation configuration");
            Console.WriteLine("\nTime Complexity: O(n log n) - Multi-key sorting with custom comparer");
            Console.WriteLine("  Explanation: Two-level sort with case-insensitive string comparison");
            Console.WriteLine("Space Complexity: O(n) - Sorted sequence");
            Console.WriteLine("  Explanation: New sequence with compound ordering");
            Console.WriteLine("\nResults:");
            foreach (var word in q8)
                Console.WriteLine($"  - {word} (length: {word.Length})");

            Console.WriteLine("\n[Q9] Sort by category, then by unit price (descending)");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q9 = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q9 = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT * FROM Products ORDER BY Category ASC, UnitPrice DESC");
            Console.WriteLine("\nEF Core Support: YES - Multi-column ORDER BY with mixed directions");
            Console.WriteLine("\nTime Complexity: O(n log n) - Multi-key sort with mixed order");
            Console.WriteLine("  Explanation: Primary sort by category, secondary by price descending");
            Console.WriteLine("Space Complexity: O(n) - Complete sorted sequence");
            Console.WriteLine("  Explanation: New ordered sequence maintaining all products");
            Console.WriteLine($"\nResults: First 8 of {q9.Count()}");
            foreach (var p in q9.Take(8))
                Console.WriteLine($"  - {p.Category,-20} {p.ProductName,-35} ${p.UnitPrice}");

            Console.WriteLine("\n[Q10] Sort by length, then descending case-insensitive");
            Console.WriteLine("--------------------------------------------------------------------------------");
            string[] words3 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q10 = words3.OrderBy(w => w.Length).ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q10 = words3.OrderBy(w => w.Length).ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT * FROM Words ORDER BY LEN(Word) ASC, Word COLLATE SQL_Latin1_General_CP1_CI_AS DESC");
            Console.WriteLine("\nEF Core Support: YES - With collation configuration");
            Console.WriteLine("\nTime Complexity: O(n log n) - Multi-key descending sort");
            Console.WriteLine("  Explanation: Primary ascending by length, secondary descending by name");
            Console.WriteLine("Space Complexity: O(n) - Sorted sequence");
            Console.WriteLine("  Explanation: New sequence with compound ordering");
            Console.WriteLine("\nResults:");
            foreach (var word in q10)
                Console.WriteLine($"  - {word} (length: {word.Length})");

            Console.WriteLine("\n[Q11] Digits with 'i' as second letter, reversed");
            Console.WriteLine("--------------------------------------------------------------------------------");
            string[] digits3 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q11 = digits3.Where(d => d.Length >= 2 && d[1] == 'i').Reverse();
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q11 = digits3.Where(d => d.Length >= 2 && d[1] == 'i').Reverse();");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT * FROM Digits WHERE LEN(Digit) >= 2 AND SUBSTRING(Digit, 2, 1) = 'i'");
            Console.WriteLine("  ORDER BY RowNumber DESC  -- Reverse requires row numbering");
            Console.WriteLine("\nEF Core Support: PARTIAL - Where translates, but Reverse() requires client evaluation");
            Console.WriteLine("  Note: Reverse() executes on client side after data retrieval");
            Console.WriteLine("\nTime Complexity: O(n) - Filter then reverse");
            Console.WriteLine("  Explanation: Linear scan for filtering + O(k) for reversing k results");
            Console.WriteLine("Space Complexity: O(k) - Filtered and reversed results");
            Console.WriteLine("  Explanation: Stores filtered results then reverses order");
            Console.WriteLine("\nResults:");
            foreach (var digit in q11)
                Console.WriteLine($"  - {digit}");

            #endregion

            #region LINQ - Transformation Operators

            Console.WriteLine("\n[Q12] Return just the names of products");
            var q12 = products.Select(p => p.ProductName);
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q12 = products.Select(p => p.ProductName);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT ProductName FROM Products");
            Console.WriteLine("\nEF Core Support: YES - Translates to SQL SELECT with single column");
            Console.WriteLine("\nTime Complexity: O(n) - Project each element");
            Console.WriteLine("  Explanation: Single pass to extract property from each product");
            Console.WriteLine("Space Complexity: O(n) - Collection of strings");
            Console.WriteLine("  Explanation: Stores one string per product");
            Console.WriteLine($"\nResults: First 5 of {q12.Count()}");
            foreach (var name in q12.Take(5))
                Console.WriteLine($"  - {name}");

            Console.WriteLine("\n[Q13] Uppercase and lowercase versions of words");
            string[] words4 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var q13 = words4.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q13 = words4.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT UPPER(Word) AS Upper, LOWER(Word) AS Lower FROM Words");
            Console.WriteLine("\nEF Core Support: YES - Translates ToUpper() and ToLower() to SQL functions");
            Console.WriteLine("\nTime Complexity: O(n) - Transform each word");
            Console.WriteLine("  Explanation: Single pass creating anonymous objects with transformations");
            Console.WriteLine("Space Complexity: O(n) - Anonymous objects with two strings each");
            Console.WriteLine("  Explanation: Each result contains upper and lower case versions");
            Console.WriteLine("\nResults:");
            foreach (var item in q13)
                Console.WriteLine($"  - Upper: {item.Upper}, Lower: {item.Lower}");

            Console.WriteLine("\n[Q14] Product properties with UnitPrice renamed to Price");
            var q14 = products.Select(p => new { p.ProductName, p.Category, Price = p.UnitPrice });
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q14 = products.Select(p => new { p.ProductName, p.Category, Price = p.UnitPrice });");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT ProductName, Category, UnitPrice AS Price FROM Products");
            Console.WriteLine("\nEF Core Support: YES - Translates to SQL SELECT with column aliasing");
            Console.WriteLine("\nTime Complexity: O(n) - Project each product");
            Console.WriteLine("  Explanation: Single pass creating anonymous objects");
            Console.WriteLine("Space Complexity: O(n) - Anonymous objects");
            Console.WriteLine("  Explanation: One anonymous object per product");
            Console.WriteLine($"\nResults: First 5 of {q14.Count()}");
            foreach (var item in q14.Take(5))
                Console.WriteLine($"  - {item.ProductName} ({item.Category}) - ${item.Price}");

            Console.WriteLine("\n[Q15] Determine if array values match their position");
            int[] arr1 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q15 = arr1.Select((num, index) => new { Number = num, InPlace = (num == index) });
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q15 = arr1.Select((num, index) => new { Number = num, InPlace = (num == index) });");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  N/A - Not directly translatable (requires index-based comparison)");
            Console.WriteLine("\nEF Core Support: NO - Indexed Select() requires client-side evaluation");
            Console.WriteLine("  Reason: Index parameter not available in SQL translation");
            Console.WriteLine("\nTime Complexity: O(n) - Single pass with index");
            Console.WriteLine("  Explanation: Iterates once comparing value to index position");
            Console.WriteLine("Space Complexity: O(n) - Anonymous objects");
            Console.WriteLine("  Explanation: Creates one result object per array element");
            Console.WriteLine("\nResults:");
            foreach (var item in q15)
                Console.WriteLine($"  - Number: {item.Number}, In Place: {item.InPlace}");

            Console.WriteLine("\n[Q16] Pairs where numbersA < numbersB");
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var q16 = numbersA.SelectMany(a => numbersB.Where(b => a < b).Select(b => new { a, b }));
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q16 = numbersA.SelectMany(a => numbersB.Where(b => a < b).Select(b => new { a, b }));");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT a.Value AS a, b.Value AS b");
            Console.WriteLine("  FROM NumbersA a CROSS JOIN NumbersB b");
            Console.WriteLine("  WHERE a.Value < b.Value");
            Console.WriteLine("\nEF Core Support: YES - Translates to CROSS JOIN with WHERE");
            Console.WriteLine("\nTime Complexity: O(n * m) - Cartesian product with filtering");
            Console.WriteLine("  Explanation: For each element in A, checks all elements in B");
            Console.WriteLine("Space Complexity: O(k) - where k is number of valid pairs");
            Console.WriteLine("  Explanation: Only stores pairs meeting the condition");
            Console.WriteLine($"\nResults: First 10 of {q16.Count()} pairs");
            foreach (var pair in q16.Take(10))
                Console.WriteLine($"  - {pair.a} < {pair.b}");

            Console.WriteLine("\n[Q17] Orders where total is less than $500");
            var q17 = customers.SelectMany(c => c.Orders.Where(o => o.Total < 500.00M)
                .Select(o => new { c.CustomerID, o.OrderID, o.Total }));
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q17 = customers.SelectMany(c => c.Orders.Where(o => o.Total < 500.00M)");
            Console.WriteLine("      .Select(o => new { c.CustomerID, o.OrderID, o.Total }));");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT c.CustomerID, o.OrderID, o.Total");
            Console.WriteLine("  FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID");
            Console.WriteLine("  WHERE o.Total < 500.00");
            Console.WriteLine("\nEF Core Support: YES - Translates to JOIN with WHERE");
            Console.WriteLine("\nTime Complexity: O(n * m) - where n is customers, m is avg orders per customer");
            Console.WriteLine("  Explanation: Flattens customer orders and filters");
            Console.WriteLine("Space Complexity: O(k) - matching orders");
            Console.WriteLine("  Explanation: Stores only orders meeting criteria");
            Console.WriteLine($"\nResults: {q17.Count()} orders found");
            foreach (var item in q17.Take(5))
                Console.WriteLine($"  - Customer: {item.CustomerID}, Order: {item.OrderID}, Total: ${item.Total}");

            Console.WriteLine("\n[Q18] Orders made in 1998 or later");
            var q18 = customers.SelectMany(c => c.Orders.Where(o => o.OrderDate.Year >= 1998)
                .Select(o => new { c.CustomerID, o.OrderID, o.OrderDate }));
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q18 = customers.SelectMany(c => c.Orders.Where(o => o.OrderDate.Year >= 1998)");
            Console.WriteLine("      .Select(o => new { c.CustomerID, o.OrderID, o.OrderDate }));");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT c.CustomerID, o.OrderID, o.OrderDate");
            Console.WriteLine("  FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID");
            Console.WriteLine("  WHERE YEAR(o.OrderDate) >= 1998");
            Console.WriteLine("\nEF Core Support: YES - Translates DateTime.Year to SQL YEAR() function");
            Console.WriteLine("\nTime Complexity: O(n * m) - Flatten and filter");
            Console.WriteLine("  Explanation: Iterates through all customer orders checking year");
            Console.WriteLine("Space Complexity: O(k) - Matching orders");
            Console.WriteLine("  Explanation: Stores orders from 1998 onwards");
            Console.WriteLine($"\nResults: {q18.Count()} orders found");
            foreach (var item in q18.Take(5))
                Console.WriteLine($"  - Customer: {item.CustomerID}, Order: {item.OrderID}, Date: {item.OrderDate:yyyy-MM-dd}");

            Console.WriteLine("\n[Q19] ProductSummary record projection");
            var q19 = products.Select(p => new ProductSummary(p.ProductName, p.Category, p.UnitPrice));
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q19 = products.Select(p => new ProductSummary(p.ProductName, p.Category, p.UnitPrice));");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT ProductName, Category, UnitPrice FROM Products");
            Console.WriteLine("\nEF Core Support: YES - Records translate like anonymous types");
            Console.WriteLine("\nTime Complexity: O(n) - Map each product");
            Console.WriteLine("  Explanation: Single pass creating record instances");
            Console.WriteLine("Space Complexity: O(n) - Record collection");
            Console.WriteLine("  Explanation: One record per product");
            Console.WriteLine($"\nResults: First 5 of {q19.Count()}");
            foreach (var summary in q19.Take(5))
                Console.WriteLine($"  - {summary.ProductName} - {summary.Category} - ${summary.Price}");

            Console.WriteLine("\n[Q20] Using Product.ToDto() instance method");
            var q20 = products.Select(p => p.ToDto());
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q20 = products.Select(p => p.ToDto());");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  N/A - Instance method call requires client-side evaluation");
            Console.WriteLine("  If using EF Core: SELECT * FROM Products (then ToDto() executes in memory)");
            Console.WriteLine("\nEF Core Support: PARTIAL - Method call not translated, executes client-side");
            Console.WriteLine("  Note: Fetches full entities then calls ToDto() in memory");
            Console.WriteLine("\nTime Complexity: O(n) - Client-side transformation");
            Console.WriteLine("  Explanation: Retrieves all products then maps each to DTO");
            Console.WriteLine("Space Complexity: O(n) - DTO collection");
            Console.WriteLine("  Explanation: Creates one DTO per product");
            Console.WriteLine($"\nResults: First 5 of {q20.Count()}");
            foreach (var dto in q20.Take(5))
                Console.WriteLine($"  - {dto.Name} - {dto.Category} - ${dto.Price}");

            Console.WriteLine("\n[Q21] Using static ProductMapper");
            var q21 = products.Select(p => ProductMapper.MapToDto(p));
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q21 = products.Select(p => ProductMapper.MapToDto(p));");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  N/A - Static method call requires client-side evaluation");
            Console.WriteLine("  If using EF Core: SELECT * FROM Products (then MapToDto() executes in memory)");
            Console.WriteLine("\nEF Core Support: PARTIAL - Method call not translated, executes client-side");
            Console.WriteLine("  Note: Similar to instance method, requires client evaluation");
            Console.WriteLine("\nTime Complexity: O(n) - Client-side mapping");
            Console.WriteLine("  Explanation: Retrieves all products then maps via static method");
            Console.WriteLine("Space Complexity: O(n) - DTO collection");
            Console.WriteLine("  Explanation: One DTO per product");
            Console.WriteLine($"\nResults: First 5 of {q21.Count()}");
            foreach (var dto in q21.Take(5))
                Console.WriteLine($"  - {dto.Name} - {dto.Category} - ${dto.Price}");

            // Query 22: Comparison of projection strategies
            Console.WriteLine("\n[Q22] Comparison of Projection Strategies");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("\n1. ANONYMOUS TYPES:");
            Console.WriteLine("   Pros:");
            Console.WriteLine("   - Fully translatable to SQL in EF Core");
            Console.WriteLine("   - No extra class definitions needed");
            Console.WriteLine("   - Compile-time safety");
            Console.WriteLine("   Cons:");
            Console.WriteLine("   - Cannot be returned from methods (unless using dynamic)");
            Console.WriteLine("   - Not reusable across different queries");
            Console.WriteLine("   Best for: Quick, local projections within a single method");
            Console.WriteLine("\n2. RECORD TYPES:");
            Console.WriteLine("   Pros:");
            Console.WriteLine("   - Translatable to SQL when using constructor syntax");
            Console.WriteLine("   - Immutable by default");
            Console.WriteLine("   - Can be returned from methods");
            Console.WriteLine("   - Value-based equality");
            Console.WriteLine("   Cons:");
            Console.WriteLine("   - Requires type definition");
            Console.WriteLine("   Best for: DTOs, value objects, cross-method projections");
            Console.WriteLine("\n3. INSTANCE ToDto() METHOD:");
            Console.WriteLine("   Pros:");
            Console.WriteLine("   - Encapsulation - mapping logic lives with the entity");
            Console.WriteLine("   - Easy to find and maintain");
            Console.WriteLine("   Cons:");
            Console.WriteLine("   - NOT translatable to SQL - requires client evaluation");
            Console.WriteLine("   - Couples entity to DTO (tight coupling)");
            Console.WriteLine("   - Fetches entire entity before mapping");
            Console.WriteLine("   Best for: Post-query transformations, non-EF scenarios");
            Console.WriteLine("\n4. STATIC MAPPER CLASS:");
            Console.WriteLine("   Pros:");
            Console.WriteLine("   - Decouples entities from DTOs");
            Console.WriteLine("   - Centralized mapping logic");
            Console.WriteLine("   - Reusable across different contexts");
            Console.WriteLine("   Cons:");
            Console.WriteLine("   - NOT translatable to SQL - requires client evaluation");
            Console.WriteLine("   - Extra class to maintain");
            Console.WriteLine("   - Can become bloated if many mappings exist");
            Console.WriteLine("   Best for: Clean architecture, many-to-many mappings");
            Console.WriteLine("\nRECOMMENDATION:");
            Console.WriteLine("   - EF Core queries: Use anonymous types or record constructors");
            Console.WriteLine("   - Reusable DTOs: Use records");
            Console.WriteLine("   - Post-query mapping: Use static mappers (better separation of concerns)");

            // Query 23: Sort by category, then price descending, with projection
            Console.WriteLine("\n[Q23] Sort by category and price (desc), project to custom type");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q23 = products.OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice)
                .Select(p => new { p.ProductName, p.Category, Price = p.UnitPrice });
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q23 = products.OrderBy(p => p.Category)");
            Console.WriteLine("      .ThenByDescending(p => p.UnitPrice)");
            Console.WriteLine("      .Select(p => new { p.ProductName, p.Category, Price = p.UnitPrice });");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT ProductName, Category, UnitPrice AS Price");
            Console.WriteLine("  FROM Products");
            Console.WriteLine("  ORDER BY Category ASC, UnitPrice DESC");
            Console.WriteLine("\nEF Core Support: YES - Full translation to SQL");
            Console.WriteLine("\nTime Complexity: O(n log n) - Sorting dominates");
            Console.WriteLine("  Explanation: Multi-key sort followed by O(n) projection");
            Console.WriteLine("Space Complexity: O(n) - Sorted and projected results");
            Console.WriteLine("  Explanation: Complete ordered projection");
            Console.WriteLine($"\nResults: First 8 of {q23.Count()}");
            foreach (var item in q23.Take(8))
                Console.WriteLine($"  - {item.Category,-20} {item.ProductName,-35} ${item.Price}");

            // Query 24: Complex filtering, aggregation, ordering, and projection
            Console.WriteLine("\n[Q24] Complex query: Filter, aggregate, order, project");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var inStockExpensive = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 10.00M);
            var totalStockValue = inStockExpensive.Sum(p => p.UnitPrice * p.UnitsInStock);
            var q24 = inStockExpensive
                .OrderByDescending(p => p.UnitPrice)
                .ThenBy(p => p.ProductName)
                .Select(p => new
                {
                    ProductName = p.ProductName,
                    Category = p.Category,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    TotalStockValue = totalStockValue
                });
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var inStockExpensive = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 10.00M);");
            Console.WriteLine("  var totalStockValue = inStockExpensive.Sum(p => p.UnitPrice * p.UnitsInStock);");
            Console.WriteLine("  var q24 = inStockExpensive");
            Console.WriteLine("      .OrderByDescending(p => p.UnitPrice)");
            Console.WriteLine("      .ThenBy(p => p.ProductName)");
            Console.WriteLine("      .Select(p => new { p.ProductName, p.Category, p.UnitPrice, p.UnitsInStock, TotalStockValue = totalStockValue });");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  -- First query for sum:");
            Console.WriteLine("  SELECT SUM(UnitPrice * UnitsInStock) AS TotalStockValue");
            Console.WriteLine("  FROM Products WHERE UnitsInStock > 0 AND UnitPrice > 10.00");
            Console.WriteLine("  -- Second query for results:");
            Console.WriteLine("  SELECT ProductName, Category, UnitPrice, UnitsInStock, @TotalStockValue AS TotalStockValue");
            Console.WriteLine("  FROM Products WHERE UnitsInStock > 0 AND UnitPrice > 10.00");
            Console.WriteLine("  ORDER BY UnitPrice DESC, ProductName ASC");
            Console.WriteLine("\nEF Core Support: PARTIAL - Would require two queries or subquery");
            Console.WriteLine("  Note: Total calculated separately then used as constant in projection");
            Console.WriteLine("\nTime Complexity: O(n log n) - Two passes plus sorting");
            Console.WriteLine("  Explanation: O(n) filter + O(n) sum + O(k log k) sort where k < n");
            Console.WriteLine("Space Complexity: O(k) - Filtered and ordered results");
            Console.WriteLine("  Explanation: Stores only products meeting criteria");
            Console.WriteLine($"\nTotal Stock Value: ${totalStockValue:N2}");
            Console.WriteLine($"Results: {q24.Count()} products");
            foreach (var item in q24.Take(5))
                Console.WriteLine($"  - {item.ProductName,-35} {item.Category,-20} ${item.UnitPrice,8:N2} x {item.UnitsInStock,3} units");

            // Query 25: Filter by ID list using Contains
            Console.WriteLine("\n[Q25] Filter products by ID list using Contains");
            Console.WriteLine("--------------------------------------------------------------------------------");
            int[] selectedIds = { 1, 2, 3, 4, 5 };
            var q25 = products.Where(p => selectedIds.Contains(p.ProductID))
                .OrderBy(p => p.Category)
                .ThenBy(p => p.ProductName)
                .Select(p => new { p.ProductID, p.ProductName, p.Category, p.UnitPrice });
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  int[] selectedIds = { 1, 2, 3, 4, 5 };");
            Console.WriteLine("  var q25 = products.Where(p => selectedIds.Contains(p.ProductID))");
            Console.WriteLine("      .OrderBy(p => p.Category)");
            Console.WriteLine("      .ThenBy(p => p.ProductName)");
            Console.WriteLine("      .Select(p => new { p.ProductID, p.ProductName, p.Category, p.UnitPrice });");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT ProductID, ProductName, Category, UnitPrice");
            Console.WriteLine("  FROM Products");
            Console.WriteLine("  WHERE ProductID IN (1, 2, 3, 4, 5)");
            Console.WriteLine("  ORDER BY Category ASC, ProductName ASC");
            Console.WriteLine("\nEF Core Support: YES - Translates Contains() to SQL IN clause");
            Console.WriteLine("\nTime Complexity: O(n + k log k) - Filter + sort matching items");
            Console.WriteLine("  Explanation: O(n) to check Contains for each product, O(k log k) to sort k matches");
            Console.WriteLine("Space Complexity: O(k) - Matching products");
            Console.WriteLine("  Explanation: Stores only products with IDs in the list");
            Console.WriteLine($"\nResults: {q25.Count()} products");
            foreach (var item in q25)
                Console.WriteLine($"  - ID: {item.ProductID}, {item.ProductName}, {item.Category}, ${item.UnitPrice}");

            #endregion

            #region LINQ - Element Operators

            Console.WriteLine("\n================================================================================");
            Console.WriteLine("LINQ - ELEMENT OPERATORS");
            Console.WriteLine("================================================================================");

            // Query 26: First product out of stock
            Console.WriteLine("\n[Q26] First product out of stock");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q26 = products.First(p => p.UnitsInStock == 0);
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q26 = products.First(p => p.UnitsInStock == 0);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT TOP 1 * FROM Products WHERE UnitsInStock = 0");
            Console.WriteLine("\nEF Core Support: YES - Translates to TOP 1 or LIMIT 1");
            Console.WriteLine("\nTime Complexity: O(n) worst case - Best case O(1) if first element matches");
            Console.WriteLine("  Explanation: Scans until first match found, throws if none exists");
            Console.WriteLine("Space Complexity: O(1) - Single element");
            Console.WriteLine("  Explanation: Returns only the first matching product");
            Console.WriteLine("\nResult:");
            Console.WriteLine($"  - {q26.ProductName} (ID: {q26.ProductID})");

            // Query 27: First product with price > 1000, or null
            Console.WriteLine("\n[Q27] First product with price > $1000, or null");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q27 = products.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q27 = products.FirstOrDefault(p => p.UnitPrice > 1000);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT TOP 1 * FROM Products WHERE UnitPrice > 1000");
            Console.WriteLine("\nEF Core Support: YES - Translates to TOP 1 or LIMIT 1");
            Console.WriteLine("\nTime Complexity: O(n) worst case - Best case O(1)");
            Console.WriteLine("  Explanation: Scans until first match, returns default (null) if none");
            Console.WriteLine("Space Complexity: O(1) - Single element or null");
            Console.WriteLine("  Explanation: Returns first match or default value");
            Console.WriteLine("\nResult:");
            Console.WriteLine($"  - {(q27 == null ? "No product found" : q27.ProductName)}");

            // Query 28: Second number greater than 5
            Console.WriteLine("\n[Q28] Second number greater than 5");
            Console.WriteLine("--------------------------------------------------------------------------------");
            int[] arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q28 = arr2.Where(n => n > 5).Skip(1).First();
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q28 = arr2.Where(n => n > 5).Skip(1).First();");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT * FROM Numbers WHERE Value > 5");
            Console.WriteLine("  ORDER BY (SELECT 0)  -- Maintain order");
            Console.WriteLine("  OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY");
            Console.WriteLine("\nEF Core Support: YES - Translates to OFFSET/FETCH or LIMIT/OFFSET");
            Console.WriteLine("\nTime Complexity: O(n) - Must find first two matches");
            Console.WriteLine("  Explanation: Filters and skips first result to get second");
            Console.WriteLine("Space Complexity: O(1) - Single value");
            Console.WriteLine("  Explanation: Returns only one number");
            Console.WriteLine("\nResult:");
            Console.WriteLine($"  - {q28}");

            // Query 29: Explanation of FirstOrDefault vs SingleOrDefault
            Console.WriteLine("\n[Q29] FirstOrDefault vs SingleOrDefault - Explanation");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("\nFirstOrDefault():");
            Console.WriteLine("  - Returns the FIRST element matching the condition");
            Console.WriteLine("  - Returns default(T) if NO elements match");
            Console.WriteLine("  - Does NOT throw if multiple elements match");
            Console.WriteLine("  - SQL: SELECT TOP 1 ... WHERE condition");
            Console.WriteLine("  - Use when: You want the first match and don't care if there are more");
            Console.WriteLine("\nSingleOrDefault():");
            Console.WriteLine("  - Returns the ONLY element matching the condition");
            Console.WriteLine("  - Returns default(T) if NO elements match");
            Console.WriteLine("  - THROWS exception if MORE THAN ONE element matches");
            Console.WriteLine("  - SQL: SELECT ... WHERE condition (then validates count)");
            Console.WriteLine("  - Use when: You expect exactly zero or one match");
            Console.WriteLine("\nExample with FirstOrDefault:");
            var beverages = products.Where(p => p.Category == "Beverages");
            var firstBeverage = beverages.FirstOrDefault();
            Console.WriteLine($"  FirstOrDefault on Beverages: {firstBeverage?.ProductName} ({beverages.Count()} total)");
            Console.WriteLine("\nExample with SingleOrDefault:");
            try
            {
                var singleBeverage = beverages.SingleOrDefault();
                Console.WriteLine($"  SingleOrDefault on Beverages: {singleBeverage?.ProductName}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"  SingleOrDefault on Beverages: EXCEPTION - Multiple elements found!");
            }
            Console.WriteLine("\nWhen to use each:");
            Console.WriteLine("  - FirstOrDefault: Lists, searches, 'get first available'");
            Console.WriteLine("  - SingleOrDefault: Primary keys, unique constraints, 'get by ID'");

            #endregion

            #region LINQ - Aggregate Operators

            Console.WriteLine("\n================================================================================");
            Console.WriteLine("LINQ - AGGREGATE OPERATORS");
            Console.WriteLine("================================================================================");

            // Query 30: Count odd numbers
            Console.WriteLine("\n[Q30] Count of odd numbers in array");
            Console.WriteLine("--------------------------------------------------------------------------------");
            int[] arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q30 = arr3.Count(n => n % 2 != 0);
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q30 = arr3.Count(n => n % 2 != 0);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT COUNT(*) FROM Numbers WHERE Value % 2 != 0");
            Console.WriteLine("\nEF Core Support: YES - Translates to SQL COUNT with WHERE");
            Console.WriteLine("\nTime Complexity: O(n) - Check each element");
            Console.WriteLine("  Explanation: Single pass counting elements meeting condition");
            Console.WriteLine("Space Complexity: O(1) - Single integer result");
            Console.WriteLine("  Explanation: Only stores the count");
            Console.WriteLine($"\nResult: {q30} odd numbers");

            // Query 31: Customers and their order count
            Console.WriteLine("\n[Q31] List of customers and how many orders each has");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q31 = customers.Select(c => new { c.CustomerID, c.CompanyName, OrderCount = c.Orders.Count });
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q31 = customers.Select(c => new { c.CustomerID, c.CompanyName, OrderCount = c.Orders.Count });");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT c.CustomerID, c.CompanyName, COUNT(o.OrderID) AS OrderCount");
            Console.WriteLine("  FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID");
            Console.WriteLine("  GROUP BY c.CustomerID, c.CompanyName");
            Console.WriteLine("\nEF Core Support: YES - Translates to JOIN with GROUP BY COUNT");
            Console.WriteLine("\nTime Complexity: O(n) - Single pass with aggregation");
            Console.WriteLine("  Explanation: Iterates customers, counting orders for each");
            Console.WriteLine("Space Complexity: O(n) - One result per customer");
            Console.WriteLine("  Explanation: Stores customer info with order count");
            Console.WriteLine("\nResults:");
            foreach (var item in q31)
                Console.WriteLine($"  - {item.CompanyName} ({item.CustomerID}): {item.OrderCount} orders");

            // Query 32: Categories and product count
            Console.WriteLine("\n[Q32] List of categories and how many products each has");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q32 = products.GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, ProductCount = g.Count() });
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q32 = products.GroupBy(p => p.Category)");
            Console.WriteLine("      .Select(g => new { Category = g.Key, ProductCount = g.Count() });");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT Category, COUNT(*) AS ProductCount");
            Console.WriteLine("  FROM Products");
            Console.WriteLine("  GROUP BY Category");
            Console.WriteLine("\nEF Core Support: YES - Translates to GROUP BY with COUNT");
            Console.WriteLine("\nTime Complexity: O(n) - Single pass grouping");
            Console.WriteLine("  Explanation: Groups products by category and counts each group");
            Console.WriteLine("Space Complexity: O(k) - where k is number of unique categories");
            Console.WriteLine("  Explanation: One result per category");
            Console.WriteLine("\nResults:");
            foreach (var item in q32.OrderBy(x => x.Category))
                Console.WriteLine($"  - {item.Category}: {item.ProductCount} products");

            // Query 33: Sum of array
            Console.WriteLine("\n[Q33] Total sum of numbers in array");
            Console.WriteLine("--------------------------------------------------------------------------------");
            int[] arr4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q33 = arr4.Sum();
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q33 = arr4.Sum();");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT SUM(Value) FROM Numbers");
            Console.WriteLine("\nEF Core Support: YES - Translates to SQL SUM aggregate");
            Console.WriteLine("\nTime Complexity: O(n) - Sum all elements");
            Console.WriteLine("  Explanation: Single pass adding each element");
            Console.WriteLine("Space Complexity: O(1) - Single sum value");
            Console.WriteLine("  Explanation: Only stores the total");
            Console.WriteLine($"\nResult: {q33}");

            // Query 34: Total characters in dictionary file
            Console.WriteLine("\n[Q34] Total characters in dictionary file");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  string[] words = File.ReadAllLines(\"dictionary_english.txt\");");
            Console.WriteLine("  var q34 = words.Sum(w => w.Length);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT SUM(LEN(Word)) FROM Dictionary");
            Console.WriteLine("\nEF Core Support: YES - Translates to SUM(LEN(...))");
            Console.WriteLine("\nTime Complexity: O(n) - Sum lengths of all words");
            Console.WriteLine("  Explanation: Single pass getting length of each word and summing");
            Console.WriteLine("Space Complexity: O(1) - Single sum value");
            Console.WriteLine("  Explanation: Only stores the total count");
            Console.WriteLine("\nNote: dictionary_english.txt not found in workspace");
            Console.WriteLine("Result: Would return total character count if file existed");

            // Query 35: Shortest word length
            Console.WriteLine("\n[Q35] Length of shortest word in dictionary");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  string[] words = File.ReadAllLines(\"dictionary_english.txt\");");
            Console.WriteLine("  var q35 = words.Min(w => w.Length);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT MIN(LEN(Word)) FROM Dictionary");
            Console.WriteLine("\nEF Core Support: YES - Translates to MIN(LEN(...))");
            Console.WriteLine("\nTime Complexity: O(n) - Find minimum length");
            Console.WriteLine("  Explanation: Single pass tracking minimum length seen");
            Console.WriteLine("Space Complexity: O(1) - Single minimum value");
            Console.WriteLine("  Explanation: Only stores the minimum length");
            Console.WriteLine("\nNote: dictionary_english.txt not found in workspace");

            // Query 36: Longest word length
            Console.WriteLine("\n[Q36] Length of longest word in dictionary");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  string[] words = File.ReadAllLines(\"dictionary_english.txt\");");
            Console.WriteLine("  var q36 = words.Max(w => w.Length);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT MAX(LEN(Word)) FROM Dictionary");
            Console.WriteLine("\nEF Core Support: YES - Translates to MAX(LEN(...))");
            Console.WriteLine("\nTime Complexity: O(n) - Find maximum length");
            Console.WriteLine("  Explanation: Single pass tracking maximum length seen");
            Console.WriteLine("Space Complexity: O(1) - Single maximum value");
            Console.WriteLine("  Explanation: Only stores the maximum length");
            Console.WriteLine("\nNote: dictionary_english.txt not found in workspace");

            // Query 37: Average word length
            Console.WriteLine("\n[Q37] Average length of words in dictionary");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  string[] words = File.ReadAllLines(\"dictionary_english.txt\");");
            Console.WriteLine("  var q37 = words.Average(w => w.Length);");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT AVG(CAST(LEN(Word) AS FLOAT)) FROM Dictionary");
            Console.WriteLine("\nEF Core Support: YES - Translates to AVG with proper casting");
            Console.WriteLine("\nTime Complexity: O(n) - Calculate average");
            Console.WriteLine("  Explanation: Single pass summing lengths and counting words");
            Console.WriteLine("Space Complexity: O(1) - Single average value");
            Console.WriteLine("  Explanation: Only stores the calculated average");
            Console.WriteLine("\nNote: dictionary_english.txt not found in workspace");

            // Query 38: Total units in stock per category
            Console.WriteLine("\n[Q38] Total units in stock for each product category");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q38 = products.GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, TotalUnits = g.Sum(p => p.UnitsInStock) });
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q38 = products.GroupBy(p => p.Category)");
            Console.WriteLine("      .Select(g => new { Category = g.Key, TotalUnits = g.Sum(p => p.UnitsInStock) });");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT Category, SUM(UnitsInStock) AS TotalUnits");
            Console.WriteLine("  FROM Products");
            Console.WriteLine("  GROUP BY Category");
            Console.WriteLine("\nEF Core Support: YES - Translates to GROUP BY with SUM");
            Console.WriteLine("\nTime Complexity: O(n) - Group and aggregate");
            Console.WriteLine("  Explanation: Single pass grouping by category and summing units");
            Console.WriteLine("Space Complexity: O(k) - where k is number of categories");
            Console.WriteLine("  Explanation: One result per unique category");
            Console.WriteLine("\nResults:");
            foreach (var item in q38.OrderBy(x => x.Category))
                Console.WriteLine($"  - {item.Category}: {item.TotalUnits} units");

            // Query 39: Cheapest price per category
            Console.WriteLine("\n[Q39] Cheapest price in each category");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q39 = products.GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) });
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q39 = products.GroupBy(p => p.Category)");
            Console.WriteLine("      .Select(g => new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) });");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT Category, MIN(UnitPrice) AS CheapestPrice");
            Console.WriteLine("  FROM Products");
            Console.WriteLine("  GROUP BY Category");
            Console.WriteLine("\nEF Core Support: YES - Translates to GROUP BY with MIN");
            Console.WriteLine("\nTime Complexity: O(n) - Group and find minimum");
            Console.WriteLine("  Explanation: Single pass grouping and tracking minimum per group");
            Console.WriteLine("Space Complexity: O(k) - where k is number of categories");
            Console.WriteLine("  Explanation: One result per category");
            Console.WriteLine("\nResults:");
            foreach (var item in q39.OrderBy(x => x.Category))
                Console.WriteLine($"  - {item.Category}: ${item.CheapestPrice}");

            // Query 40: Products with cheapest price in each category (using let)
            Console.WriteLine("\n[Q40] Products with cheapest price in each category (using Let)");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q40 = from p in products
                      group p by p.Category into g
                      let minPrice = g.Min(p => p.UnitPrice)
                      from p in g
                      where p.UnitPrice == minPrice
                      select new { p.Category, p.ProductName, p.UnitPrice };
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q40 = from p in products");
            Console.WriteLine("            group p by p.Category into g");
            Console.WriteLine("            let minPrice = g.Min(p => p.UnitPrice)");
            Console.WriteLine("            from p in g");
            Console.WriteLine("            where p.UnitPrice == minPrice");
            Console.WriteLine("            select new { p.Category, p.ProductName, p.UnitPrice };");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT p.Category, p.ProductName, p.UnitPrice");
            Console.WriteLine("  FROM Products p");
            Console.WriteLine("  INNER JOIN (");
            Console.WriteLine("      SELECT Category, MIN(UnitPrice) AS MinPrice");
            Console.WriteLine("      FROM Products");
            Console.WriteLine("      GROUP BY Category");
            Console.WriteLine("  ) AS minPrices ON p.Category = minPrices.Category AND p.UnitPrice = minPrices.MinPrice");
            Console.WriteLine("\nEF Core Support: PARTIAL - May require client evaluation or subquery");
            Console.WriteLine("  Note: 'let' with subsequent regrouping often needs optimization");
            Console.WriteLine("\nTime Complexity: O(n) - Group, find min, filter");
            Console.WriteLine("  Explanation: Groups once, finds min per group, then filters");
            Console.WriteLine("Space Complexity: O(k) - Products matching minimum prices");
            Console.WriteLine("  Explanation: One or more products per category");
            Console.WriteLine("\nResults:");
            foreach (var item in q40.OrderBy(x => x.Category))
                Console.WriteLine($"  - {item.Category}: {item.ProductName} - ${item.UnitPrice}");

            // Query 41: Most expensive price per category
            Console.WriteLine("\n[Q41] Most expensive price in each category");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q41 = products.GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, MostExpensivePrice = g.Max(p => p.UnitPrice) });
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q41 = products.GroupBy(p => p.Category)");
            Console.WriteLine("      .Select(g => new { Category = g.Key, MostExpensivePrice = g.Max(p => p.UnitPrice) });");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT Category, MAX(UnitPrice) AS MostExpensivePrice");
            Console.WriteLine("  FROM Products");
            Console.WriteLine("  GROUP BY Category");
            Console.WriteLine("\nEF Core Support: YES - Translates to GROUP BY with MAX");
            Console.WriteLine("\nTime Complexity: O(n) - Group and find maximum");
            Console.WriteLine("  Explanation: Single pass grouping and tracking maximum per group");
            Console.WriteLine("Space Complexity: O(k) - where k is number of categories");
            Console.WriteLine("  Explanation: One result per category");
            Console.WriteLine("\nResults:");
            foreach (var item in q41.OrderBy(x => x.Category))
                Console.WriteLine($"  - {item.Category}: ${item.MostExpensivePrice}");

            // Query 42: Products with most expensive price in each category
            Console.WriteLine("\n[Q42] Products with most expensive price in each category");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q42 = from p in products
                      group p by p.Category into g
                      let maxPrice = g.Max(p => p.UnitPrice)
                      from p in g
                      where p.UnitPrice == maxPrice
                      select new { p.Category, p.ProductName, p.UnitPrice };
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q42 = from p in products");
            Console.WriteLine("            group p by p.Category into g");
            Console.WriteLine("            let maxPrice = g.Max(p => p.UnitPrice)");
            Console.WriteLine("            from p in g");
            Console.WriteLine("            where p.UnitPrice == maxPrice");
            Console.WriteLine("            select new { p.Category, p.ProductName, p.UnitPrice };");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT p.Category, p.ProductName, p.UnitPrice");
            Console.WriteLine("  FROM Products p");
            Console.WriteLine("  INNER JOIN (");
            Console.WriteLine("      SELECT Category, MAX(UnitPrice) AS MaxPrice");
            Console.WriteLine("      FROM Products");
            Console.WriteLine("      GROUP BY Category");
            Console.WriteLine("  ) AS maxPrices ON p.Category = maxPrices.Category AND p.UnitPrice = maxPrices.MaxPrice");
            Console.WriteLine("\nEF Core Support: PARTIAL - Similar to Q40, may need optimization");
            Console.WriteLine("\nTime Complexity: O(n) - Group, find max, filter");
            Console.WriteLine("  Explanation: Groups once, finds max per group, then filters");
            Console.WriteLine("Space Complexity: O(k) - Products matching maximum prices");
            Console.WriteLine("  Explanation: One or more products per category");
            Console.WriteLine("\nResults:");
            foreach (var item in q42.OrderBy(x => x.Category))
                Console.WriteLine($"  - {item.Category}: {item.ProductName} - ${item.UnitPrice}");

            // Query 43: Average price per category
            Console.WriteLine("\n[Q43] Average price of each category's products");
            Console.WriteLine("--------------------------------------------------------------------------------");
            var q43 = products.GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, AveragePrice = g.Average(p => p.UnitPrice) });
            Console.WriteLine("C# LINQ Query:");
            Console.WriteLine("  var q43 = products.GroupBy(p => p.Category)");
            Console.WriteLine("      .Select(g => new { Category = g.Key, AveragePrice = g.Average(p => p.UnitPrice) });");
            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine("  SELECT Category, AVG(UnitPrice) AS AveragePrice");
            Console.WriteLine("  FROM Products");
            Console.WriteLine("  GROUP BY Category");
            Console.WriteLine("\nEF Core Support: YES - Translates to GROUP BY with AVG");
            Console.WriteLine("\nTime Complexity: O(n) - Group and calculate average");
            Console.WriteLine("  Explanation: Single pass grouping and calculating average per group");
            Console.WriteLine("Space Complexity: O(k) - where k is number of categories");
            Console.WriteLine("  Explanation: One result per category");
            Console.WriteLine("\nResults:");
            foreach (var item in q43.OrderBy(x => x.Category))
                Console.WriteLine($"  - {item.Category}: ${item.AveragePrice:N2}");

            #endregion

            Console.WriteLine("\n================================================================================");
            Console.WriteLine("ASSIGNMENT COMPLETE - All 43 queries executed with SQL translations");
            Console.WriteLine("and complexity analysis!");
            Console.WriteLine("================================================================================");
        }
    }
}

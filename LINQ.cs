using System;
using System.Linq;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
}

class Program
{
    static void Main()
    {
        // Sample list of products
        List<Product> products = new List<Product>
        {
            new Product { Name = "Apple", Category = "Fruit", Price = 1.2 },
            new Product { Name = "Banana", Category = "Fruit", Price = 0.8 },
            new Product { Name = "Carrot", Category = "Vegetable", Price = 0.5 },
            new Product { Name = "Salmon", Category = "Meat", Price = 7.0 },
            new Product { Name = "Broccoli", Category = "Vegetable", Price = 1.3 }
        };

        // --------------------------------------------------
        // 🔸 1. FILTERING (get products with price > 1.0)
        // --------------------------------------------------

        // Query syntax
        var filteredQuery = from p in products
                            where p.Price > 1.0
                            select p;

        // Method syntax
        var filteredMethod = products.Where(p => p.Price > 1.0);


        // --------------------------------------------------
        // 🔸 2. SORTING (by Category, then Price descending)
        // --------------------------------------------------

        // Query syntax
        var sortedQuery = from p in products
                          orderby p.Category, p.Price descending
                          select p;

        // Method syntax
        var sortedMethod = products.OrderBy(p => p.Category).ThenByDescending(p => p.Price);


        // --------------------------------------------------
        // 🔸 3. PROJECTION (select only Name and Price)
        // --------------------------------------------------

        // Query syntax
        var projectedQuery = from p in products
                             select new { p.Name, p.Price };

        // Method syntax
        var projectedMethod = products.Select(p => new { p.Name, p.Price });


        // --------------------------------------------------
        // 🔸 4. AGGREGATION (count, sum, average)
        // --------------------------------------------------

        // Method syntax
        int countMethod = products.Count();
        double sumMethod = products.Sum(p => p.Price);
        double averageMethod = products.Average(p => p.Price);
        double maxMethod = products.Max(p => p.Price);
        double minMethod = products.Min(p => p.Price);


        // --------------------------------------------------
        // 🔸 5. SET OPERATIONS (Distinct, Union, Except)
        // --------------------------------------------------

        var categories = products.Select(p => p.Category);

        // Distinct
        var distinctCategories = categories.Distinct();

        // Union with another list
        List<string> extra = new List<string> { "Grain", "Dairy" };

        var allCategories = categories.Union(extra);

        // Except (remove "Meat")
        var filteredCategories = allCategories.Except(new List<string> { "Meat" });

        // --------------------------------------------------
        // 🔚 END OF REVISION EXAMPLES
        // --------------------------------------------------
    }
}

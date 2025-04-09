


// Define ProductTypes
using System.Xml.Serialization;

List<ProductType> productTypes = new List<ProductType>()
        {
            new ProductType() { Id = 1, Name = "Potions" },
            new ProductType() { Id = 2, Name = "Apparel" },
            new ProductType() { Id = 3, Name = "Enchanted Objects" },
            new ProductType() { Id = 4, Name = "Wands" }
        };

        // Create a list of products
        List<Product> products = new List<Product>
        {
            new Product()
            {
                Name = "Love Potion",
                Price = 100.00M,
                IsAvailable = true,
                ProductTypeId = 1,  // Potions
                DataEntered = DateTime.Now
            },
            new Product()
            {
                Name = "Wizard Robe",
                Price = 150.00M,
                IsAvailable = true,
                ProductTypeId = 2,  // Apparel
                DataEntered = DateTime.Now.AddDays(-2)
            },
            new Product()
            {
                Name = "Cursed Mirror",
                Price = 250.00M,
                IsAvailable = false,
                ProductTypeId = 3,  // Enchanted Objects
                DataEntered = DateTime.Now.AddDays(-5)
            },
            new Product()
            {
                Name = "Elder Wand",
                Price = 500.00M,
                IsAvailable = true,
                ProductTypeId = 4,  // Wands
                DataEntered = DateTime.Now.AddDays(-10)
            },
            new Product()
            {
                Name = "Healing Potion",
                Price = 75.00M,
                IsAvailable = true,
                ProductTypeId = 1,  // Potions
                DataEntered = DateTime.Now.AddDays(-1)
            }
        };

string greeting = "Reductio & Absurdum Inventory";
Console.WriteLine(greeting);

string choice;
do
{
    Console.WriteLine(@"
0. Exit
1. View All Products
2. View Products via Category
3. Add New Product
4. Delete a Product
5. Update a Product
");

    choice = Console.ReadLine();

    if (choice == "1")
    {
        ListProducts(products, productTypes);
    }
    else if (choice == "2")
    {
        ViewProductsByCategory(products, productTypes);
    }
    else if (choice == "3")
    {
        AddProduct(products, productTypes);
    }
    else if (choice == "4")
    {
        Console.WriteLine("Deleting a product...");
    }
    else if (choice == "5")
    {
        Console.WriteLine("Updating a product...");
    }
    else if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else
    {
        Console.WriteLine("Invalid choice. Please try again.");
    }

} while (choice != "0");

void ListProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("== All Products ==");
    Console.WriteLine("{0,-20} | {1,7} | {2,-15}", "Name", "Price", "Type");
    Console.WriteLine(new string('-', 50));

    var productView = products.Select(p => new
    {
        p.Name,
        p.Price,
        TypeName = productTypes.FirstOrDefault(pt => pt.Id == p.ProductTypeId)?.Name ?? "Unknown"
    });

    foreach (var item in productView)
    {
        Console.WriteLine("{0,-20} | {1,7:C} | {2,-15}", item.Name, item.Price, item.TypeName);
    }
}


void ViewProductsByCategory(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Choose a category:");
    productTypes.ForEach(pt => Console.WriteLine($"{pt.Id}. {pt.Name}"));

    Console.Write("Enter category number: ");
    if (!int.TryParse(Console.ReadLine(), out int typeId))
    {
        Console.WriteLine("Not a number. Press Enter to continue...");
        Console.ReadLine();
        return;
    }

    var selectedType = productTypes.FirstOrDefault(pt => pt.Id == typeId);
    if (selectedType is null)
    {
        Console.WriteLine("Invalid category. Press Enter to continue...");
        Console.ReadLine();
        return;
    }

    var filtered = products
        .Where(p => p.ProductTypeId == typeId)
        .ToList();

    Console.WriteLine($"\n=== Products in {selectedType.Name} ===");

    filtered.ForEach(p =>
        Console.WriteLine($@"
Name: {p.Name}
Price: {p.Price:C}
Available: {(p.IsAvailable ? "Yes" : "No")}
Days on Shelf: {(DateTime.Now - p.DataEntered).Days}
-------------------------"));

    Console.ReadLine();
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    try
    {
        Console.WriteLine("Enter product name:");
        string name = Console.ReadLine();

        Console.WriteLine("Select product category:");
        foreach (var productType in productTypes)
        {
            Console.WriteLine($"{productType.Id}. {productType.Name}");
        }

        if (!int.TryParse(Console.ReadLine(), out int productTypeId))
        {
            Console.WriteLine("Invalid product type ID.");
            return;
        }

        var selectedProductType = productTypes.FirstOrDefault(pt => pt.Id == productTypeId);
        if (selectedProductType == null)
        {
            Console.WriteLine("Product type not found.");
            return;
        }

        Console.WriteLine("Enter product price:");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Console.WriteLine("Invalid price.");
            return;
        }

        Console.WriteLine("Is the product available? (y/n)");
        bool isAvailable = Console.ReadLine().ToLower() == "y";

        Product newProduct = new Product()
        {
            Name = name,
            ProductTypeId = productTypeId,
            Price = price,
            IsAvailable = isAvailable,
            DataEntered = DateTime.Now
        };

        products.Add(newProduct);

        Console.WriteLine($"{name} added successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}
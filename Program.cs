// Define ProductTypes
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
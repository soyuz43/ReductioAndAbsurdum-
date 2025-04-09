# Reductio & Absurdum Inventory Manager

A console-based inventory management application for tracking magical products, written in C#.

## Features

- **View All Products**: Display a list of all products with their names, prices, and categories.
- **View by Category**: Filter products by predefined categories (Potions, Apparel, Enchanted Objects, Wands).
- **Add New Product**: Create new products with details like name, price, availability, and category.
- **Delete Product**: Remove a product by specifying its exact name.
- **Update Product**: Modify existing product details (name, price, category, availability).
- **Days on Shelf Tracking**: Automatically calculates days since each product was added.

## Product Categories
1. Potions
2. Apparel
3. Enchanted Objects
4. Wands

## Installation

1. Ensure [.NET SDK](https://dotnet.microsoft.com/download) is installed.
2. Clone the repository:
   ```bash
   git clone https://github.com/soyuz43/ReductioAndAbsurdum-.git
   ```
3. Navigate to the project directory:
   ```bash
   cd inventory-manager
   ```
4. Run the application:
   ```bash
   dotnet run
   ```

## Usage

**Main Menu**
```
0. Exit
1. View All Products
2. View Products via Category
3. Add New Product
4. Delete a Product
5. Update a Product
```

### Key Operations

1. **View All Products**  
   Displays a formatted table of all inventory items.

2. **View by Category**  
   - Choose a category number from the list
   - See products filtered by category with detailed info including availability and days on shelf

3. **Add Product**  
   - Enter product name
   - Select category from numbered list
   - Set price (e.g., `100.50`)
   - Specify availability (Y/N)

4. **Delete Product**  
   - Enter exact product name to remove it from inventory

5. **Update Product**  
   - Search product by name
   - Update individual fields (press Enter to keep current values):
     - Name
     - Category
     - Price
     - Availability

## Code Structure

- **Product Class**  
  Properties: `Name`, `Price`, `IsAvailable`, `ProductTypeId`, `DataEntered`
  
- **ProductType Class**  
  Properties: `Id`, `Name` (Predefined categories)

- **Main Operations**  
  - `ListProducts()`: Displays all products in table format
  - `ViewProductsByCategory()`: Filters and shows category-specific products
  - `AddProduct()`: Handles product creation with validation
  - `DeleteProduct()`: Removes products by name match
  - `UpdateProduct()`: Allows partial updates of product properties

## Notes

- Data is stored in-memory and resets when application closes
- Category list is predefined and cannot be modified through the UI
- Product availability shown as "Yes"/"No" in displays
- Days on shelf calculated from `DataEntered` timestamp


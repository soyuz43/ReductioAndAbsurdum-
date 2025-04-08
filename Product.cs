public class ProductType
{
    public int Id { get; set; }
    public string Name { get; set; }

}

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public int ProductTypeId { get; set; }
    public DateTime DataEntered { get; set; }
    public int DaysOnShelf => (DateTime.Now - DataEntered).Days;

}
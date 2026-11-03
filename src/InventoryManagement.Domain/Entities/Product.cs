namespace InventoryManagement.Domain.Entities;

public class Product
{
    public int Id {get; private set;}
    public string Name {get; private set;}
    public string SKU {get; private set;}
    public decimal Price {get; private set;}
    public int MinimumStockLevel {get; private set;}
    public bool IsActive {get; private set;}

    public Product(string name, string sku, decimal price, int minimumStockLevel)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty.");

        if (string.IsNullOrWhiteSpace(sku))
            throw new ArgumentException("SKU cannot be empty.");

        if (price <= 0)
            throw new ArgumentOutOfRangeException("Price must be greater than zero.");

        if (minimumStockLevel < 0)
            throw new ArgumentOutOfRangeException("Minimum stock level cannot be negative.");

        Name = name;
        SKU = sku;
        Price = price;
        MinimumStockLevel = minimumStockLevel;
        IsActive = true;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new ArgumentOutOfRangeException("New price must be greater than zero.");

        Price = newPrice;
    }

    public void Deactivate()
    {
        if (!IsActive)
            throw new InvalidOperationException("The product is already inactive.");

        IsActive = false;
    }
}

namespace InventoryManagement.Domain.Entities;

public class Inventory
{
    public int Id {get; private set;}
    public int ProductId {get; private set;}
    public int Quantity {get; private set;}

    public Inventory(int productId)
    {
        if (productId <= 0)
            throw new ArgumentOutOfRangeException(nameof(productId),"Product ID must be greater than zero.");

        ProductId = productId;
        Quantity = 0;
    }

    public void AddStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity),"Stock quantity must be greater than zero.");

        Quantity += quantity;
    }

    public void RemoveStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity),"Stock removal quantity must be greater than zero.");

        if (quantity > Quantity)
            throw new InvalidOperationException("You cannot remove more than the current stock.");

        Quantity -= quantity;
    }
}

using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.Entities;

public class StockMovement
{
    public int Id {get; private set;}
    public int ProductId {get; private set;}
    public int Quantity {get; private set;}
    public StockMovementType Type {get; private set;}
    public DateTime Date {get; private set;}
    public string Reason {get; private set;}

    public StockMovement(int productId, int quantity, StockMovementType type, string reason)
    {
        if (productId <= 0)
            throw new ArgumentOutOfRangeException(nameof(productId),"Product ID must be greater than zero.");

        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity),"Quantity must be greater than zero.");

        if (!Enum.IsDefined(type))
            throw new ArgumentOutOfRangeException(nameof(type),"Invalid stock movement type.");

        if (string.IsNullOrWhiteSpace(reason))
            throw new ArgumentException("Reason cannot be empty.");

        ProductId = productId;
        Quantity = quantity;
        Type = type;
        Reason = reason;
        Date = DateTime.UtcNow;
    }
}

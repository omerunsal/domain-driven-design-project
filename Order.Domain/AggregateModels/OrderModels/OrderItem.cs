using Order.Domain.SeedWork;

namespace Order.Domain.AggregateModels.OrderModels;

public class OrderItem : BaseEntity
{
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public int ProductId { get; private set; }

    public OrderItem(int quantity, decimal price, int productId)
    {
        // Business validations can be here
        Quantity = quantity;
        Price = price;
        ProductId = productId;
    }
}
using MediatR;
using Order.Domain.Events;
using Order.Domain.SeedWork;

namespace Order.Domain.AggregateModels.OrderModels;

public class Order : BaseEntity, IAggregateRoot
{
    public DateTime DateTime { get; private set; }
    public string Description { get; private set; }
    public string UserName { get; private set; }
    public string OrderStatus { get; private set; }
    public Address Address { get; private set; }
    public ICollection<OrderItem> OrderItems { get; private set; }

    public Order(DateTime dateTime, string description, string userName, string orderStatus, Address address,
        ICollection<OrderItem> orderItems)
    {
        if (dateTime < DateTime.Now)
        {
            throw new Exception("Order date must be greater than now");
        }

        if (address.City == "")
        {
            throw new Exception("City can not be empty");
        }

        DateTime = dateTime;
        Description = description ?? throw new ArgumentNullException(nameof(description));
        UserName = userName;
        OrderStatus = orderStatus ?? throw new ArgumentNullException(nameof(orderStatus));
        Address = address ?? throw new ArgumentNullException(nameof(address));
        OrderItems = orderItems ?? throw new ArgumentNullException(nameof(orderItems));
        
        AddDomainEvents(new OrderStartedDomainEvent(userName, this));
    }

    public void AddOrderItem(int quantity, decimal price, int productId)
    {
        OrderItem orderItem = new(quantity, price, productId);
        OrderItems.Add(orderItem);
    }
}
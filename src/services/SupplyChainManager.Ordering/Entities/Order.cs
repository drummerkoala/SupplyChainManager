using SupplyChainManager.Shared.Abstractions.Domain;

namespace SupplyChainManager.Ordering.Entities
{
    public class Order : IEntity, ICreateAuditable, IUpdateAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; private set; }

        public DateTime OrderDate { get; private set; }

        public decimal TotalAmount { get; private set; }

        public string Status { get; private set; } = "Pending";

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string? DeletedBy { get; set; }

        public virtual List<OrderItem>? Items { get; set; }

        private Order() { }

        public Order(Guid customerId, decimal totalAmount)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            OrderDate = DateTime.UtcNow;
            TotalAmount = totalAmount;
            Status = "Pending";
        }
    }
}

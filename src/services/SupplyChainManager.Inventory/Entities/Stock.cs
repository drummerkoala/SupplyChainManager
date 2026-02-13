using SupplyChainManager.Shared.Abstractions.Domain;

namespace SupplyChainManager.Inventory.Entities
{
    public class Stock : IEntity, ICreateAuditable, IUpdateAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; private set; }

        public Guid WarehouseId { get; private set; }

        public int Quantity { get; private set; }

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string? DeletedBy { get; set; }

        private Stock() { }

        public Stock(Guid productId, Guid warehouseId, int initialQuantity)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            WarehouseId = warehouseId;
            Quantity = initialQuantity;
        }
    }
}

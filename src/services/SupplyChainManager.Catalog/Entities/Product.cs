using SupplyChainManager.Shared.Abstractions.Domain;

namespace SupplyChainManager.Catalog.Entities
{
    public class Product: IEntity, ICreateAuditable, IUpdateAuditable, ISoftDeletable
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public string Sku { get; private set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; private set; }

        public int StockCount { get; private set; }

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedAt { get; set; }

        public string? DeletedBy { get; set; }

        private Product() {}

        public Product(string name, string sku, decimal price, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(sku)) throw new ArgumentNullException(nameof(sku));
            if (price < 0) throw new ArgumentException("Price cannot be negative", nameof(price));

            Id = Guid.NewGuid();
            Name = name;
            Sku = sku;
            Price = price;
            Description = description;
            StockCount = 0;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0) throw new ArgumentException("Price cannot be negative", nameof(newPrice));
            Price = newPrice;
        }

        public void AddStock(int quantity)
        {
            if (quantity <= 0) throw new ArgumentException("Quantity must be positive", nameof(quantity));
            StockCount += quantity;
        }

        public void RemoveStock(int quantity)
        {
            if (quantity <= 0) throw new ArgumentException("Quantity must be positive", nameof(quantity));
            if (StockCount - quantity < 0) throw new InvalidOperationException("Insufficient stock.");

            StockCount -= quantity;
        }
    }
}

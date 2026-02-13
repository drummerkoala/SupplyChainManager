using SupplyChainManager.Shared.Abstractions.Domain;

namespace SupplyChainManager.Catalog.Entities
{
    public class Category : IEntity, ICreateAuditable, IUpdateAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }

        public string Name { get; private set; } = string.Empty;

        public int Quantity { get; private set; }

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string? DeletedBy { get; set; }

        private Category() { }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}

using SupplyChainManager.Shared.Abstractions.Domain;

namespace SupplyChainManager.Inventory.Entities
{
    public class Warehouse : IEntity, ICreateAuditable, IUpdateAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }

        public string Name { get; private set; } = string.Empty;

        public string Address { get; private set; } = string.Empty;

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string? DeletedBy { get; set; }

        private Warehouse() { }

        public Warehouse(string name, string address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
        }
    }
}

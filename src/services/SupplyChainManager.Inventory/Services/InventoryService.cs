using SupplyChainManager.Inventory.Abstractions;
using SupplyChainManager.Inventory.Entities;
using SupplyChainManager.Shared.Abstractions.Persistence;

namespace SupplyChainManager.Inventory.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IRepository<Warehouse> _warehouseRepository;
        private readonly IRepository<Stock> _stockRepository;

        public InventoryService(
            IRepository<Warehouse> warehouseRepository,
            IRepository<Stock> stockRepository)
        {
            _warehouseRepository = warehouseRepository;
            _stockRepository = stockRepository;
        }
    }
}

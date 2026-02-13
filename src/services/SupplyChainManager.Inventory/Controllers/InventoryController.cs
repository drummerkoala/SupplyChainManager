using Microsoft.AspNetCore.Mvc;
using SupplyChainManager.Inventory.Abstractions;

namespace SupplyChainManager.Inventory.Controllers
{
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _service;

        public InventoryController(IInventoryService service)
        {
            _service = service;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SupplyChainManager.Catalog.Abstractions;

namespace SupplyChainManager.Catalog.Controllers
{
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }
    }
}

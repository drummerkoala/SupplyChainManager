using SupplyChainManager.Catalog.Abstractions;
using SupplyChainManager.Catalog.Entities;
using SupplyChainManager.Shared.Abstractions.Persistence;

namespace SupplyChainManager.Catalog.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }
    }
}

using SupplyChainManager.Ordering.Entities;
using SupplyChainManager.Shared.Abstractions.Persistence;

namespace SupplyChainManager.Ordering.Services
{
    public class OrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;

        public OrderService(
            IRepository<Order> orderRepository,
            IRepository<OrderItem> orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }
    }
}

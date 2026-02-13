using Microsoft.AspNetCore.Mvc;
using SupplyChainManager.Ordering.Abstractions;

namespace SupplyChainManager.Ordering.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
    }
}

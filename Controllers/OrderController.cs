using Microsoft.AspNetCore.Mvc;
using Test_Versta24.Models;
using Test_Versta24.Models.ViewModel;

namespace Test_Versta24.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository) => _orderRepository = orderRepository;

        public IActionResult Index()
        {
            return View(_orderRepository.Orders);
        }
        [Route("order/{id:long}")]
        public IActionResult Detail(long id) 
        {
            var order = _orderRepository.Orders.SingleOrDefault(o => o.OrderId == id);
            if(order != null)
            {
                return View("Order", new OrderViewModel 
                {
                    Order = order,
                    DisplayMode = OrderDisplayMode.Show
                });
            }
            else
            {
                return NoContent();
            }
        }
        public IActionResult Create()
        {
            return View("Order", new OrderViewModel { DisplayMode = OrderDisplayMode.Create });
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            if(ModelState.IsValid)
            {
                _orderRepository.SaveOrder(order);
				return RedirectToAction("Completed", new { orderID = order.OrderId });
			}
            else
            {
                return View("Order", new OrderViewModel
                {
                    Order = order,
                    DisplayMode = OrderDisplayMode.Create
                });
            }
        }
        public IActionResult Completed(long orderID)
        {
            return View(orderID);
        }
    }
}

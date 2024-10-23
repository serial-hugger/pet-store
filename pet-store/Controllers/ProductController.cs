using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using pet_store.Data;

namespace pet_store.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class ProductController : ControllerBase
    {
        private readonly IProductLogic _productLogic;
        public ProductController(IProductLogic productLogic)
        {
            _productLogic = productLogic;
        }
        [HttpGet("{action}/{id}")]
        public IActionResult GetProduct(int id)
        {
            return new JsonResult(_productLogic.GetProductByIdAsync(id));
        }
        [HttpGet("{action}/{orderId}")]
        public IActionResult GetOrder(int orderId)
        {
            return new JsonResult(_productLogic.GetOrderByIdAsync(orderId));
        }
    }
}
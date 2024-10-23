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
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _productLogic.GetProductByIdAsync(id);
            return new JsonResult(result);
        }
        [HttpGet("{action}/{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            var result = await _productLogic.GetOrderByIdAsync(orderId);
            return new JsonResult(result);
        }
    }
}
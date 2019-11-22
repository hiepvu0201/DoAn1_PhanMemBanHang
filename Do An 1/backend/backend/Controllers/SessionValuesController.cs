using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace backend.Controllers
{
    [Route("/api/session")]
    [ApiController]
    public class SessionValuesController : Controller
    {
        [HttpGet("cart")]
        public IActionResult GetCart()
        {
            return Ok(HttpContext.Session.GetString("cart"));
        }
        [HttpPost("cart")]
        public void StoreCart([FromBody] ProductSelection[] products)
        {
            var jsonData = JsonConvert.SerializeObject(products);
            HttpContext.Session.SetString("cart", jsonData);
        }
    }
}
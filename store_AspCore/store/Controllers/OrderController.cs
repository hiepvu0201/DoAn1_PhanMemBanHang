using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Models;
using store.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepo;

        public OrderController(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpGet]
        public async Task<List<Order>> GetAll()
        {
            return await _orderRepo.GetOrders();
        }

        [HttpGet("options")]
        public async Task<List<Order>> GetAllOptions([FromHeader] QueryOptions options)
        {
            return await _orderRepo.GetOrderOptions(options);
        }

        [HttpGet("{orderId}")]
        public async Task<List<CutomerOrder>> GetDetail(long orderId)
        {
            return await _orderRepo.GetOrder(orderId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Bill bill)
        {
            await _orderRepo.CreateOrder(bill);
            return Ok(1);
        }
    }
}

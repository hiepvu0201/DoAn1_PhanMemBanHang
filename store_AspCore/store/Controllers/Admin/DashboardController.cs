using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Controllers.Admin
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController: Controller
    {
        private readonly DataContext _context;
        public DashboardController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("catalogs")]
        public async Task<int> GetCatalogCount()
        {
            return await _context.Catalogs.CountAsync();
        }

        [HttpGet("products")]
        public async Task<int> GetProductCount()
        {
            return await _context.Products.CountAsync();
        }

        [HttpGet("categories")]
        public async Task<int> GetCategoryCount()
        {
            return await _context.Categories.CountAsync();
        }

        [HttpGet("posts")]
        public async Task<int> GetPostCount()
        {
            return await _context.Posts.CountAsync();
        }

        [HttpGet("orders")]
        public async Task<int> GetOrderCount()
        {
            return await _context.Orders.CountAsync();
        }

        [HttpGet("totalPrice")]
        public async Task<decimal> GetTotalPriceOrder()
        {
            var model = await _context.OrderDetails.Include(o => o.Product).ToListAsync();

            decimal totalPrice = 0;
            foreach(var m in model)
            {
                totalPrice += m.Quantity * m.Product.Price;
            }
            return totalPrice;
        }
    }
}

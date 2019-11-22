using System;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController:Controller
    {

        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("cart")]
        public async Task<IActionResult> CreateCart([FromBody] ProductSelection[] products)
        {
            int CustomerId = _context.Customers.Count();

            Orders orders = new Orders
            {
                OrderDate = DateTime.Now,
                Customer = CustomerId == 0 ? null : new Customer { Id = CustomerId }
            };
            if (orders.Customer != null && orders.Customer.Id != 0)
            {
                _context.Attach(orders.Customer);
            }

            await _context.Orders.AddAsync(orders);
            await _context.SaveChangesAsync();


            int OrderId = orders.Id;

            foreach (ProductSelection p in products)
            {

                OrderDetails orderDetails = new OrderDetails
                {
                    ProductID = p.id,
                    OrdersID = OrderId,
                    Quantity = p.quantity,
                };

                await _context.OrderDetails.AddAsync(orderDetails);
                await _context.SaveChangesAsync();
            }

            return Ok(1);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Customer customer)
        {
            Console.WriteLine(customer.Name);
            Customer customer1 = new Customer
            {
                Name = customer.Name,
                Phone = customer.Phone,
                Email = customer.Email,
                Address = customer.Address,
                City = customer.City,
                Note = customer.Note,
                CreatedAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            await _context.Customers.AddAsync(customer1);
            await _context.SaveChangesAsync();
          
            return Ok(customer1.Id);
        }
    }
}

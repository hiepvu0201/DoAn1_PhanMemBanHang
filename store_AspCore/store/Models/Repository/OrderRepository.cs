using Microsoft.EntityFrameworkCore;
using store.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateOrder(Bill bill)
        {
            Customer customer = new Customer
            {
                FirstName = bill.Customer.FirstName,
                LastName = bill.Customer.LastName,
                Phone = bill.Customer.Phone,
                Email = bill.Customer.Email,
                Address = bill.Customer.Address,
                City = bill.Customer.City,
                Note = bill.Customer.Note,
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            Order order = new Order
            {
                OrderDate = DateTime.Now,
                CustomerId = customer.Id
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();


            var productSelections = bill.ProductSelections;
            foreach (ProductSelection p in productSelections)
            {

                OrderDetail orderDetails = new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = p.Id,
                    Quantity = p.quantity,
                };

                await _context.OrderDetails.AddAsync(orderDetails);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CutomerOrder>> GetOrder(long orderId)
        {
            var model = (from o in _context.Orders
                         join c in _context.Customers on o.CustomerId equals c.Id
                         join od in _context.OrderDetails on c.Id equals od.OrderId
                         where o.Id == orderId
                         select new CutomerOrder
                         {
                             FirstName = c.FirstName,
                             LastName = c.LastName,
                             Phone = c.Phone,
                             Email = c.Email,
                             Address = c.Address,
                             City = c.City,
                             OrderDate = o.OrderDate,
                             OrderId = o.Id,
                             product = od.Product,
                             Quantity = od.Quantity
                         });

            return await model.ToListAsync();
        }

        public async Task<List<Order>> GetOrderOptions(QueryOptions options)
        {
            return await QueryOptionsRepository<Order>.CreateAsync(_context.Orders.Include(o => o.Customer), options);
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders.Include(o => o.Customer).ToListAsync();
        }
    }
}

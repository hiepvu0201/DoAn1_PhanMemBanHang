using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models.IRepository
{
    public interface IOrderRepository
    {
        Task CreateOrder(Bill bill);
        Task<List<Order>> GetOrders();
        Task<List<CutomerOrder>> GetOrder(long orderId);
        Task<List<Order>> GetOrderOptions(QueryOptions options);
    }
}

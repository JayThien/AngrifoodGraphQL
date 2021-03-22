using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Entities;
using WebApplication2.Interfaces;

namespace WebApplication2.Services
{
    public class OrderService : IOrderService
    {
        private readonly CustomerDbContext customerDbContext;

        public OrderService(CustomerDbContext customerDbContext)
        {
            this.customerDbContext = customerDbContext;
        }
        public async Task<List<Order>> GetOrdersByCustomerId(int id)
        {
            var orders = await customerDbContext.Orders.Where(order => order.CustomerId == id).ToListAsync();

            return orders;
        }
    }
}

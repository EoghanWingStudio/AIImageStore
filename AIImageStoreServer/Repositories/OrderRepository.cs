using AIImageStoreServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AIImageStoreServer.Repositories
{
    public interface IOrderRepository
    {
        Task<Boolean> AddOrder(Order order);
        Task<Boolean> UpdateOrder(Order id);
        Task<Boolean> DeleteOrder(int id);
        Task<Order> GetOrderById(int id);

    }
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderRepository _orderRepository;
        private readonly RepositoryDBContext _dbContext;
        public OrderRepository(IOrderRepository orderRepository, RepositoryDBContext dbContext)
        {
            _orderRepository = orderRepository;
            _dbContext = dbContext;
        }

        public async Task<Boolean> AddOrder(Order order)
        {
            var orderAdded = await _dbContext.AddAsync(order);

            if (orderAdded != null)
                return true;
            return false;

        }

        public async Task<Boolean> DeleteOrder(int id)
        {
            var order = await _dbContext.Orders.SingleOrDefaultAsync(o => o.OrderId == id);

            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                return true;

            }
            return false;
            
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _dbContext.Orders.SingleOrDefaultAsync(o => o.OrderId == id);

            
        }

        public async Task<Boolean> UpdateOrder(Order order)
        {
            var previousOrder = await _dbContext.Orders.FindAsync(order.OrderId);
            if (previousOrder != null)
            {
                previousOrder = order;
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}

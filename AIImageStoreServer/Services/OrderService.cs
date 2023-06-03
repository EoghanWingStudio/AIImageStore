using AIImageStoreServer.Models;
using AIImageStoreServer.Repositories;

namespace AIImageStoreServer.Services
{
    public interface IOrderService
    {
        Task<Order?> GetOrderAsync(int id);
        Task<bool> DeleteOrderAsync(int id);
        Task<Order?> CreateOrderAsync(int userId);
        Task<Order?> UpdateOrderAsync(int orderId);
    }
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<Order?> CreateOrderAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> UpdateOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}

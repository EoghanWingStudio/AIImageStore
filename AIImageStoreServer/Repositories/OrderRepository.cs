using AIImageStoreServer.Models;

namespace AIImageStoreServer.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder();
        Task<Order> UpdateOrder();
        Task<Order> DeleteOrder(int id);
        Task<Order> GetOrderById(int id);

    }
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderRepository _orderRepository;
        public OrderRepository(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<Order> AddOrder()
        {
            throw new NotImplementedException();
        }

        public async Task<Order?> DeleteOrder(int id)
        {
            var order  = await _orderRepository.DeleteOrderAsync(id);
            if (order != null) 
                return order;

            return null;
            
        }

        public async Task<Order?> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            
            if(order != null) 
                return order;

            return null;
        }

        public Task<Order> UpdateOrder()
        {
            throw new NotImplementedException();
        }
    }
}

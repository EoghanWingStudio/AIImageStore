using AIImageStoreServer.Models;

namespace AIImageStoreServer.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> CreateCart(int userId);
        Task<Cart> AddToCart(Product product, Cart cart);

        Task<Cart> DeleteCart(Cart cart);  

    }
    public class CartRepository
    {
        private readonly
            AiImageStoreContext _context;

        public CartRepository(AiImageStoreContext context)
        {
            _context = context;
        }

        public async Task<Cart> CreateCart(int userId)
        {
            var cart = new Cart { UserId = userId };
            await _context.Carts.AddAsync(cart);
            return cart;
        }

        public async Task<Cart> AddToCart(Cart cart)
        {
            var updatedCart = cart;
            return updatedCart;

        }
    }
}

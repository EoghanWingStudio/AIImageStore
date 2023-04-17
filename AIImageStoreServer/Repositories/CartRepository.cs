using AIImageStoreServer.Models;

namespace AIImageStoreServer.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> CreateCart(int userId);
        Task<Cart> AddToCart(Product product, Cart cart);

        Task<Boolean> DeleteCart(Cart cart);  

    }
    public class CartRepository: ICartRepository
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

        public async Task<Cart> AddToCart(Product product, Cart cart)
        {
            var updatedCart = cart;
            return updatedCart;

        }

        public async Task<Boolean> DeleteCart(Cart cart)
        {
           var cartInfo = await _context.Carts.FindAsync(cart.CartId);

            if(cartInfo != null)
            {
                _context.Carts.Remove(cartInfo);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

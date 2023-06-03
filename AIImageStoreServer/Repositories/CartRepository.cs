using AIImageStoreServer.Models;

namespace AIImageStoreServer.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> CreateCart(int userId);
        Task<Cart?> UpdateCart(Cart cart);

        Task<Boolean> DeleteCart(Cart cart);
        Task<Cart?> GetCartByIdAsync(int id);
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

        public async Task<Cart?> UpdateCart(Cart cart)
        {
            var cartInfo = await _context.Carts.FindAsync(cart.CartId);
            if (cartInfo != null)
            {
                cartInfo = cart;
                _context.Carts.Update(cartInfo);
                await _context.SaveChangesAsync();
                return cartInfo;
            }
            return null;

        }

        public async Task<bool> DeleteCart(Cart cart)
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

        public async Task<Cart?> GetCartByIdAsync(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            return cart;

        }
    }
}

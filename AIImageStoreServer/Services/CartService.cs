
using AIImageStoreServer.Models;
using AIImageStoreServer.Repositories;

namespace AIImageStoreServer.Services
{
    public interface ICartService
    {
        Task<Cart?> GetCartByIdAsync(int id);
        Task<Cart?> CreateCartAsync(int userId);
        Task<Cart?> UpdateCartAsync(Cart cart);   
        Task<bool> DeleteCartAsync(Cart cart);
        Task<Cart?> AddToCartAsync(int productId, Cart updatedCart);
        Task<Cart?> RemoveFromCartAsync(int productId, Cart updatedCart);

    }
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<Cart?> CreateCartAsync(int userId)
        {
            var newCart = await _cartRepository.CreateCart(userId);

            return newCart;
        }

        public async Task<bool> DeleteCartAsync(Cart cart)
        {
            var cartDeleted = await _cartRepository.DeleteCart(cart);  

            return cartDeleted;
        }

        public async Task<Cart?> GetCartByIdAsync(int id)
        {
            var cart = await _cartRepository.GetCartByIdAsync(id);
            return cart;
        }

        public async Task<Cart?> AddToCartAsync(int productId, Cart updatedCart)
        {
            var cart = await _cartRepository.GetCartByIdAsync(productId);
            // get product from product repo

            await _cartRepository.UpdateCart(cart);
            return cart;
        }
        public async Task<Cart?> RemoveFromCartAsync(int productId, Cart updatedCart)
        {
            var cart = await _cartRepository.GetCartByIdAsync(productId);
            // get product from product repo

            await _cartRepository.UpdateCart(cart);
            return cart;
        }
        public async Task<Cart?> UpdateCartAsync(Cart cart)
        {
            var updatedCart = await _cartRepository.UpdateCart(cart);
            return updatedCart;
        }
    }
}

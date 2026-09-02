using Basket.Application.Responses;
using Basket.Core.Entities;

namespace Basket.Application.Mappers
{
    public static class BasketMapper
    {   
        public static ShoppingCartResponse ToResponse(this ShoppingCart shoppingCart)
        {
            return new ShoppingCartResponse
            {
                UserName = shoppingCart.UserName,
                Items = shoppingCart.Items.Select(item => new ShoppingCartItemResponses
                {
                    Quantity = item.Quantity,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ImageFile = item.ImageFile
                }).ToList()
            };
        }
        
        // Delegate based mapper
        public static ShoppingCartResponse ToResponseUsingDelegate(this ShoppingCart cart) 
            => MapCart(cart);

        public static readonly Func<ShoppingCart, ShoppingCartResponse> MapCart = 
        cart => new ShoppingCartResponse
        {
            UserName = cart.UserName,
            Items = cart.Items.Select(item => new ShoppingCartItemResponses
            {
                Quantity = item.Quantity,
                Price = item.Price,
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                ImageFile = item.ImageFile
            }).ToList()
        };
    }
}
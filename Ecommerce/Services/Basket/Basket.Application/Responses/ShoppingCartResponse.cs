namespace Basket.Application.Responses
{
    public record class ShoppingCartResponse
    {
        public string UserName { get; init; }
        public List<ShoppingCartItemResponses> Items { get; init; } = new List<ShoppingCartItemResponses>();
        public ShoppingCartResponse()
        {
            UserName = string.Empty;
            Items = new List<ShoppingCartItemResponses>();
        }

        // ctor with username only
        public ShoppingCartResponse(string userName) : this(userName, new List<ShoppingCartItemResponses>())
        {
            
        }
        
        // Fulll ctor with username and items
        public ShoppingCartResponse(string userName, List<ShoppingCartItemResponses> items)
        {
            UserName = userName;
            Items = items ?? new List<ShoppingCartItemResponses>();
        }
        
        public decimal TotalPrice => Items.Sum(item => item.Price * item.Quantity);
        
            
        
        
    }
}
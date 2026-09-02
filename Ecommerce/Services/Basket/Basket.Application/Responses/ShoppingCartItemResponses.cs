namespace Basket.Application.Responses
{
    public record class ShoppingCartItemResponses
    {
        public int Quantity { get; init; }
        public string ImageFile { get; init; }
        public decimal Price { get; init; }
        public string ProductId { get; init; }  
        public string ProductName { get; init; }
        
    }
}
namespace Basket.Application.DTOs
{
    public record ShoppingCartDtos
    (
        string userName,
        List<ShoppingCartItemDto> Items,
        decimal TotalPrice

    );

    public record ShoppingCartItemDto
    (
        string ProductId ,
        string ProductName ,
        decimal Price ,
        int Quantity
    );

    public record CreateShoppingCartItemDto
    (
        string ProductId,
        string ProductName,
        decimal Price,
        int Quantity,
        string ImageFile

    );

    public record BasketCheckoutDto(
            string UserName,
            decimal TotalPrice,
            string FirstName,
            string LastName,
            string EmailAddress,
            string AddressLine,
            string Country,
            string State,
            string ZipCode,
            string CardName,
            string CardNumber,
            string Expiration,
            string Cvv,
            int PaymentMethod
        );
}
namespace StoreBook.Api.Contracts
{
    public record BookRespons(
        Guid Id,
        string Title,
        string Description,
        decimal Price
        );
}

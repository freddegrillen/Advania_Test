namespace Advania_Test.Domain.Contracts;

    public record AddProductRequest(
        string Name,
        string Category,
        string? Color,
        decimal Price
    );

    public record ProductResponse(
        string Name,
        string Category,
        string? Color,
        decimal Price
        );


namespace Advania_Test.Domain.Contracts;

    public record AddProductRequest(
        string Name,
        string? Color,
        decimal Price
    );

    public record ProductResponse(
        int Id,
        string Name,
        string? Color,
        decimal Price
        );


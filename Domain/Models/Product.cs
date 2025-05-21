
namespace Advania_Test.Domain.Models
{
    public sealed class Product
    {
        public required string Category { get; set; }
        public required string Name { get; set; }
        public string? Color { get; set; }
        public decimal Price { get; set; }
    }
}

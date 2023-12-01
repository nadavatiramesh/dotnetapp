using System.ComponentModel.DataAnnotations;

namespace e_commerce.API.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal ActualCost { get; set; }

        public string Category { get; set; }

        public string? Description { get; set; }

        public string? Color { get; set; }

        public string? ImageLink { get; set; }
        public int UserId { get; set; }
    }
}

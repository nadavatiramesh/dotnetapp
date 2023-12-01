using System;
using System.Collections.Generic;

namespace e_commerce.API.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public decimal ActualCost { get; set; }

    public string? Category { get; set; }

    public string? Description { get; set; }

    public string? Color { get; set; }

    public string? ImageLink { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime UpdatedOn { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}

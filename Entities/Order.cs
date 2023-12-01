using System;
using System.Collections.Generic;

namespace e_commerce.API.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public string? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}

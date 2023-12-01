using System;
using System.Collections.Generic;

namespace e_commerce.API.Entities;

public partial class Seller
{
    public int SellerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public string? Passcode { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
}

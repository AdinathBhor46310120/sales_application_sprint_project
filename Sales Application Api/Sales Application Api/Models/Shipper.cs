using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Application_Api.Models;

public partial class Shipper 
{
    [Key]
    public int ShipperId { get; set; }

    [Required]
    public string CompanyName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

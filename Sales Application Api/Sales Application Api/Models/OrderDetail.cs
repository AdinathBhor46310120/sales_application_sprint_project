using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Application_Api.Models;

public partial class OrderDetail
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public decimal UnitPrice { get; set; }

    [Required]
    public short Quantity { get; set; }

    [Required]
    public float Discount { get; set; }

    [Required]
    public virtual Order Order { get; set; } = null!;

    [Required]
    public virtual Product Product { get; set; } = null!;
}

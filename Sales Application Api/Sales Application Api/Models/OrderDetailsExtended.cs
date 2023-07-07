using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Application_Api.Models;

public partial class OrderDetailsExtended
{
    //[Key]
    public int OrderId { get; set; }

    
    public int ProductId { get; set; }

   
    public string ProductName { get; set; } = null!;

    
    public decimal UnitPrice { get; set; }

    
    public short Quantity { get; set; }

   
    public float Discount { get; set; }

   
    public decimal? ExtendedPrice { get; set; }
}

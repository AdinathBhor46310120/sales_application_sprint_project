using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Sales_Application_Api.Models;

public partial class CurrentProductList
{
    [System.ComponentModel.DataAnnotations.Key]
    public int ProductId { get; set; }

    [Required]
    public string ProductName { get; set; } = null!;
}

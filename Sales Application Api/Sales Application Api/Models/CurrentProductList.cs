using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Sales_Application_Api.Models;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}

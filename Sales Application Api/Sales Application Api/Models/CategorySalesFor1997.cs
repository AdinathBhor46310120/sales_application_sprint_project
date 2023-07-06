using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Application_Api.Models;

public partial class CategorySalesFor1997
{
    [Required]
    public string CategoryName { get; set; } = null!;

    [Required]
    public decimal? CategorySales { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Application_Api.Models;

public partial class CategorySalesFor1997
{
    public string CategoryName { get; set; } = null!;

    public decimal? CategorySales { get; set; }
}

using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;

namespace Sales_Application_Api.Models;

public partial class CustomerAndSuppliersByCity
{
    [Required]
    public string? City { get; set; }

    [Required]
    public string CompanyName { get; set; } = null!;

    [Required]
    public string? ContactName { get; set; }

    [Required]
    public string Relationship { get; set; } = null!;
}

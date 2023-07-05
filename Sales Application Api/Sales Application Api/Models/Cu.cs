using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;

namespace Sales_Application_Api.Models;

public partial class Cu
{
    [Required]
    public string? Region { get; set; }

    [Required]
    public string? Postalcode { get; set; }

    [Required]
    public string? Country { get; set; }
}

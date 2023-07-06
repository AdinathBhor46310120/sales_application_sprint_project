using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Sales_Application_Api.Models;

public partial class MyView
{
    public string CompanyName { get; set; } = null!;
    public string? City { get; set; }
}

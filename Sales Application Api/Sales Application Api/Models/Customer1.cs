//using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Application_Api.Models;

public partial class Customer1
{
    [Key]
    public string CustomerId { get; set; } = null!;

    [Required]
    public string CompanyName { get; set; } = null!;

    [Required]
    public string? ContactName { get; set; }

    [Required]
    public string? ContactTitle { get; set; }

    [Required]
    public string? Address { get; set; }

    [Required]
    public string? City { get; set; }

    [Required]
    public string? Region { get; set; }

    [Required]
    public string? PostalCode { get; set; }

    [Required]
    public string? Country { get; set; }

    [Required]
    public string? Phone { get; set; }

    [Required]
    public string? Fax { get; set; }

    //[Required]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<CustomerDemographic> CustomerTypes { get; set; } = new List<CustomerDemographic>();
}

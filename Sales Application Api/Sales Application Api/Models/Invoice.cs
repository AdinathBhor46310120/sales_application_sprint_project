using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Application_Api.Models;

public partial class Invoice
{
    [Required]
    public string? ShipName { get; set; }

    [Required]
    public string? ShipAddress { get; set; }

    [Required]
    public string? ShipCity { get; set; }

    [Required]
    public string? ShipRegion { get; set; }

    [Required]
    public string? ShipPostalCode { get; set; }

    [Required]
    public string? ShipCountry { get; set; }

    [Required]
    public string? CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

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

    public string Salesperson { get; set; } = null!;

    [Key]
    public int OrderId { get; set; }

    [Required]
    public DateTime? OrderDate { get; set; }

    [Required]
    public DateTime? RequiredDate { get; set; }

    [Required]
    public DateTime? ShippedDate { get; set; }

    public string ShipperName { get; set; } = null!;

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    [Key]
    public decimal UnitPrice { get; set; }

    [Key]
    public short Quantity { get; set; }

    [Key]
    public float Discount { get; set; }

    [Required]
    public decimal? ExtendedPrice { get; set; }

    [Required]
    public decimal? Freight { get; set; }
}

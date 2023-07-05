using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Application_Api.Models;

public partial class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    public string? CustomerId { get; set; }

    [Required]
    public int? EmployeeId { get; set; }

    [Required]
    public DateTime? OrderDate { get; set; }

    [Required]
    public DateTime? RequiredDate { get; set; }

    [Required]
    public DateTime? ShippedDate { get; set; }

    [Required]
    public int? ShipVia { get; set; }

    [Required]
    public decimal? Freight { get; set; }

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
    public virtual Customer1? Customer { get; set; }

    [Required]
    public virtual Employee? Employee { get; set; }

    //[Required]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    //[Required]
    public virtual Shipper? ShipViaNavigation { get; set; }
}

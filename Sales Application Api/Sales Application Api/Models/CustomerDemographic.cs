using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Application_Api.Models;

public partial class CustomerDemographic
{
    public string CustomerTypeId { get; set; } = null!;

    public string? CustomerDesc { get; set; }

    public virtual ICollection<Customer1> Customers { get; set; } = new List<Customer1>();
}

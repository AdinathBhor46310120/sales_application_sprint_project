using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Application_Api.Models;

public partial class Territory
{
    [Key]
    public string TerritoryId { get; set; } = null!;

    [Required]
    public string TerritoryDescription { get; set; } = null!;

    [Required]
    public int RegionId { get; set; }

    public virtual Region Region { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

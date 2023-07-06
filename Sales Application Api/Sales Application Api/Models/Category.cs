using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Application_Api.Models;

public partial class Category
{
    [Key]
   // [Required]
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; } = null!;

    [Required]
    public string? Description { get; set; }

    [Required]
    public byte[]? Picture { get; set; }

    [Required]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

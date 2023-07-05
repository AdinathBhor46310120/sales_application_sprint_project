using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Application_Api.Models;

public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? TitleOfCourtesy { get; set; }

    [Required]
    public DateTime? BirthDate { get; set; }

    [Required]
    public DateTime? HireDate { get; set; }

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
    public string? HomePhone { get; set; }

    [Required]
    public string? Extension { get; set; }

    [Required]
    public byte[]? Photo { get; set; }

    [Required]
    public string? Notes { get; set; }

    [Required]
    public int? ReportsTo { get; set; }

    [Required]
    public string? PhotoPath { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required]
    public string? Role { get; set; }

   // [Required]
    public virtual ICollection<Employee> InverseReportsToNavigation { get; set; } = new List<Employee>();

    //[Required]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    
    public virtual Employee? ReportsToNavigation { get; set; }

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}

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

    public string? Title { get; set; }

<<<<<<< HEAD
=======

>>>>>>> 3a6f3f4cb2554db077b20d12d6b814e3c1eba803
    public string? TitleOfCourtesy { get; set; }

    public DateTime? BirthDate { get; set; }

    public DateTime? HireDate { get; set; }

<<<<<<< HEAD

    public string? Address { get; set; }


    public string? City { get; set; }


    public string? Region { get; set; }


    public string? PostalCode { get; set; }


    public string? Country { get; set; }


    public string? HomePhone { get; set; }
=======
    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? HomePhone { get; set; }

>>>>>>> 3a6f3f4cb2554db077b20d12d6b814e3c1eba803
    public string? Extension { get; set; }

    public byte[]? Photo { get; set; }

    public string? Notes { get; set; }

    public int? ReportsTo { get; set; }

    public string? PhotoPath { get; set; }

<<<<<<< HEAD
 
=======
>>>>>>> 3a6f3f4cb2554db077b20d12d6b814e3c1eba803
    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }
<<<<<<< HEAD

=======
>>>>>>> 3a6f3f4cb2554db077b20d12d6b814e3c1eba803
    public virtual ICollection<Employee> InverseReportsToNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Employee? ReportsToNavigation { get; set; }
    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}

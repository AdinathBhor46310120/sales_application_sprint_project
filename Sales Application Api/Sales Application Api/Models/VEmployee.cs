using System;
using System.Collections.Generic;

namespace Sales_Application_Api.Models;

public partial class VEmployee
{
    public int EmployeeId { get; set; }

    public string FullName { get; set; } = null!;

    public int? ReportsTo { get; set; }
}

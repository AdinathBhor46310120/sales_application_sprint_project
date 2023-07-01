using System;
using System.Collections.Generic;

namespace Sales_Application_Api.Models;

public partial class Tblrating
{
    public string? Empid { get; set; }

    public int? Score { get; set; }

    public string? Decriptiption { get; set; }
}

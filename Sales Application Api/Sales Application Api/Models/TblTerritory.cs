using System;
using System.Collections.Generic;

namespace Sales_Application_Api.Models;

public partial class TblTerritory
{
    public string? TId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Territory? TIdNavigation { get; set; }
}

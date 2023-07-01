using System;
using System.Collections.Generic;

namespace Sales_Application_Api.Models;

public partial class PurchaseOrder
{
    public int Poid { get; set; }

    public int? Cid { get; set; }

    public DateTime? Poidate { get; set; }

    public virtual Customer? CidNavigation { get; set; }
}

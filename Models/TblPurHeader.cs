using System;
using System.Collections.Generic;

namespace Purchase_Order.Models;

public partial class TblPurHeader
{
    public int PurHeaderId { get; set; }

    public string? PurReference { get; set; }

    public int VendorId { get; set; }

    public DateTime PurCreatedDate { get; set; }

    public DateTime? PurExpectedArrivalDate { get; set; }

    public string? PurSourceReference { get; set; }

    public decimal? PurAmountExclVat { get; set; }

    public decimal? PurAmountVat { get; set; }

    public decimal? PurAmountInclVat { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<TblPurDetail> TblPurDetails { get; } = new List<TblPurDetail>();

    public virtual TblVendor Vendor { get; set; } = null!;
}

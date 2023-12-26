using System;
using System.Collections.Generic;

namespace Purchase_Order.Models;

public partial class TblPurDetail
{
    public int PurDetailId { get; set; }

    public int PurHeaderId { get; set; }

    public int PurMatId { get; set; }

    public DateTime PurExpectedArrivalDate { get; set; }

    public int PurQty { get; set; }

    public int? PurUoM { get; set; }

    public decimal? PurUnitPrice { get; set; }

    public decimal? PurAmountExclVat { get; set; }

    public decimal? PurAmountVat { get; set; }

    public decimal? PurAmountInclVat { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual TblPurHeader PurHeader { get; set; } = null!;

    public virtual TblMaterial PurMat { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Purchase_Order.Models;

public partial class TblMaterial
{
    public int MatId { get; set; }

    public string MatRef { get; set; } = null!;

    public string MatDesc { get; set; } = null!;

    public string MatUom { get; set; } = null!;

    public decimal MatStandardCost { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual ICollection<TblPurDetail> TblPurDetails { get; } = new List<TblPurDetail>();
}

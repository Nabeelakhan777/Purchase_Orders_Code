using System;
using System.Collections.Generic;

namespace Purchase_Order.Models;

public partial class TblVendor
{
    public int VendorId { get; set; }

    public string Name { get; set; } = null!;

    public string? Tel { get; set; }

    public string? ExtAccNo { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? Contact { get; set; }

    public string? Street { get; set; }

    public string? Suburb { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Vatno { get; set; }

    public string? RegNo { get; set; }

    public decimal? Vatperc { get; set; }

    public virtual ICollection<TblPurHeader> TblPurHeaders { get; } = new List<TblPurHeader>();
}

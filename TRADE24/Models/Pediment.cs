using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class Pediment
{
    public string Pedimento { get; set; } = null!;

    public decimal? Fraccion { get; set; }

    public int? Qty { get; set; }

    public string? Date { get; set; }
}

using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class GeneralDatum
{
    public string CodeId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }
}

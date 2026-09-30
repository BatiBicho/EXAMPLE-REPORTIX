using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class MaCode
{
    public string Class { get; set; } = null!;

    public string ParentId { get; set; } = null!;

    public string CodeId { get; set; } = null!;

    public string? DescriptionEn { get; set; }

    public string? DescriptionSp { get; set; }

    public string? DescriptionKo { get; set; }

    public int? Sort { get; set; }

    public bool IsDisabled { get; set; }

    public string? DisabledReason { get; set; }

    public string CreatedDate { get; set; } = null!;

    public string CreatedTime { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string? LastUpdatedDate { get; set; }

    public string? LastUpdatedTime { get; set; }

    public string? LastUpdatedBy { get; set; }
}

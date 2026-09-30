using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class SyPrivacyPolicy
{
    public int VersionId { get; set; }

    public string? DescriptionEn { get; set; }

    public string? DescriptionSp { get; set; }

    public string? DescriptionKo { get; set; }

    public string CreatedDate { get; set; } = null!;

    public string CreatedTime { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;
}

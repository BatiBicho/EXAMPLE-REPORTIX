using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class SyMenu
{
    public int MenuId { get; set; }

    public int? ParentId { get; set; }

    public string? DisplayTextEn { get; set; }

    public string? DisplayTextSp { get; set; }

    public string? DisplayTextKo { get; set; }

    public string? DescriptionEn { get; set; }

    public string? DescriptionSp { get; set; }

    public string? DescriptionKo { get; set; }

    public string? ActionName { get; set; }

    public string? ControllerName { get; set; }

    public string? Area { get; set; }

    public string? Url { get; set; }

    public short ItemLevel { get; set; }

    public short ItemOrder { get; set; }

    public bool OpenNewWindow { get; set; }

    public string? NewWindowFeatures { get; set; }

    public string? IconName { get; set; }

    public string? PageId { get; set; }

    public bool IsDisabled { get; set; }

    public string CreatedDate { get; set; } = null!;

    public string CreatedTime { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string? LastUpdatedDate { get; set; }

    public string? LastUpdatedTime { get; set; }

    public string? LastUpdatedBy { get; set; }
}

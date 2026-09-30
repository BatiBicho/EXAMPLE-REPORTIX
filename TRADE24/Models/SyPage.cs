using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class SyPage
{
    public string PageId { get; set; } = null!;

    public string? PageName { get; set; }

    public string? PageType { get; set; }

    public string? ModuleId { get; set; }

    public string? Path { get; set; }

    public string? Status { get; set; }

    public string? LastUpdatedDate { get; set; }

    public string? LastUpdatedTime { get; set; }

    public string? LastUpdatedBy { get; set; }

    public string CreatedDate { get; set; } = null!;

    public string CreatedTime { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;
}

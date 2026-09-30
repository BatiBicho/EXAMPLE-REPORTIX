using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class SyModule
{
    public string ModuleId { get; set; } = null!;

    public string? ModuleName { get; set; }

    public string? ModuleDescription { get; set; }

    public string? ModulePurpose { get; set; }

    public string? ModuleEffect { get; set; }

    public string? RequestUserId { get; set; }

    public string? Status { get; set; }

    public string? LastUpdatedDate { get; set; }

    public string? LastUpdatedTime { get; set; }

    public string? LastUpdatedBy { get; set; }

    public string CreatedDate { get; set; } = null!;

    public string CreatedTime { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;
}

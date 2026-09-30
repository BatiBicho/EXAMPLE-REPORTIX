using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class SyRole
{
    public string RoleId { get; set; } = null!;

    public string? RoleName { get; set; }

    public string? Status { get; set; }

    public string? LastUpdatedDate { get; set; }

    public string? LastUpdatedTime { get; set; }

    public string? LastUpdatedBy { get; set; }

    public string CreatedDate { get; set; } = null!;

    public string CreatedTime { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;
}

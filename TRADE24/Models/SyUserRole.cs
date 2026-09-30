using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class SyUserRole
{
    public string UserId { get; set; } = null!;

    public string RoleId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? LastUpdatedDate { get; set; }

    public string? LastUpdatedTime { get; set; }

    public string? LastUpdatedBy { get; set; }

    public string CreatedDate { get; set; } = null!;

    public string CreatedTime { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;
}

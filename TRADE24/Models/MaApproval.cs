using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class MaApproval
{
    public string PageId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string ApprovalId { get; set; } = null!;

    public string? Email { get; set; }

    public string? Division { get; set; }
}

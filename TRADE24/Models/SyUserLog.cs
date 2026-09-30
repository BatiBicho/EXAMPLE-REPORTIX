using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class SyUserLog
{
    public int UserLogId { get; set; }

    public string UserId { get; set; } = null!;

    public int LogTypeId { get; set; }

    public string CreatedDate { get; set; } = null!;

    public string CreatedTime { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;
}

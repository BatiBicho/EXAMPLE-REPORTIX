using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class SyLogConnection
{
    public int ConnectionCode { get; set; }

    public string UserId { get; set; } = null!;

    public string? UserIp { get; set; }

    public string LogDate { get; set; } = null!;

    public string LogTime { get; set; } = null!;

    public string? SessionId { get; set; }
}

using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class SyLogStatistic
{
    public int StatisticCode { get; set; }

    public int ConnectionCode { get; set; }

    public string PageId { get; set; } = null!;

    public string LogDate { get; set; } = null!;

    public string LogTime { get; set; } = null!;
}

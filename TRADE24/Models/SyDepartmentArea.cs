using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class SyDepartmentArea
{
    public int AreaId { get; set; }

    public int DepartmentId { get; set; }

    public string? DescriptionEn { get; set; }

    public string? DescriptionSp { get; set; }

    public string? DescriptionKo { get; set; }

    public string? NomenclatureEn { get; set; }

    public string? NomenclatureSp { get; set; }

    public string? NomenclatureKo { get; set; }

    public string? ManagerId { get; set; }

    public bool IsDisabled { get; set; }

    public string CreatedDate { get; set; } = null!;

    public string CreatedTime { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string? LastUpdatedDate { get; set; }

    public string? LastUpdatedTime { get; set; }

    public string? LastUpdatedBy { get; set; }
}

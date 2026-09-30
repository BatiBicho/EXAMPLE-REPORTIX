using System;
using System.Collections.Generic;

namespace TRADE24.Models;

public partial class SyUser
{
    public string UserId { get; set; } = null!;

    public string? UserName { get; set; }

    public string? UserLastName1 { get; set; }

    public string? UserLastName2 { get; set; }

    public string? Password { get; set; }

    public int? DepartmentId { get; set; }

    public int? DepartmentAreaId { get; set; }

    public string? Email { get; set; }

    public string? Status { get; set; }

    public string? UserType { get; set; }

    public string? PassChangeDate { get; set; }

    public string? PassChangeTime { get; set; }

    public Guid? ValidationCode { get; set; }

    public int? PassIncorrect { get; set; }

    public int? PrivacyVersionId { get; set; }

    public string? PrivacyAcceptDate { get; set; }

    public string? PrivacyAcceptTime { get; set; }

    public int? SecurityGuidelineAgree { get; set; }

    public string? SecurityGuidelineDate { get; set; }

    public string? SecurityGuidelineTime { get; set; }

    public string? LastUpdatedDate { get; set; }

    public string? LastUpdatedTime { get; set; }

    public string? LastUpdatedBy { get; set; }

    public string CreatedDate { get; set; } = null!;

    public string CreatedTime { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;
}

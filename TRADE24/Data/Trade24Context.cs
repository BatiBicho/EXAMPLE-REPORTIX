using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TRADE24.Models;

namespace TRADE24.Data;

public partial class Trade24Context : DbContext
{
    public Trade24Context(DbContextOptions<Trade24Context> options)
        : base(options)
    {
    }

    public virtual DbSet<GeneralDatum> GeneralData { get; set; }

    public virtual DbSet<MaApproval> MaApprovals { get; set; }

    public virtual DbSet<MaCode> MaCodes { get; set; }

    public virtual DbSet<Pediment> Pediments { get; set; }

    public virtual DbSet<SyDepartment> SyDepartments { get; set; }

    public virtual DbSet<SyDepartmentArea> SyDepartmentAreas { get; set; }

    public virtual DbSet<SyLogConnection> SyLogConnections { get; set; }

    public virtual DbSet<SyLogStatistic> SyLogStatistics { get; set; }

    public virtual DbSet<SyMenu> SyMenus { get; set; }

    public virtual DbSet<SyModule> SyModules { get; set; }

    public virtual DbSet<SyPage> SyPages { get; set; }

    public virtual DbSet<SyPrivacyPolicy> SyPrivacyPolicies { get; set; }

    public virtual DbSet<SyRole> SyRoles { get; set; }

    public virtual DbSet<SyRolePage> SyRolePages { get; set; }

    public virtual DbSet<SyUser> SyUsers { get; set; }

    public virtual DbSet<SyUserLog> SyUserLogs { get; set; }

    public virtual DbSet<SyUserRole> SyUserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GeneralDatum>(entity =>
        {
            entity.HasKey(e => e.CodeId);

            entity.ToTable("GENERAL_DATA");

            entity.Property(e => e.CodeId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("CODE_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<MaApproval>(entity =>
        {
            entity.HasKey(e => new { e.PageId, e.Status, e.UserId, e.ApprovalId });

            entity.ToTable("MA_APPROVAL");

            entity.Property(e => e.PageId)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ApprovalId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Division)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MaCode>(entity =>
        {
            entity.HasKey(e => new { e.Class, e.ParentId, e.CodeId });

            entity.ToTable("MA_CODE");

            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ParentId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CodeId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionEn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionKo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionSp)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DisabledReason)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pediment>(entity =>
        {
            entity.HasKey(e => e.Pedimento);

            entity.ToTable("PEDIMENTS");

            entity.Property(e => e.Pedimento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Date)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Fraccion).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<SyDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK_tDepartment");

            entity.ToTable("SY_DEPARTMENT");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionEn)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionKo)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionSp)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ManagerId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NomenclatureEn)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NomenclatureKo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NomenclatureSp)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SyDepartmentArea>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK_tDeptAreas");

            entity.ToTable("SY_DEPARTMENT_AREA");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionEn)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionKo)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionSp)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ManagerId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NomenclatureEn)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NomenclatureKo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NomenclatureSp)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SyLogConnection>(entity =>
        {
            entity.HasKey(e => e.ConnectionCode).HasName("PK_LOG_CONNECTION");

            entity.ToTable("SY_LOG_CONNECTION");

            entity.Property(e => e.LogDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.LogTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.SessionId)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserIp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UserIP");
        });

        modelBuilder.Entity<SyLogStatistic>(entity =>
        {
            entity.HasKey(e => e.StatisticCode).HasName("PK_LOG_STATISTICS");

            entity.ToTable("SY_LOG_STATISTIC");

            entity.Property(e => e.LogDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.LogTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PageId)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SyMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK_Menu");

            entity.ToTable("SY_MENU");

            entity.Property(e => e.ActionName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ControllerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionEn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionKo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionSp)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DisplayTextEn)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.DisplayTextKo)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.DisplayTextSp)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.IconName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.NewWindowFeatures)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PageId)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SyModule>(entity =>
        {
            entity.HasKey(e => e.ModuleId);

            entity.ToTable("SY_MODULE");

            entity.Property(e => e.ModuleId)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ModuleDescription).HasColumnType("ntext");
            entity.Property(e => e.ModuleEffect).HasColumnType("ntext");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ModulePurpose).HasColumnType("ntext");
            entity.Property(e => e.RequestUserId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SyPage>(entity =>
        {
            entity.HasKey(e => e.PageId).HasName("PK_SY_PAGE_1");

            entity.ToTable("SY_PAGE");

            entity.Property(e => e.PageId)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ModuleId)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.PageName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PageType)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Path)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SyPrivacyPolicy>(entity =>
        {
            entity.HasKey(e => e.VersionId);

            entity.ToTable("SY_PRIVACY_POLICY");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionEn).HasColumnType("ntext");
            entity.Property(e => e.DescriptionKo).HasColumnType("ntext");
            entity.Property(e => e.DescriptionSp).HasColumnType("ntext");
        });

        modelBuilder.Entity<SyRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("SY_ROLE");

            entity.Property(e => e.RoleId)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SyRolePage>(entity =>
        {
            entity.HasKey(e => new { e.PageId, e.RoleId }).HasName("PK_SY_ROLEPAGE");

            entity.ToTable("SY_ROLE_PAGE");

            entity.Property(e => e.PageId)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RoleId)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SyUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("SY_USER");

            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PassChangeDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.PassChangeTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PrivacyAcceptDate).HasMaxLength(8);
            entity.Property(e => e.PrivacyAcceptTime).HasMaxLength(6);
            entity.Property(e => e.PrivacyVersionId).HasColumnName("PrivacyVersionID");
            entity.Property(e => e.SecurityGuidelineDate).HasMaxLength(8);
            entity.Property(e => e.SecurityGuidelineTime).HasMaxLength(6);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.UserLastName1)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserLastName2)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SyUserLog>(entity =>
        {
            entity.HasKey(e => e.UserLogId).HasName("PK_SY_USERLog");

            entity.ToTable("SY_USER_LOG");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SyUserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("PK_SY_USERROLE");

            entity.ToTable("SY_USER_ROLE");

            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoleId)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedTime)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Test.Models.Mapping;

namespace Test.Models
{
    public partial class WYTraceCodeSystemContext : DbContext
    {
        static WYTraceCodeSystemContext()
        {
            Database.SetInitializer<WYTraceCodeSystemContext>(null);
        }

        public WYTraceCodeSystemContext()
            : base("Name=WYTraceCodeSystemContext")
        {
        }

        public DbSet<SysBadWordInfo> SysBadWordInfoes { get; set; }
        public DbSet<SysErrorLog> SysErrorLogs { get; set; }
        public DbSet<SysJobLevel> SysJobLevels { get; set; }
        public DbSet<SysMenu> SysMenus { get; set; }
        public DbSet<SysMenuFunction> SysMenuFunctions { get; set; }
        public DbSet<SysOrganization> SysOrganizations { get; set; }
        public DbSet<SysOrganizationType> SysOrganizationTypes { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysRolePermission> SysRolePermissions { get; set; }
        public DbSet<SysSetting> SysSettings { get; set; }
        public DbSet<SysSettingType> SysSettingTypes { get; set; }
        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<SysUserRole> SysUserRoles { get; set; }
        public DbSet<T_BottleBoxRelationship> T_BottleBoxRelationship { get; set; }
        public DbSet<T_OldDataErrorRecord> T_OldDataErrorRecord { get; set; }
        public DbSet<T_Product> T_Product { get; set; }
        public DbSet<T_ProductCategory> T_ProductCategory { get; set; }
        public DbSet<T_ProductRelationship> T_ProductRelationship { get; set; }
        public DbSet<T_ProductSpecification> T_ProductSpecification { get; set; }
        public DbSet<T_ProductVersions> T_ProductVersions { get; set; }
        public DbSet<T_ScanCodeRecord> T_ScanCodeRecord { get; set; }
        public DbSet<T_TraceCodeDetail> T_TraceCodeDetail { get; set; }
        public DbSet<T_TraceCodeImportRecord> T_TraceCodeImportRecord { get; set; }
        public DbSet<T_TraceCodes> T_TraceCodes { get; set; }
        public DbSet<T_UserLog> T_UserLog { get; set; }
        public DbSet<ViewProduct> ViewProducts { get; set; }
        public DbSet<ViewProductCategory> ViewProductCategories { get; set; }
        public DbSet<ViewSysJobLevel> ViewSysJobLevels { get; set; }
        public DbSet<ViewSysMenu> ViewSysMenus { get; set; }
        public DbSet<ViewSysOrganization> ViewSysOrganizations { get; set; }
        public DbSet<ViewSysSetting> ViewSysSettings { get; set; }
        public DbSet<ViewSysUser> ViewSysUsers { get; set; }
        public DbSet<ViewTraceCode> ViewTraceCodes { get; set; }
        public DbSet<ViewTraceCodeDetail> ViewTraceCodeDetails { get; set; }
        public DbSet<ViewTraceCodeDetailQR> ViewTraceCodeDetailQRs { get; set; }
        public DbSet<ViewTraceCodeDetailXT> ViewTraceCodeDetailXTs { get; set; }
        public DbSet<ViewUserLog> ViewUserLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SysBadWordInfoMap());
            modelBuilder.Configurations.Add(new SysErrorLogMap());
            modelBuilder.Configurations.Add(new SysJobLevelMap());
            modelBuilder.Configurations.Add(new SysMenuMap());
            modelBuilder.Configurations.Add(new SysMenuFunctionMap());
            modelBuilder.Configurations.Add(new SysOrganizationMap());
            modelBuilder.Configurations.Add(new SysOrganizationTypeMap());
            modelBuilder.Configurations.Add(new SysRoleMap());
            modelBuilder.Configurations.Add(new SysRolePermissionMap());
            modelBuilder.Configurations.Add(new SysSettingMap());
            modelBuilder.Configurations.Add(new SysSettingTypeMap());
            modelBuilder.Configurations.Add(new SysUserMap());
            modelBuilder.Configurations.Add(new SysUserRoleMap());
            modelBuilder.Configurations.Add(new T_BottleBoxRelationshipMap());
            modelBuilder.Configurations.Add(new T_OldDataErrorRecordMap());
            modelBuilder.Configurations.Add(new T_ProductMap());
            modelBuilder.Configurations.Add(new T_ProductCategoryMap());
            modelBuilder.Configurations.Add(new T_ProductRelationshipMap());
            modelBuilder.Configurations.Add(new T_ProductSpecificationMap());
            modelBuilder.Configurations.Add(new T_ProductVersionsMap());
            modelBuilder.Configurations.Add(new T_ScanCodeRecordMap());
            modelBuilder.Configurations.Add(new T_TraceCodeDetailMap());
            modelBuilder.Configurations.Add(new T_TraceCodeImportRecordMap());
            modelBuilder.Configurations.Add(new T_TraceCodesMap());
            modelBuilder.Configurations.Add(new T_UserLogMap());
            modelBuilder.Configurations.Add(new ViewProductMap());
            modelBuilder.Configurations.Add(new ViewProductCategoryMap());
            modelBuilder.Configurations.Add(new ViewSysJobLevelMap());
            modelBuilder.Configurations.Add(new ViewSysMenuMap());
            modelBuilder.Configurations.Add(new ViewSysOrganizationMap());
            modelBuilder.Configurations.Add(new ViewSysSettingMap());
            modelBuilder.Configurations.Add(new ViewSysUserMap());
            modelBuilder.Configurations.Add(new ViewTraceCodeMap());
            modelBuilder.Configurations.Add(new ViewTraceCodeDetailMap());
            modelBuilder.Configurations.Add(new ViewTraceCodeDetailQRMap());
            modelBuilder.Configurations.Add(new ViewTraceCodeDetailXTMap());
            modelBuilder.Configurations.Add(new ViewUserLogMap());
        }
    }
}

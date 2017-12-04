using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class SysRolePermissionMap : EntityTypeConfiguration<SysRolePermission>
    {
        public SysRolePermissionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.RoleID, t.Permission });

            // Properties
            this.Property(t => t.RoleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Permission)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("SysRolePermission");
            this.Property(t => t.RoleID).HasColumnName("RoleID");
            this.Property(t => t.Permission).HasColumnName("Permission");

            // Relationships
            this.HasRequired(t => t.SysRole)
                .WithMany(t => t.SysRolePermissions)
                .HasForeignKey(d => d.RoleID);

        }
    }
}

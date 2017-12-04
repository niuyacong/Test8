using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class SysUserRoleMap : EntityTypeConfiguration<SysUserRole>
    {
        public SysUserRoleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.RoleID });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RoleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("SysUserRole");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.RoleID).HasColumnName("RoleID");

            // Relationships
            this.HasRequired(t => t.SysRole)
                .WithMany(t => t.SysUserRoles)
                .HasForeignKey(d => d.RoleID);

        }
    }
}

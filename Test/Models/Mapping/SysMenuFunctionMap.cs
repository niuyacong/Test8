using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class SysMenuFunctionMap : EntityTypeConfiguration<SysMenuFunction>
    {
        public SysMenuFunctionMap()
        {
            // Primary Key
            this.HasKey(t => t.Code);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Resource)
                .HasMaxLength(250);

            this.Property(t => t.Description)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("SysMenuFunction");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Resource).HasColumnName("Resource");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
        }
    }
}

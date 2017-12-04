using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class ViewSysSettingMap : EntityTypeConfiguration<ViewSysSetting>
    {
        public ViewSysSettingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Code, t.Name, t.Value });

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Value)
                .IsRequired();

            this.Property(t => t.SysSettingTypeCode)
                .HasMaxLength(50);

            this.Property(t => t.SysSettingTypeName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ViewSysSetting");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.SysSettingTypeCode).HasColumnName("SysSettingTypeCode");
            this.Property(t => t.SysSettingTypeName).HasColumnName("SysSettingTypeName");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class SysSettingMap : EntityTypeConfiguration<SysSetting>
    {
        public SysSettingMap()
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

            this.Property(t => t.Value)
                .IsRequired();

            this.Property(t => t.SysSettingTypeCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SysSetting");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.SysSettingTypeCode).HasColumnName("SysSettingTypeCode");
        }
    }
}

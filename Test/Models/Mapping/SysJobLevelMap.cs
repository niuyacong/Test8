using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class SysJobLevelMap : EntityTypeConfiguration<SysJobLevel>
    {
        public SysJobLevelMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.LevelName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SysJobLevel");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.LevelName).HasColumnName("LevelName");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
            this.Property(t => t.SysOrganizationID).HasColumnName("SysOrganizationID");
            this.Property(t => t.CreateID).HasColumnName("CreateID");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
        }
    }
}

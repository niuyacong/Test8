using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class ViewSysJobLevelMap : EntityTypeConfiguration<ViewSysJobLevel>
    {
        public ViewSysJobLevelMap()
        {
            // Primary Key
            this.HasKey(t => t.LevelId);

            // Properties
            this.Property(t => t.LevelId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LevelName)
                .HasMaxLength(50);

            this.Property(t => t.OrgName)
                .HasMaxLength(4000);

            this.Property(t => t.ParentName)
                .HasMaxLength(50);

            this.Property(t => t.Code)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ViewSysJobLevel");
            this.Property(t => t.LevelId).HasColumnName("LevelId");
            this.Property(t => t.LevelName).HasColumnName("LevelName");
            this.Property(t => t.OrgId).HasColumnName("OrgId");
            this.Property(t => t.OrgName).HasColumnName("OrgName");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.ParentName).HasColumnName("ParentName");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.Code).HasColumnName("Code");
        }
    }
}

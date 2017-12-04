using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class ViewSysMenuMap : EntityTypeConfiguration<ViewSysMenu>
    {
        public ViewSysMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(250);

            this.Property(t => t.Value)
                .HasMaxLength(250);

            this.Property(t => t.NavigateUrl)
                .HasMaxLength(250);

            this.Property(t => t.ParentName)
                .HasMaxLength(250);

            this.Property(t => t.BlackIcon)
                .HasMaxLength(500);

            this.Property(t => t.WhiteIcon)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ViewSysMenu");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.NavigateUrl).HasColumnName("NavigateUrl");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ParentName).HasColumnName("ParentName");
            this.Property(t => t.isNotVisible).HasColumnName("isNotVisible");
            this.Property(t => t.BlackIcon).HasColumnName("BlackIcon");
            this.Property(t => t.WhiteIcon).HasColumnName("WhiteIcon");
        }
    }
}

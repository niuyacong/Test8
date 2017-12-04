using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class SysOrganizationMap : EntityTypeConfiguration<SysOrganization>
    {
        public SysOrganizationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(4000);

            this.Property(t => t.Description)
                .HasMaxLength(4000);

            this.Property(t => t.OrganizationTypeCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SysOrganization");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.OrganizationTypeCode).HasColumnName("OrganizationTypeCode");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");

            // Relationships
            this.HasOptional(t => t.SysOrganizationType)
                .WithMany(t => t.SysOrganizations)
                .HasForeignKey(d => d.OrganizationTypeCode);

        }
    }
}

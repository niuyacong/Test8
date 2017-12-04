using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class SysErrorLogMap : EntityTypeConfiguration<SysErrorLog>
    {
        public SysErrorLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Address)
                .HasMaxLength(400);

            // Table & Column Mappings
            this.ToTable("SysErrorLog");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class SysBadWordInfoMap : EntityTypeConfiguration<SysBadWordInfo>
    {
        public SysBadWordInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.BadWord)
                .HasMaxLength(200);

            this.Property(t => t.Type)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SysBadWordInfo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.BadWord).HasColumnName("BadWord");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatTime).HasColumnName("CreatTime");
            this.Property(t => t.CreatID).HasColumnName("CreatID");
            this.Property(t => t.UpdateTime).HasColumnName("UpdateTime");
            this.Property(t => t.UpdateID).HasColumnName("UpdateID");
        }
    }
}

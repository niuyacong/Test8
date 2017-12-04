using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class T_BottleBoxRelationshipMap : EntityTypeConfiguration<T_BottleBoxRelationship>
    {
        public T_BottleBoxRelationshipMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.FromNo });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.BoxNumber)
                .HasMaxLength(50);

            this.Property(t => t.BottleNumber)
                .HasMaxLength(50);

            this.Property(t => t.FromNo)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_BottleBoxRelationship");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.BoxNumber).HasColumnName("BoxNumber");
            this.Property(t => t.BottleNumber).HasColumnName("BottleNumber");
            this.Property(t => t.FromNo).HasColumnName("FromNo");
            this.Property(t => t.ScanTime).HasColumnName("ScanTime");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateID).HasColumnName("CreateID");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class ViewTraceCodeDetailXTMap : EntityTypeConfiguration<ViewTraceCodeDetailXT>
    {
        public ViewTraceCodeDetailXTMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.Status });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(14);

            this.Property(t => t.Batch)
                .HasMaxLength(50);

            this.Property(t => t.ProductName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ViewTraceCodeDetailXT");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TraceCodesID).HasColumnName("TraceCodesID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.CodeType).HasColumnName("CodeType");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Batch).HasColumnName("Batch");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class T_TraceCodeDetailMap : EntityTypeConfiguration<T_TraceCodeDetail>
    {
        public T_TraceCodeDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Code)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_TraceCodeDetail");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TraceCodesID).HasColumnName("TraceCodesID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.CodeType).HasColumnName("CodeType");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class T_TraceCodeImportRecordMap : EntityTypeConfiguration<T_TraceCodeImportRecord>
    {
        public T_TraceCodeImportRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("T_TraceCodeImportRecord");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TraceCodesID).HasColumnName("TraceCodesID");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateID).HasColumnName("CreateID");
        }
    }
}

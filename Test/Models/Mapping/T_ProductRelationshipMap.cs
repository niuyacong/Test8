using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class T_ProductRelationshipMap : EntityTypeConfiguration<T_ProductRelationship>
    {
        public T_ProductRelationshipMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.PreCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_ProductRelationship");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PreCode).HasColumnName("PreCode");
            this.Property(t => t.StartCode).HasColumnName("StartCode");
            this.Property(t => t.EndCode).HasColumnName("EndCode");
            this.Property(t => t.TraceCodesID).HasColumnName("TraceCodesID");
            this.Property(t => t.CodeType).HasColumnName("CodeType");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class T_TraceCodesMap : EntityTypeConfiguration<T_TraceCodes>
    {
        public T_TraceCodesMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ProductName)
                .HasMaxLength(50);

            this.Property(t => t.Batch)
                .HasMaxLength(50);

            this.Property(t => t.ProductSapCode)
                .HasMaxLength(50);

            this.Property(t => t.Rate)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("T_TraceCodes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.Batch).HasColumnName("Batch");
            this.Property(t => t.ProductSapCode).HasColumnName("ProductSapCode");
            this.Property(t => t.ProductCategoryID).HasColumnName("ProductCategoryID");
            this.Property(t => t.ProductSpecificationID).HasColumnName("ProductSpecificationID");
            this.Property(t => t.Num).HasColumnName("Num");
            this.Property(t => t.Rate).HasColumnName("Rate");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateID).HasColumnName("CreateID");
            this.Property(t => t.CodeType).HasColumnName("CodeType");
        }
    }
}

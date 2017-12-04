using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class ViewTraceCodeMap : EntityTypeConfiguration<ViewTraceCode>
    {
        public ViewTraceCodeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.Type });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ProductName)
                .HasMaxLength(50);

            this.Property(t => t.Batch)
                .HasMaxLength(50);

            this.Property(t => t.ProductSapCode)
                .HasMaxLength(50);

            this.Property(t => t.Rate)
                .HasMaxLength(10);

            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.CategoryName)
                .HasMaxLength(50);

            this.Property(t => t.CategoryCode)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.SpecificationName)
                .HasMaxLength(50);

            this.Property(t => t.SpecificationCode)
                .HasMaxLength(10);

            this.Property(t => t.SapCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ViewTraceCode");
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
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.CategoryCode).HasColumnName("CategoryCode");
            this.Property(t => t.SpecificationName).HasColumnName("SpecificationName");
            this.Property(t => t.SpecificationCode).HasColumnName("SpecificationCode");
            this.Property(t => t.SapCode).HasColumnName("SapCode");
            this.Property(t => t.CodeType).HasColumnName("CodeType");
        }
    }
}

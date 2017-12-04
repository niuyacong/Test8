using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class T_ProductSpecificationMap : EntityTypeConfiguration<T_ProductSpecification>
    {
        public T_ProductSpecificationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Code)
                .HasMaxLength(10);

            this.Property(t => t.SapCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_ProductSpecification");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.ProductCategoryID).HasColumnName("ProductCategoryID");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateID).HasColumnName("CreateID");
            this.Property(t => t.UpdateTime).HasColumnName("UpdateTime");
            this.Property(t => t.UpdateID).HasColumnName("UpdateID");
            this.Property(t => t.SapCode).HasColumnName("SapCode");
        }
    }
}

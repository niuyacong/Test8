using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class T_ProductMap : EntityTypeConfiguration<T_Product>
    {
        public T_ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Tankage)
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("T_Product");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ProductCategoryID).HasColumnName("ProductCategoryID");
            this.Property(t => t.ProductSpecificationID).HasColumnName("ProductSpecificationID");
            this.Property(t => t.Tankage).HasColumnName("Tankage");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CreateID).HasColumnName("CreateID");
            this.Property(t => t.UpdateTime).HasColumnName("UpdateTime");
            this.Property(t => t.UpdateID).HasColumnName("UpdateID");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Version).HasColumnName("Version");
        }
    }
}

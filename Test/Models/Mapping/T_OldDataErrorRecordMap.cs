using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class T_OldDataErrorRecordMap : EntityTypeConfiguration<T_OldDataErrorRecord>
    {
        public T_OldDataErrorRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.MATERCODE)
                .HasMaxLength(50);

            this.Property(t => t.BOXCODE)
                .HasMaxLength(50);

            this.Property(t => t.BOTTLE_NUMBER)
                .HasMaxLength(50);

            this.Property(t => t.PRODUCT_NAME)
                .HasMaxLength(50);

            this.Property(t => t.ErrorInfo)
                .HasMaxLength(50);

            this.Property(t => t.CreateTime)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_OldDataErrorRecord");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MATERCODE).HasColumnName("MATERCODE");
            this.Property(t => t.BOXCODE).HasColumnName("BOXCODE");
            this.Property(t => t.BOTTLE_NUMBER).HasColumnName("BOTTLE_NUMBER");
            this.Property(t => t.PRODUCT_NAME).HasColumnName("PRODUCT_NAME");
            this.Property(t => t.ErrorInfo).HasColumnName("ErrorInfo");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
        }
    }
}

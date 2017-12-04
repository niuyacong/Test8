using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class T_UserLogMap : EntityTypeConfiguration<T_UserLog>
    {
        public T_UserLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("T_UserLog");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.USID).HasColumnName("USID");
            this.Property(t => t.OperatingTime).HasColumnName("OperatingTime");
            this.Property(t => t.Contents).HasColumnName("Contents");
        }
    }
}

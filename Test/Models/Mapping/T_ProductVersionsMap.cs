using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class T_ProductVersionsMap : EntityTypeConfiguration<T_ProductVersions>
    {
        public T_ProductVersionsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("T_ProductVersions");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.VersionNumbers).HasColumnName("VersionNumbers");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Test.Models.Mapping
{
    public class ViewSysUserMap : EntityTypeConfiguration<ViewSysUser>
    {
        public ViewSysUserMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserNo)
                .HasMaxLength(50);

            this.Property(t => t.LoginName)
                .HasMaxLength(250);

            this.Property(t => t.Password)
                .HasMaxLength(250);

            this.Property(t => t.Name)
                .HasMaxLength(250);

            this.Property(t => t.Image)
                .HasMaxLength(250);

            this.Property(t => t.PasswordFormat)
                .HasMaxLength(250);

            this.Property(t => t.PasswordSalt)
                .HasMaxLength(250);

            this.Property(t => t.MobilePhone)
                .HasMaxLength(250);

            this.Property(t => t.Telephone)
                .HasMaxLength(250);

            this.Property(t => t.EmailAddress)
                .HasMaxLength(250);

            this.Property(t => t.DisplayOrder)
                .HasMaxLength(250);

            this.Property(t => t.SysOrganizationName)
                .HasMaxLength(4000);

            this.Property(t => t.SysJobLevelCode)
                .HasMaxLength(50);

            this.Property(t => t.LevelName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ViewSysUser");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserNo).HasColumnName("UserNo");
            this.Property(t => t.LoginName).HasColumnName("LoginName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SysOrganizationID).HasColumnName("SysOrganizationID");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.PasswordFormat).HasColumnName("PasswordFormat");
            this.Property(t => t.PasswordSalt).HasColumnName("PasswordSalt");
            this.Property(t => t.MobilePhone).HasColumnName("MobilePhone");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.Enabled).HasColumnName("Enabled");
            this.Property(t => t.SysOrganizationName).HasColumnName("SysOrganizationName");
            this.Property(t => t.SysJobLevelCode).HasColumnName("SysJobLevelCode");
            this.Property(t => t.LevelName).HasColumnName("LevelName");
        }
    }
}

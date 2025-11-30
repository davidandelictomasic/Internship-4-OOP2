using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities.Companies;

namespace UserManagement.Infrastructure.Database.Configurations.Companies
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>

    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("companies");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("id");

            builder.Property(c => c.Name).HasColumnName("name");
            



        }
    }
}

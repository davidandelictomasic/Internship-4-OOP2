using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities.Companies;

namespace UserManagement.Infrastructure.Database.Configurations.Companies
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>

    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");
            builder.HasKey(c => c.ID);

            builder.Property(c => c.ID).HasColumnName("Id");

            builder.Property(c => c.Name).HasColumnName("name");
            



        }
    }
}

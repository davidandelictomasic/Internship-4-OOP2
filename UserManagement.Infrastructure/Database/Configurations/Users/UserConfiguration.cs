
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.Entities.Users;

namespace UserManagement.Infrastructure.Database.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>

    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.ID);

            builder.Property(u => u.ID).HasColumnName("Id");

            builder.Property(u => u.Name).HasColumnName("name");
            builder.Property(u => u.Username).HasColumnName("username");
            builder.Property(u => u.Email).HasColumnName("email");
            builder.Property(u => u.AddressStreet).HasColumnName("address_street");
            builder.Property(u => u.AddressCity).HasColumnName("address_city");
            builder.Property(u => u.GeoLocation).HasColumnName("geo_location");
            builder.Property(u => u.Website).HasColumnName("website");
            builder.Property(u => u.Password).HasColumnName("password");
           


    }
    }
}

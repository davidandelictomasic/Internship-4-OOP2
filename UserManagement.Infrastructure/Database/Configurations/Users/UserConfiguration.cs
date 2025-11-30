
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.Entities.Users;

namespace UserManagement.Infrastructure.Database.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>

    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnName("id");
            builder.Property(u => u.UpdatedAt).HasColumnName("updated_at");
            builder.Property(u => u.Name).HasColumnName("name");
            builder.Property(u => u.Username).HasColumnName("username");
            builder.Property(u => u.Email).HasColumnName("email");
            builder.Property(u => u.AddressStreet).HasColumnName("address_street");
            builder.Property(u => u.AddressCity).HasColumnName("address_city");
            builder.Property(u => u.GeoLatitude).HasColumnName("geo_lat");
            builder.Property(u => u.GeoLongitude).HasColumnName("geo_lng");
            builder.Property(u => u.Website).HasColumnName("website");
            builder.Property(u => u.Password).HasColumnName("password");
            builder.Property(u => u.IsActive).HasColumnName("is_active");



        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MUSbooking.Domain.Entity;

namespace MUSbooking.Infrastructure.DataBase.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Description)
                .IsRequired();

            builder.Property(a => a.CreatedAt)
                .IsRequired();

            builder.Property(a => a.Price)
                .IsRequired();

            builder.HasMany(a => a.Equipments)
                .WithOne(c => c.Order);
        }
    }
}

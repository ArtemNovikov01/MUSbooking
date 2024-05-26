using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MUSbooking.Domain.Entity;

namespace MUSbooking.Infrastructure.DataBase.Configurations
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired();

            builder.Property(a => a.Amount)
                .IsRequired();

            builder.Property(a => a.Price)
                .IsRequired();

            builder.HasMany(a => a.Orders)
                .WithOne(c => c.Equipment);
        }
    }
}

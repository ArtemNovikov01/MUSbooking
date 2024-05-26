using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MUSbooking.Domain.Entity;
using MUSbooking.Domain.Entities;

namespace MUSbooking.Infrastructure.DataBase.Configurations
{
    public class OrderedEquipmentConfiguration : IEntityTypeConfiguration<OrderedEquipment>
    {
        public void Configure(EntityTypeBuilder<OrderedEquipment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Equipment)
                .IsRequired();

            builder.Property(a => a.Order)
                .IsRequired();

            builder.Property(a => a.Count)
                .IsRequired();

            builder.HasOne(a => a.Order)
                .WithMany(c => c.Equipments);

            builder.HasOne(a => a.Equipment)
                .WithMany(c => c.Orders);
        }
    }
}

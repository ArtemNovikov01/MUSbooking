using Microsoft.EntityFrameworkCore;
using MUSbooking.Domain.Entities;
using MUSbooking.Domain.Entity;
using MUSbooking.Services;
namespace MUSbooking.Infrastructure.DataBase
{
    public class MUSbookingDbContext : DbContext, IMUSbookingDbContext
    {
        public MUSbookingDbContext(DbContextOptions<MUSbookingDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Equipment> Equipments => Set<Equipment>();
        public DbSet<OrderedEquipment> OrderedEquipments => Set<OrderedEquipment>();

    }
}

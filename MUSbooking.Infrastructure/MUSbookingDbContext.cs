using Microsoft.EntityFrameworkCore;
using MUSbooking.Domain.Entity;
using MUSbooking.Services;
namespace MUSbooking.Infrastructure.DataBase
{
    public class MUSbookingDbContext : DbContext, IMUSbookingDbContext
    {
        public MUSbookingDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Equipment> Equipments => Set<Equipment>();
        public MUSbookingDbContext() => Database.EnsureCreated();
    }
}

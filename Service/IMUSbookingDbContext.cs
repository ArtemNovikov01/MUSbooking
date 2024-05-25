using Microsoft.EntityFrameworkCore;
using MUSbooking.Domain.Entity;

namespace MUSbooking.Services
{
    public interface IMUSbookingDbContext
    {
        public DbSet<Order> Orders { get; }
        public DbSet<Equipment> Equipments { get; }
    }
}

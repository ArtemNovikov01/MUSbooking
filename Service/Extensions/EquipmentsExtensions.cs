using Microsoft.EntityFrameworkCore;
using MUSbooking.Domain.Entity;

namespace MUSbooking.Services.Extensions
{
    public static class EquipmentsExtensions
    {
        public static IQueryable<Equipment> FilterByName(this IQueryable<Equipment> query, string? term)
        {
            if (term is null)
            {
                return query;
            }

            var searchTerm = term.Trim();

            return query.Where(e => EF.Functions.Like(e.Name, $"%{searchTerm}%"));
        }

        public static IQueryable<Equipment> FilterByAmount(this IQueryable<Equipment> query, int? amount)
        {
            if (amount is null)
            {
                return query;
            }

            return query.Where(e => e.Amount == amount);
        }

        public static IQueryable<Equipment> FilterByPrice(this IQueryable<Equipment> query, decimal? price)
        {
            if (price is null)
            {
                return query;
            }

            return query.Where(e => e.Price == price);
        }
    }
}

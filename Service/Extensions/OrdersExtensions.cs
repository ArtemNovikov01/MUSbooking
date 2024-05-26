using Microsoft.EntityFrameworkCore;
using MUSbooking.Domain.Entity;

namespace MUSbooking.Services.Extensions
{
    public static class OrdersExtensions
    {
        public static IQueryable<Order> FilterByDescription(this IQueryable<Order> query, string? term)
        {
            if (term is null)
            {
                return query;
            }

            var searchTerm = term.Trim();

            return query.Where(e => EF.Functions.Like(e.Description, $"%{searchTerm}%"));
        }

        public static IQueryable<Order> FilterByPrice(this IQueryable<Order> query, decimal? price)
        {
            if (price is null)
            {
                return query;
            }

            return query.Where(e => e.Price == price);
        }

        public static IQueryable<Order> FilterByCreatedAt(this IQueryable<Order> query, DateTime? createdAt)
        {
            if (createdAt is null)
            {
                return query;
            }

            return query.Where(e => e.CreatedAt == createdAt);
        }
    }
}

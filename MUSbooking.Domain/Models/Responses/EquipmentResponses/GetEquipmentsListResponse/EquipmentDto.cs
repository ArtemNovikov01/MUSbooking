﻿using MUSbooking.Domain.Entity;

namespace MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse
{
    public class EquipmentDto
    {
        public EquipmentDto(Equipment equipment)
        {
            Id = equipment.Id;
            Name = equipment.Name;
            Price = equipment.Price;
            Amount = equipment.Amount;
        }

        public int Id { get; init; }

        /// <summary>
        ///     Название оборудования.
        /// </summary>
        public string Name { get; init; } = null!;

        /// <summary>
        ///     Цена.
        /// </summary>
        public decimal Price { get; init; }
        public int Amount { get; init; }
    }
}

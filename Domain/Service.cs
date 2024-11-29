// <copyright file="Service.cs" company="Земсков Н.А и Моисеенко М.А">
// Copyright (c) Земсков Н.А и Моисеенко М.А. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Класс, представляющий услугу.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Уникальный идентификатор услуги.
        /// </summary>
        public Guid ServiceId { get; private set; }

        /// <summary>
        /// Название услуги.
        /// </summary>
        public string ServiceName { get; private set; }

        /// <summary>
        /// Цена услуги.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Описание услуги.
        /// </summary>
        public string? Description { get; private set; }

        /// <summary>
        /// Коэффициент для расчета кастомной стоимости.
        /// </summary>
        public decimal CustomPriceMultiplier { get; private set; }

        /// <summary>
        /// Заказы, связанные с данной услугой.
        /// </summary>
        public ICollection<Order> Orders { get; private set; } = new List<Order>();

        /// <summary>
        /// Конструктор для создания новой услуги.
        /// </summary>
        /// <param name="serviceName">Название услуги.</param>
        /// <param name="price">Цена услуги.</param>
        /// <param name="description">Описание услуги.</param>
        /// <param name="customPriceMultiplier">Коэффициент для кастомной стоимости.</param>
        public Service(string serviceName, decimal price, string? description = null, decimal customPriceMultiplier = 1.0m)
        {
            if (string.IsNullOrWhiteSpace(serviceName))
                throw new ArgumentNullException(nameof(serviceName), "Название услуги не может быть пустым.");

            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Цена услуги не может быть отрицательной.");

            if (customPriceMultiplier <= 0)
                throw new ArgumentOutOfRangeException(nameof(customPriceMultiplier), "Коэффициент кастомной стоимости должен быть больше нуля.");

            ServiceId = Guid.NewGuid();
            ServiceName = serviceName.Trim();
            Price = price;
            Description = description?.Trim();
            CustomPriceMultiplier = customPriceMultiplier;
        }

        /// <summary>
        /// Обновляет цену услуги.
        /// </summary>
        /// <param name="newPrice">Новая цена.</param>
        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(newPrice), "Цена услуги не может быть отрицательной.");

            Price = newPrice;
        }

        /// <summary>
        /// Обновляет коэффициент кастомной стоимости.
        /// </summary>
        /// <param name="newMultiplier">Новый коэффициент.</param>
        public void UpdateCustomPriceMultiplier(decimal newMultiplier)
        {
            if (newMultiplier <= 0)
                throw new ArgumentOutOfRangeException(nameof(newMultiplier), "Коэффициент кастомной стоимости должен быть больше нуля.");

            CustomPriceMultiplier = newMultiplier;
        }

        /// <summary>
        /// Рассчитывает кастомную стоимость услуги.
        /// </summary>
        /// <returns>Кастомная стоимость услуги.</returns>
        public decimal CalculateCustomPrice()
        {
            return Price * CustomPriceMultiplier;
        }

        /// <summary>
        /// Переопределение метода ToString для удобного отображения услуги.
        /// </summary>
        /// <returns>Описание услуги в виде строки.</returns>
        public override string ToString()
        {
            return $"{ServiceName}: {Price:C} (Кастомная стоимость: {CalculateCustomPrice():C})";
        }

        /// <summary>
        /// Переопределение метода Equals для сравнения услуг.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>True, если услуги равны.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not Service other)
                return false;

            return ServiceId == other.ServiceId &&
                   ServiceName == other.ServiceName &&
                   Price == other.Price &&
                   Description == other.Description &&
                   CustomPriceMultiplier == other.CustomPriceMultiplier;
        }

        /// <summary>
        /// Переопределение метода GetHashCode.
        /// </summary>
        /// <returns>Хэш-код услуги.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(ServiceId, ServiceName, Price, Description, CustomPriceMultiplier);
        }
    }
}

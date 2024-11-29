// <copyright file="OrderConfiguration.cs" company="Земсков Н.А и Моисеенко М.А">
// Copyright (c) Земсков Н.А и Моисеенко М.А. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Класс, представляющий заказ.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Уникальный идентификатор заказа.
        /// </summary>
        public Guid OrderId { get; private set; }

        /// <summary>
        /// Идентификатор услуги, связанной с заказом.
        /// </summary>
        public Guid ServiceId { get; private set; }

        /// <summary>
        /// Навигационное свойство для услуги.
        /// </summary>
        public Service Service { get; private set; } = null!; // Навигационное свойство

        /// <summary>
        /// Идентификатор клиента, сделавшего заказ.
        /// </summary>
        public Guid CustomerId { get; private set; }

        /// <summary>
        /// Навигационное свойство для клиента.
        /// </summary>
        public Customer Customer { get; private set; } = null!; // Навигационное свойство

        /// <summary>
        /// Идентификатор команды, назначенной на выполнение заказа.
        /// </summary>
        public Guid? TeamId { get; private set; }

        /// <summary>
        /// Навигационное свойство для команды.
        /// </summary>
        public Team? Team { get; private set; } // Навигационное свойство (может быть null)

        /// <summary>
        /// Дата заказа.
        /// </summary>
        public DateTime OrderDate { get; private set; }

        /// <summary>
        /// Указывает, является ли проект кастомным.
        /// </summary>
        public bool CustomProject { get; private set; }

        /// <summary>
        /// Общая стоимость заказа.
        /// </summary>
        public decimal TotalPrice { get; private set; }

        /// <summary>
        /// Конструктор для создания нового заказа.
        /// </summary>
        /// <param name="serviceId">Идентификатор услуги.</param>
        /// <param name="customerId">Идентификатор клиента.</param>
        /// <param name="orderDate">Дата заказа.</param>
        /// <param name="totalPrice">Общая стоимость заказа.</param>
        /// <param name="customProject">Является ли проект кастомным.</param>
        /// <param name="teamId">Идентификатор команды (опционально).</param>
        public Order(Guid serviceId, Guid customerId, DateTime orderDate, decimal totalPrice, bool customProject = false, Guid? teamId = null)
        {
            if (totalPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(totalPrice), "Стоимость заказа не может быть отрицательной.");

            ServiceId = serviceId;
            CustomerId = customerId;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            CustomProject = customProject;
            TeamId = teamId;

            OrderId = Guid.NewGuid();
        }

        /// <summary>
        /// Обновляет информацию о команде, назначенной на выполнение заказа.
        /// </summary>
        /// <param name="teamId">Новый идентификатор команды.</param>
        public void AssignTeam(Guid? teamId)
        {
            TeamId = teamId;
        }

        /// <summary>
        /// Устанавливает новую стоимость заказа.
        /// </summary>
        /// <param name="newPrice">Новая стоимость.</param>
        public void UpdateTotalPrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(newPrice), "Стоимость заказа не может быть отрицательной.");

            TotalPrice = newPrice;
        }

        /// <summary>
        /// Переопределение метода ToString для удобного отображения заказа.
        /// </summary>
        /// <returns>Описание заказа в виде строки.</returns>
        public override string ToString()
        {
            return $"Заказ {OrderId} | Услуга: {ServiceId} | Клиент: {CustomerId} | " +
                   $"Дата: {OrderDate:yyyy-MM-dd} | Кастомный проект: {CustomProject} | " +
                   $"Стоимость: {TotalPrice:C}";
        }

        /// <summary>
        /// Переопределение метода Equals для сравнения заказов.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>True, если заказы равны.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not Order other)
                return false;

            return OrderId == other.OrderId &&
                   ServiceId == other.ServiceId &&
                   CustomerId == other.CustomerId &&
                   TeamId == other.TeamId &&
                   OrderDate == other.OrderDate &&
                   CustomProject == other.CustomProject &&
                   TotalPrice == other.TotalPrice;
        }

        /// <summary>
        /// Переопределение метода GetHashCode.
        /// </summary>
        /// <returns>Хэш-код заказа.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(OrderId, ServiceId, CustomerId, TeamId, OrderDate, CustomProject, TotalPrice);
        }
    }
}

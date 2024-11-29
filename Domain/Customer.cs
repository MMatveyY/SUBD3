// <copyright file="Order.cs" company="Земсков Н.А и Моисеенко М.А">
// Copyright (c) Земсков Н.А и Моисеенко М.А. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Класс, представляющий клиента.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Уникальный идентификатор клиента.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Контактная информация клиента.
        /// </summary>
        public string? ContactInfo { get; private set; }

        /// <summary>
        /// Список заказов, связанных с клиентом.
        /// </summary>
        public ICollection<Order> Orders { get; private set; } = new List<Order>();

        /// <summary>
        /// Конструктор для создания клиента с обязательным именем.
        /// </summary>
        /// <param name="name">Имя клиента.</param>
        /// <param name="contactInfo">Контактная информация клиента.</param>
        public Customer(string name, string? contactInfo = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Имя клиента не может быть пустым.");

            Id = Guid.NewGuid();
            Name = name.Trim();
            ContactInfo = contactInfo?.Trim();
        }

        /// <summary>
        /// Устанавливает новую контактную информацию для клиента.
        /// </summary>
        /// <param name="contactInfo">Новая контактная информация.</param>
        public void UpdateContactInfo(string? contactInfo)
        {
            ContactInfo = contactInfo?.Trim();
        }

        /// <summary>
        /// Переопределение метода ToString для удобного отображения клиента.
        /// </summary>
        /// <returns>Имя и контактная информация клиента.</returns>
        public override string ToString()
        {
            return $"{Name} ({ContactInfo ?? "Контактная информация отсутствует"})";
        }

        /// <summary>
        /// Переопределение метода Equals для сравнения клиентов.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>True, если клиенты равны.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not Customer other)
                return false;

            return Id == other.Id &&
                   Name == other.Name &&
                   ContactInfo == other.ContactInfo;
        }

        /// <summary>
        /// Переопределение метода GetHashCode.
        /// </summary>
        /// <returns>Хэш-код клиента.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, ContactInfo);
        }
    }
}

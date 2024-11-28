// <copyright file="Team.cs" company="Земсков Н.А и Моисеенко М.А">
// Copyright (c) Земсков Н.А и Моисеенко М.А. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Класс, представляющий бригаду.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Уникальный идентификатор бригады.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Название бригады.
        /// </summary>
        public string TeamName { get; private set; }

        /// <summary>
        /// Указывает, активна ли бригада.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Рабочие, принадлежащие бригаде.
        /// </summary>
        public ICollection<Worker> Workers { get; private set; } = new List<Worker>();

        /// <summary>
        /// Заказы, назначенные бригаде.
        /// </summary>
        public ICollection<Order> Orders { get; private set; } = new List<Order>();

        /// <summary>
        /// Конструктор для создания новой бригады.
        /// </summary>
        /// <param name="teamName">Название бригады.</param>
        /// <param name="isActive">Статус активности бригады.</param>
        public Team(string teamName, bool isActive = true)
        {
            if (string.IsNullOrWhiteSpace(teamName))
                throw new ArgumentNullException(nameof(teamName), "Название бригады не может быть пустым.");

            Id = Guid.NewGuid();
            TeamName = teamName.Trim();
            IsActive = isActive;
        }

        /// <summary>
        /// Устанавливает статус активности бригады.
        /// </summary>
        /// <param name="isActive">Новый статус активности.</param>
        public void SetActiveStatus(bool isActive)
        {
            IsActive = isActive;
        }

        /// <summary>
        /// Переопределение метода ToString для удобного отображения бригады.
        /// </summary>
        /// <returns>Описание бригады в виде строки.</returns>
        public override string ToString()
        {
            return $"{TeamName} ({(IsActive ? "Активна" : "Не активна")})";
        }

        /// <summary>
        /// Переопределение метода Equals для сравнения бригад.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>True, если бригады равны.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not Team other)
                return false;

            return Id == other.Id &&
                   TeamName == other.TeamName &&
                   IsActive == other.IsActive;
        }

        /// <summary>
        /// Переопределение метода GetHashCode.
        /// </summary>
        /// <returns>Хэш-код бригады.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, TeamName, IsActive);
        }
    }
}

// <copyright file="Worker.cs" company="Земсков Н.А и Моисеенко М.А">
// Copyright (c) Земсков Н.А и Моисеенко М.А. All rights reserved.
// </copyright>

using System;

namespace Domain
{
    /// <summary>
    /// Класс, представляющий рабочего.
    /// </summary>
    public class Worker
    {
        /// <summary>
        /// Уникальный идентификатор рабочего.
        /// </summary>
        public Guid WorkerId { get; private set; }

        /// <summary>
        /// Имя рабочего.
        /// </summary>
        public string WorkerName { get; private set; }

        /// <summary>
        /// Роль рабочего (например, "Worker" или "Master").
        /// </summary>
        public string Role { get; private set; }

        /// <summary>
        /// Идентификатор команды, в которой работает рабочий.
        /// </summary>
        public Guid? TeamId { get; private set; }

        /// <summary>
        /// Навигационное свойство для команды, к которой принадлежит рабочий.
        /// </summary>
        public Team? Team { get; private set; }

        /// <summary>
        /// Конструктор для создания нового рабочего.
        /// </summary>
        /// <param name="workerName">Имя рабочего.</param>
        /// <param name="role">Роль рабочего.</param>
        /// <param name="teamId">Идентификатор команды (опционально).</param>
        public Worker(string workerName, string role, Guid? teamId = null)
        {
            if (string.IsNullOrWhiteSpace(workerName))
                throw new ArgumentNullException(nameof(workerName), "Имя рабочего не может быть пустым.");

            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentNullException(nameof(role), "Роль рабочего не может быть пустой.");

            WorkerId = Guid.NewGuid();
            WorkerName = workerName.Trim();
            Role = role.Trim();
            TeamId = teamId;
        }

        /// <summary>
        /// Назначает рабочего в команду.
        /// </summary>
        /// <param name="teamId">Идентификатор команды.</param>
        public void AssignToTeam(Guid teamId)
        {
            TeamId = teamId;
        }

        /// <summary>
        /// Убирает рабочего из команды.
        /// </summary>
        public void RemoveFromTeam()
        {
            TeamId = null;
        }

        /// <summary>
        /// Переопределение метода ToString для удобного отображения рабочего.
        /// </summary>
        /// <returns>Описание рабочего в виде строки.</returns>
        public override string ToString()
        {
            return $"{WorkerName} - {Role} {(TeamId.HasValue ? $"(Команда: {TeamId})" : "(Без команды)")}";
        }

        /// <summary>
        /// Переопределение метода Equals для сравнения рабочих.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>True, если рабочие равны.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not Worker other)
                return false;

            return WorkerId == other.WorkerId &&
                   WorkerName == other.WorkerName &&
                   Role == other.Role &&
                   TeamId == other.TeamId;
        }

        /// <summary>
        /// Переопределение метода GetHashCode.
        /// </summary>
        /// <returns>Хэш-код рабочего.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(WorkerId, WorkerName, Role, TeamId);
        }
    }
}

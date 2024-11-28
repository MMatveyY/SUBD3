// <copyright file="WorkerConfiguration.cs" company="Земсков Н.А и Моисеенко М.А">
// Copyright (c) Земсков Н.А и Моисеенко М.А. All rights reserved.
// </copyright>

namespace DataAccess.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Worker"/>) в таблицу БД.
    /// </summary>
    public sealed class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            // Установка первичного ключа
            _ = builder.HasKey(worker => worker.WorkerId);

            // Конфигурация свойства WorkerName
            _ = builder.Property(worker => worker.WorkerName)
                .HasMaxLength(200)
                .IsRequired();

            // Конфигурация свойства Role
            _ = builder.Property(worker => worker.Role)
                .HasMaxLength(100)
                .IsRequired();

            // Связь с командой (Team)
            _ = builder.HasOne(worker => worker.Team)
                .WithMany(team => team.Workers)
                .HasForeignKey(worker => worker.TeamId)
                .OnDelete(DeleteBehavior.SetNull); // При удалении команды TeamId станет NULL

            // Опционально: Индекс на WorkerName и Role
            _ = builder.HasIndex(worker => new { worker.WorkerName, worker.Role })
                .IsUnique(); // Уникальная пара "Имя + Роль"
        }
    }
}

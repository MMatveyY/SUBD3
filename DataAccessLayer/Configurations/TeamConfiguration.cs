// <copyright file="TeamConfiguration.cs" company="Земсков Н.А и Моисеенко М.А">
// Copyright (c) Земсков Н.А и Моисеенко М.А. All rights reserved.
// </copyright>

namespace DataAccess.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Team"/>) в таблицу БД.
    /// </summary>
    public sealed class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            // Установка первичного ключа
            _ = builder.HasKey(team => team.Id);

            // Конфигурация свойства TeamName
            _ = builder.Property(team => team.TeamName)
                .HasMaxLength(200)
                .IsRequired();

            // Конфигурация свойства IsActive
            _ = builder.Property(team => team.IsActive)
                .IsRequired()
                .HasDefaultValue(true); // Значение по умолчанию — активна

            // Опционально: Добавление индекса на имя команды
            _ = builder.HasIndex(team => team.TeamName)
                .IsUnique(); // Уникальные имена команд
        }
    }
}

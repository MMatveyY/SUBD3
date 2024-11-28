// <copyright file="ServiceConfiguration.cs" company="Земсков Н.А и Моисеенко М.А">
// Copyright (c) Земсков Н.А и Моисеенко М.А. All rights reserved.
// </copyright>

namespace DataAccess.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Service"/>) в таблицу БД.
    /// </summary>
    public sealed class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            // Установка первичного ключа
            _ = builder.HasKey(service => service.ServiceId);

            // Конфигурация свойства ServiceName
            _ = builder.Property(service => service.ServiceName)
                .HasMaxLength(200)
                .IsRequired();

            // Конфигурация свойства Price
            _ = builder.Property(service => service.Price)
                .HasColumnType("decimal(18,2)") // Для финансовых значений
                .IsRequired();

            // Конфигурация свойства Description
            _ = builder.Property(service => service.Description)
                .HasMaxLength(500)
                .IsRequired(false);

            // Конфигурация свойства CustomPriceMultiplier
            _ = builder.Property(service => service.CustomPriceMultiplier)
                .HasColumnType("decimal(5,2)") // Тип для коэффициента
                .IsRequired()
                .HasDefaultValue(1.0m);

            // Опционально: Добавление индекса на название услуги
            _ = builder.HasIndex(service => service.ServiceName)
                .IsUnique();
        }
    }
}

// <copyright file="CustomerConfiguration.cs" company="Земсков Н.А и Моисеенко М.А">
// Copyright (c) Земсков Н.А и Моисеенко М.А. All rights reserved.
// </copyright>

namespace DataAccess.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Customer"/>) в таблицу БД.
    /// </summary>
    public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Установка первичного ключа
            _ = builder.HasKey(customer => customer.Id);

            // Конфигурация свойства Name
            _ = builder.Property(customer => customer.Name)
                .HasMaxLength(200)
                .IsRequired();

            // Конфигурация свойства ContactInfo
            _ = builder.Property(customer => customer.ContactInfo)
                .HasMaxLength(300)
                .IsRequired(false);

            // Опционально: настройка индекса по имени клиента
            _ = builder.HasIndex(customer => customer.Name)
                .IsUnique(false); // Уникальность не требуется, может быть несколько клиентов с одинаковым именем
        }
    }
}

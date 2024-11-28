// <copyright file="OrderConfiguration.cs" company="Земсков Н.А и Моисеенко М.А">
// Copyright (c) Земсков Н.А и Моисеенко М.А. All rights reserved.
// </copyright>

namespace DataAccess.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Order"/>) в таблицу БД.
    /// </summary>
    public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Установка первичного ключа
            _ = builder.HasKey(order => order.OrderId);

            // Конфигурация свойства OrderDate
            _ = builder.Property(order => order.OrderDate)
                .IsRequired();

            // Конфигурация свойства TotalPrice
            _ = builder.Property(order => order.TotalPrice)
                .HasColumnType("decimal(18,2)") // Для финансовых значений
                .IsRequired();

            // Конфигурация свойства CustomProject
            _ = builder.Property(order => order.CustomProject)
                .IsRequired();

            // Настройка связи с Service
            _ = builder.HasOne(order => order.Service)
                .WithMany()
                .HasForeignKey(order => order.ServiceId)
                .OnDelete(DeleteBehavior.Cascade); // Удаление заказа при удалении услуги

            // Настройка связи с Customer
            _ = builder.HasOne(order => order.Customer)
                .WithMany(customer => customer.Orders)
                .HasForeignKey(order => order.CustomerId)
                .OnDelete(DeleteBehavior.Cascade); // Удаление заказа при удалении клиента

            // Настройка связи с Team (может быть null)
            _ = builder.HasOne(order => order.Team)
                .WithMany(team => team.Orders)
                .HasForeignKey(order => order.TeamId)
                .OnDelete(DeleteBehavior.SetNull); // Установка null, если команда удалена
        }
    }
}

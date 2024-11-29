// <copyright file="DataContext.cs" company="Земсков Н.А и Моисеенко М.А">
// Copyright (c) Земсков Н.А и Моисеенко М.А. All rights reserved.
// </copyright>

namespace DataAccess
{
    using System.Reflection;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Контекст доступа к данным.
    /// </summary>
    public sealed class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ApplicationDbContext"/>.
        /// </summary>
        public ApplicationDbContext()
            : base()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ApplicationDbContext"/>.
        /// </summary>
        /// <param name="options">Опции настройки контекста доступа к данным.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Таблица клиентов.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Таблица заказов.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Таблица услуг.
        /// </summary>
        public DbSet<Service> Services { get; set; }

        /// <summary>
        /// Таблица бригад.
        /// </summary>
        public DbSet<Team> Teams { get; set; }

        /// <summary>
        /// Таблица рабочих.
        /// </summary>
        public DbSet<Worker> Workers { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Применение конфигурации через Fluent API.
            _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Можно дополнительно настроить связи или ограничения напрямую.
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Здесь укажите вашу строку подключения.
            optionsBuilder.UseNpgsql("Username=postgres;Password=1234;Host=localhost;Database=Admin;");
        }
    }
}

// <copyright file="Program.cs" company="Земсков Н.А и Моисеенко М.А">
// Copyright (c) Земсков Н.А и Моисеенко М.А. All rights reserved.
// </copyright>

using DataAccess;
using Domain;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                // Создаём нового клиента
                var customer = new Customer("Иван Иванов", "ivanov@example.com");

                // Добавляем клиента в базу
                context.Customers.Add(customer);

                // Сохраняем изменения
                context.SaveChanges();

                Console.WriteLine($"Клиент добавлен с ID: {customer.Id}");
            }
        }
    }

}

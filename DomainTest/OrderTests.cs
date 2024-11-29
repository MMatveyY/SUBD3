// <copyright file="OrderTests.cs" company="Земсков Н.А и Моисеенко М.А">
// Copyright (c) Земсков Н.А и Моисеенко М.А. All rights reserved.
// </copyright>

using System;
using Domain;
using NUnit.Framework;

namespace DomainTest
{
    using System;
    using System.Collections.Generic;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для класса <see cref="Order"/>.
    /// </summary>
    [TestFixture]
    public sealed class OrderTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            var teamId = Guid.NewGuid();
            var orderDate = DateTime.Now;

            // Act
            var order = new Order(serviceId, customerId, orderDate, 150000m, true, teamId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(order.ServiceId, Is.EqualTo(serviceId));
                Assert.That(order.CustomerId, Is.EqualTo(customerId));
                Assert.That(order.TeamId, Is.EqualTo(teamId));
                Assert.That(order.OrderDate, Is.EqualTo(orderDate));
                Assert.That(order.TotalPrice, Is.EqualTo(150000m));
                Assert.That(order.CustomProject, Is.True);
                Assert.That(order.OrderId, Is.Not.EqualTo(Guid.Empty));
            });
        }

        [Test]
        public void Ctor_NegativePrice_ThrowsException()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            var orderDate = DateTime.Now;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _ = new Order(serviceId, customerId, orderDate, -100m));
        }

        [Test]
        public void AssignTeam_ValidTeamId_Success()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            var orderDate = DateTime.Now;
            var order = new Order(serviceId, customerId, orderDate, 150000m);

            var teamId = Guid.NewGuid();

            // Act
            order.AssignTeam(teamId);

            // Assert
            Assert.That(order.TeamId, Is.EqualTo(teamId));
        }

        [Test]
        public void AssignTeam_NullTeam_RemovesTeam()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            var orderDate = DateTime.Now;
            var teamId = Guid.NewGuid();
            var order = new Order(serviceId, customerId, orderDate, 150000m, true, teamId);

            // Act
            order.AssignTeam(null);

            // Assert
            Assert.That(order.TeamId, Is.Null);
        }

        [Test]
        public void UpdateTotalPrice_ValidPrice_Success()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            var orderDate = DateTime.Now;
            var order = new Order(serviceId, customerId, orderDate, 150000m);

            // Act
            order.UpdateTotalPrice(200000m);

            // Assert
            Assert.That(order.TotalPrice, Is.EqualTo(200000m));
        }

        [Test]
        public void UpdateTotalPrice_NegativePrice_ThrowsException()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            var orderDate = DateTime.Now;
            var order = new Order(serviceId, customerId, orderDate, 150000m);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => order.UpdateTotalPrice(-100m));
        }

        [Test]
        public void ToString_ValidData_ReturnsExpected()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            var orderDate = new DateTime(2024, 11, 1);
            var order = new Order(serviceId, customerId, orderDate, 150000m, true);

            // Act
            var result = order.ToString();

            // Assert
            StringAssert.Contains("150 000,00", result); // Проверка стоимости
            StringAssert.Contains("2024-11-01", result); // Проверка даты
        }

        [Test]
        public void Equals_SameData_ReturnsFalse()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            var orderDate = DateTime.Now;

            var order1 = new Order(serviceId, customerId, orderDate, 150000m);
            var order2 = new Order(serviceId, customerId, orderDate, 150000m);

            // Act & Assert
            Assert.That(order1.Equals(order2), Is.False, "Orders with the same data but different GUIDs should not be equal.");
        }

        [Test]
        public void GetHashCode_DifferentOrders_ReturnsDifferentHashCodes()
        {
            // Arrange
            var serviceId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            var orderDate = DateTime.Now;

            var order1 = new Order(serviceId, customerId, orderDate, 150000m);
            var order2 = new Order(serviceId, customerId, orderDate, 150000m);

            // Act
            var hash1 = order1.GetHashCode();
            var hash2 = order2.GetHashCode();

            // Assert
            Assert.That(hash1, Is.Not.EqualTo(hash2));
        }
    }
}

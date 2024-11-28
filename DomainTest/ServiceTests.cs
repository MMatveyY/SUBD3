// <copyright file="ServiceTests.cs" company="Земсков Н.А и Моисеенко М.А">
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
    /// Тесты для класса <see cref="Service"/>.
    /// </summary>
    [TestFixture]
    public sealed class ServiceTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            // Arrange & Act
            var service = new Service("Строительство дома", 1000000m, "Описание услуги", 1.2m);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(service.ServiceName, Is.EqualTo("Строительство дома"));
                Assert.That(service.Price, Is.EqualTo(1000000m));
                Assert.That(service.Description, Is.EqualTo("Описание услуги"));
                Assert.That(service.CustomPriceMultiplier, Is.EqualTo(1.2m));
                Assert.That(service.ServiceId, Is.Not.EqualTo(Guid.Empty));
            });
        }

        [Test]
        public void Ctor_NullServiceName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Service(null!, 1000000m));
        }

        [Test]
        public void Ctor_EmptyServiceName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Service("", 1000000m));
        }

        [Test]
        public void Ctor_NegativePrice_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Service("Услуга", -500m));
        }

        [Test]
        public void Ctor_NonPositiveMultiplier_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Service("Услуга", 100000m, null, 0m));
        }

        [Test]
        public void UpdatePrice_ValidPrice_Success()
        {
            // Arrange
            var service = new Service("Строительство дома", 1000000m);

            // Act
            service.UpdatePrice(1200000m);

            // Assert
            Assert.That(service.Price, Is.EqualTo(1200000m));
        }

        [Test]
        public void UpdatePrice_NegativePrice_ThrowsException()
        {
            // Arrange
            var service = new Service("Строительство дома", 1000000m);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => service.UpdatePrice(-100m));
        }

        [Test]
        public void UpdateCustomPriceMultiplier_ValidMultiplier_Success()
        {
            // Arrange
            var service = new Service("Строительство дома", 1000000m, null, 1.1m);

            // Act
            service.UpdateCustomPriceMultiplier(1.3m);

            // Assert
            Assert.That(service.CustomPriceMultiplier, Is.EqualTo(1.3m));
        }

        [Test]
        public void UpdateCustomPriceMultiplier_NonPositiveMultiplier_ThrowsException()
        {
            // Arrange
            var service = new Service("Строительство дома", 1000000m);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => service.UpdateCustomPriceMultiplier(0m));
        }

        [Test]
        public void CalculateCustomPrice_ValidData_ReturnsExpectedPrice()
        {
            // Arrange
            var service = new Service("Строительство дома", 1000000m, null, 1.2m);

            // Act
            var customPrice = service.CalculateCustomPrice();

            // Assert
            Assert.That(customPrice, Is.EqualTo(1200000m));
        }

        [Test]
        public void ToString_ValidData_ReturnsExpected()
        {
            // Arrange
            var service = new Service("Строительство дома", 1000000m, "Описание", 1.2m);

            // Act
            var result = service.ToString();

            // Assert
            StringAssert.Contains("Строительство дома", result); // Проверка имени услуги
            StringAssert.Contains("1 200 000,00", result);       // Проверка кастомной стоимости
        }

        [Test]
        public void Equals_SameData_ReturnsFalse()
        {
            // Arrange
            var service1 = new Service("Строительство дома", 1000000m);
            var service2 = new Service("Строительство дома", 1000000m);

            // Act & Assert
            Assert.That(service1.Equals(service2), Is.False, "Services with the same data but different GUIDs should not be equal.");
        }

        [Test]
        public void GetHashCode_DifferentServices_ReturnsDifferentHashCodes()
        {
            // Arrange
            var service1 = new Service("Строительство дома", 1000000m);
            var service2 = new Service("Ремонт крыши", 500000m);

            // Act
            var hash1 = service1.GetHashCode();
            var hash2 = service2.GetHashCode();

            // Assert
            Assert.That(hash1, Is.Not.EqualTo(hash2));
        }
    }
}

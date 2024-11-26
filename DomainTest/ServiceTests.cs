namespace DomainTest
{
    using System;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для сущности <see cref="Domain.Service"/>.
    /// </summary>
    [TestFixture]
    public sealed class ServiceTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            Assert.DoesNotThrow(() => _ = new Service("Строительство дома", 1000000m, "Описание услуги", 1.1m));
        }

        [Test]
        public void Ctor_InvalidPrice_ExpectedException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Service("Строительство дома", -500m));
        }

        [Test]
        public void Ctor_InvalidMultiplier_ExpectedException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Service("Строительство дома", 100000m, null, 0m));
        }

        [TestCase("Услуга 1", 1000m, "Описание", 1.2, "Услуга 1: 1 000,00 ₽")]
        [TestCase("Услуга 2", 500m, null, 1.0, "Услуга 2: 500,00 ₽")]
        public void ToString_ValidData_Success(string name, decimal price, string? description, decimal multiplier, string expected)
        {
            // Arrange
            var service = new Service(name, price, description, multiplier);

            // Act
            var actual = service.ToString();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

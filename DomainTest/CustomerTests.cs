namespace DomainTest
{
    using System;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для сущности <see cref="Domain.Customer"/>.
    /// </summary>
    [TestFixture]
    public sealed class CustomerTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            Assert.DoesNotThrow(() => _ = new Customer("Иван Иванов", "ivanov@example.com"));
        }

        [Test]
        public void Ctor_NullName_ExpectedException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new Customer(null!));
        }

        [TestCase("Иван Иванов", "ivanov@example.com", "Иван Иванов (ivanov@example.com)")]
        [TestCase("Петр Петров", null, "Петр Петров (Контакты отсутствуют)")]
        public void ToString_ValidData_Success(string name, string? contact, string expected)
        {
            // Arrange
            var customer = new Customer(name, contact);

            // Act
            var actual = customer.ToString();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

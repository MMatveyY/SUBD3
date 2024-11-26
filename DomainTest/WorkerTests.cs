namespace DomainTest
{
    using System;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для сущности <see cref="Domain.Order"/>.
    /// </summary>
    [TestFixture]
    public sealed class OrderTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            var service = new Service("Строительство дома", 1000000m);
            var customer = new Customer("Иван Иванов");
            Assert.DoesNotThrow(() => _ = new Order(service, customer, DateTime.Now, 1000000m));
        }

        [Test]
        public void Ctor_NullService_ExpectedException()
        {
            var customer = new Customer("Иван Иванов");
            Assert.Throws<ArgumentNullException>(() => _ = new Order(null!, customer, DateTime.Now, 1000000m));
        }

        [Test]
        public void Ctor_NullCustomer_ExpectedException()
        {
            var service = new Service("Строительство дома", 1000000m);
            Assert.Throws<ArgumentNullException>(() => _ = new Order(service, null!, DateTime.Now, 1000000m));
        }

        [TestCase(1000000, "Строительство дома", "Иван Иванов", "1000000.00")]
        public void ToString_ValidData_Success(decimal price, string serviceName, string customerName, string expected)
        {
            // Arrange
            var service = new Service(serviceName, price);
            var customer = new Customer(customerName);
            var order = new Order(service, customer, DateTime.Now, price);

            // Act
            var actual = order.ToString();

            // Assert
            Assert.That(actual, Is.StringContaining(expected));
        }
    }
}

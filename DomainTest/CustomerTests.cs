// <copyright file="CustomerTests.cs" company="Земсков Н.А и Моисеенко М.А">
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
    /// Тесты для класса <see cref="Customer"/>.
    /// </summary>
    [TestFixture]
    public sealed class CustomerTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            // Arrange & Act
            var customer = new Customer("Иван Иванов", "ivanov@example.com");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(customer.Name, Is.EqualTo("Иван Иванов"));
                Assert.That(customer.ContactInfo, Is.EqualTo("ivanov@example.com"));
                Assert.That(customer.Id, Is.Not.EqualTo(Guid.Empty));
            });
        }

        [Test]
        public void Ctor_NullName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Customer(null!));
        }

        [Test]
        public void Ctor_EmptyName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Customer(""));
        }

        [TestCase("Иван Иванов", null, "Иван Иванов (Контактная информация отсутствует)")]
        [TestCase("Мария Смирнова", "maria@example.com", "Мария Смирнова (maria@example.com)")]
        public void ToString_ValidData_ReturnsExpected(string name, string? contact, string expected)
        {
            // Arrange
            var customer = new Customer(name, contact);

            // Act
            var actual = customer.ToString();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void UpdateContactInfo_ValidData_Success()
        {
            // Arrange
            var customer = new Customer("Иван Иванов", "ivanov@example.com");

            // Act
            customer.UpdateContactInfo("new_email@example.com");

            // Assert
            Assert.That(customer.ContactInfo, Is.EqualTo("new_email@example.com"));
        }

        [Test]
        public void UpdateContactInfo_NullData_SetsNull()
        {
            // Arrange
            var customer = new Customer("Иван Иванов", "ivanov@example.com");

            // Act
            customer.UpdateContactInfo(null);

            // Assert
            Assert.That(customer.ContactInfo, Is.Null);
        }

        [Test]
        public void Equals_SameData_ReturnsTrue()
        {
            // Arrange
            var customer1 = new Customer("Иван Иванов", "ivanov@example.com");
            var customer2 = new Customer("Иван Иванов", "ivanov@example.com");

            // Act & Assert
            Assert.That(customer1.Equals(customer2), Is.False, "Guid is unique, objects should not be equal");
        }

        [Test]
        public void GetHashCode_DifferentCustomers_ReturnsDifferentHashCodes()
        {
            // Arrange
            var customer1 = new Customer("Иван Иванов", "ivanov@example.com");
            var customer2 = new Customer("Мария Смирнова", "maria@example.com");

            // Act
            var hash1 = customer1.GetHashCode();
            var hash2 = customer2.GetHashCode();

            // Assert
            Assert.That(hash1, Is.Not.EqualTo(hash2));
        }
    }
}

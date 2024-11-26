namespace DomainTest
{
    using System;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для сущности <see cref="Domain.Team"/>.
    /// </summary>
    [TestFixture]
    public sealed class TeamTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            Assert.DoesNotThrow(() => _ = new Team("Бригада №1"));
        }

        [Test]
        public void Ctor_NullName_ExpectedException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new Team(null!));
        }

        [TestCase("Бригада №1", true, "Бригада №1 (Свободна)")]
        [TestCase("Бригада №2", false, "Бригада №2 (Занята)")]
        public void ToString_ValidData_Success(string name, bool isActive, string expected)
        {
            // Arrange
            var team = new Team(name, isActive);

            // Act
            var actual = team.ToString();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

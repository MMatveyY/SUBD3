// <copyright file="TeamTests.cs" company="Земсков Н.А и Моисеенко М.А">
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
    /// Тесты для класса <see cref="Team"/>.
    /// </summary>
    [TestFixture]
    public sealed class TeamTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            // Arrange & Act
            var team = new Team("Бригада №1", true);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(team.TeamName, Is.EqualTo("Бригада №1"));
                Assert.That(team.IsActive, Is.True);
                Assert.That(team.Id, Is.Not.EqualTo(Guid.Empty));
            });
        }

        [Test]
        public void Ctor_DefaultIsActive_Success()
        {
            // Arrange & Act
            var team = new Team("Бригада №2");

            // Assert
            Assert.That(team.IsActive, Is.True);
        }

        [Test]
        public void Ctor_NullTeamName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Team(null!));
        }

        [Test]
        public void Ctor_EmptyTeamName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Team(""));
        }
       

        [Test]
        public void SetActiveStatus_SetToFalse_Success()
        {
            // Arrange
            var team = new Team("Бригада №1", true);

            // Act
            team.SetActiveStatus(false);

            // Assert
            Assert.That(team.IsActive, Is.False);
        }

        [Test]
        public void SetActiveStatus_SetToTrue_Success()
        {
            // Arrange
            var team = new Team("Бригада №2", false);

            // Act
            team.SetActiveStatus(true);

            // Assert
            Assert.That(team.IsActive, Is.True);
        }

        [Test]
        public void Equals_SameData_ReturnsFalse()
        {
            // Arrange
            var team1 = new Team("Бригада №1");
            var team2 = new Team("Бригада №1");

            // Act & Assert
            Assert.That(team1.Equals(team2), Is.False, "Teams with the same name but different GUIDs should not be equal.");
        }

        [Test]
        public void GetHashCode_DifferentTeams_ReturnsDifferentHashCodes()
        {
            // Arrange
            var team1 = new Team("Бригада №1");
            var team2 = new Team("Бригада №2");

            // Act
            var hash1 = team1.GetHashCode();
            var hash2 = team2.GetHashCode();

            // Assert
            Assert.That(hash1, Is.Not.EqualTo(hash2));
        }
    }
}

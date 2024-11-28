// <copyright file="WorkerTests.cs" company="Земсков Н.А и Моисеенко М.А">
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
    /// Тесты для класса <see cref="Worker"/>.
    /// </summary>
    [TestFixture]
    public sealed class WorkerTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            // Arrange & Act
            var worker = new Worker("Алексей Павлов", "Worker");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(worker.WorkerName, Is.EqualTo("Алексей Павлов"));
                Assert.That(worker.Role, Is.EqualTo("Worker"));
                Assert.That(worker.TeamId, Is.Null);
                Assert.That(worker.WorkerId, Is.Not.EqualTo(Guid.Empty));
            });
        }

        [Test]
        public void Ctor_WithTeamId_Success()
        {
            // Arrange
            var teamId = Guid.NewGuid();

            // Act
            var worker = new Worker("Алексей Павлов", "Worker", teamId);

            // Assert
            Assert.That(worker.TeamId, Is.EqualTo(teamId));
        }

        [Test]
        public void Ctor_NullWorkerName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Worker(null!, "Worker"));
        }

        [Test]
        public void Ctor_EmptyWorkerName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Worker("", "Worker"));
        }

        [Test]
        public void Ctor_NullRole_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Worker("Алексей Павлов", null!));
        }

        [Test]
        public void Ctor_EmptyRole_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Worker("Алексей Павлов", ""));
        }

        [Test]
        public void AssignToTeam_ValidTeamId_Success()
        {
            // Arrange
            var worker = new Worker("Алексей Павлов", "Worker");
            var teamId = Guid.NewGuid();

            // Act
            worker.AssignToTeam(teamId);

            // Assert
            Assert.That(worker.TeamId, Is.EqualTo(teamId));
        }

        [Test]
        public void RemoveFromTeam_RemovesTeamAssignment()
        {
            // Arrange
            var teamId = Guid.NewGuid();
            var worker = new Worker("Алексей Павлов", "Worker", teamId);

            // Act
            worker.RemoveFromTeam();

            // Assert
            Assert.That(worker.TeamId, Is.Null);
        }

        [Test]
        public void ToString_WithoutTeam_ReturnsExpected()
        {
            // Arrange
            var worker = new Worker("Алексей Павлов", "Worker");

            // Act
            var result = worker.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("Алексей Павлов - Worker (Без команды)"));
        }

        [Test]
        public void ToString_WithTeam_ReturnsExpected()
        {
            // Arrange
            var teamId = Guid.NewGuid();
            var worker = new Worker("Алексей Павлов", "Worker", teamId);

            // Act
            var result = worker.ToString();

            // Assert
            StringAssert.Contains("Алексей Павлов - Worker", result);
            StringAssert.Contains(teamId.ToString(), result);
        }

        [Test]
        public void Equals_SameData_ReturnsFalse()
        {
            // Arrange
            var worker1 = new Worker("Алексей Павлов", "Worker");
            var worker2 = new Worker("Алексей Павлов", "Worker");

            // Act & Assert
            Assert.That(worker1.Equals(worker2), Is.False, "Workers with the same data but different GUIDs should not be equal.");
        }

        [Test]
        public void GetHashCode_DifferentWorkers_ReturnsDifferentHashCodes()
        {
            // Arrange
            var worker1 = new Worker("Алексей Павлов", "Worker");
            var worker2 = new Worker("Мария Смирнова", "Master");

            // Act
            var hash1 = worker1.GetHashCode();
            var hash2 = worker2.GetHashCode();

            // Assert
            Assert.That(hash1, Is.Not.EqualTo(hash2));
        }
    }
}

using System;
using CodingCase.WebApi.Infrastructure.Models;
using Xunit;

namespace CodingCase.Tests.UnitTests.ModelTests
{
    public class LockTests
    {
        [Fact]
        public void Lock_Partial_Plus_Transitive_Match_Test()
        {
            // Arrange
            var building = new Building
            {
                Id = new Guid(),
                Description = "TestBuildingDescription",
                Name = "TestBuildingName",
                ShortCut = "TestBuildingShortCut"
            };

            var currentLock = new Lock
            {
                Id = new Guid(),
                Description = "TestDescription",
                Name = "TestName",
                BuildingId = building.Id,
                Building = building,
                Floor = "TestFloor",
                RoomNumber = "TestRoomNumber",
                SerialNumber = "TestSerialNumber",
                Type = "TestType"
            };

            currentLock.Building = building;
            // Act
            var weight = currentLock.GetWeight("Test");

            // Assert
            Assert.Equal(52, weight);
        }

        [Fact]
        public void Lock_Full_Plus_Transitive_Match_Test()
        {
            // Arrange
            var building = new Building
            {
                Id = new Guid(),
                Description = "Test",
                Name = "Test",
                ShortCut = "Test"
            };

            var currentLock = new Lock
            {
                Id = new Guid(),
                Description = "Test",
                Name = "Test",
                BuildingId = building.Id,
                Building = building,
                Floor = "Test",
                RoomNumber = "Test",
                SerialNumber = "Test",
                Type = "Test"
            };

            currentLock.Building = building;
            // Act
            var weight = currentLock.GetWeight("Test");

            // Assert
            Assert.Equal(520, weight);
        }

    }
}

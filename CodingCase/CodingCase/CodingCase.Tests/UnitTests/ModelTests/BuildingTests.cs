using System;
using CodingCase.WebApi.Infrastructure.Models;
using Xunit;

namespace CodingCase.Tests.UnitTests.ModelTests
{
    public class BuildingTests
    {
        [Fact]
        public void Building_Partial_Match_Test()
        {
            // Arrange
            var building = new Building
            {
                Id = new Guid(),
                Description = "BuildingDescription",
                Name = "BuildingName",
                ShortCut = "BuildingShortCut"
            };

            // Act
            var weight = building.GetWeight("Building");

            // Assert
            Assert.Equal(21, weight);
        }

        [Fact]
        public void Building_Full_Match_Test()
        {
            // Arrange
            var building = new Building
            {
                Id = new Guid(),
                Description = "BuildingDescription",
                Name = "BuildingName",
                ShortCut = "BuildingShortCut"
            };

            // Act
            var weight = building.GetWeight("BuildingDescription");

            // Assert
            Assert.Equal(50, weight);
        }

        [Fact]
        public void Building_Full_Plus_Partial_Match_Test()
        {
            // Arrange
            var building = new Building
            {
                Id = new Guid(),
                Description = "Building",
                Name = "BuildingName",
                ShortCut = "BuildingShortCut"
            };

            // Act
            var weight = building.GetWeight("Building");

            // Assert
            Assert.Equal(66, weight);
        }
    }
}

using System;
using CodingCase.WebApi.Infrastructure.Models;
using Xunit;

namespace CodingCase.Tests.UnitTests.ModelTests
{
    public class MediumTests
    {
        [Fact]
        public void Medium_Partial_Plus_Transitive_Match_Test()
        {
            // Arrange
            var group = new Group
            {
                Id = new Guid(),
                Description = "TestGroupDescription",
                Name = "TestGroupName",
            };

            var medium = new Medium
            {
                Id = new Guid(),
                Description = "TestDescription",
                SerialNumber = "TestSerialNumber",
                Type = "TestType",
                Group = group,
                GroupId = group.Id,
                Owner = "TestOwner"
            };

            medium.Group = group;

            // Act
            var weight = medium.GetWeight("Test");

            // Assert
            Assert.Equal(35, weight);
        }

        [Fact]
        public void Medium_Full_Plus_Transitive_Match_Test()
        {
            // Arrange
            var group = new Group
            {
                Id = new Guid(),
                Description = "Test",
                Name = "Test",
            };

            var medium = new Medium
            {
                Id = new Guid(),
                Description = "Test",
                SerialNumber = "Test",
                Type = "Test",
                Group = group,
                GroupId = group.Id,
                Owner = "Test"
            };

            medium.Group = group;

            // Act
            var weight = medium.GetWeight("Test");

            // Assert
            Assert.Equal(350, weight);
        }

    }
}

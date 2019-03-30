using System;
using CodingCase.WebApi.Infrastructure.Models;
using Xunit;

namespace CodingCase.Tests.UnitTests.ModelTests
{
    public class GroupTests
    {
        [Fact]
        public void Group_Partial_Match_Test()
        {
            // Arrange
            var group = new Group
            {
                Id = new Guid(),
                Description = "GroupDescription",
                Name = "GroupName",
            };

            // Act
            var weight = group.GetWeight("group");

            // Assert
            Assert.Equal(14, weight);
        }

        [Fact]
        public void Group_Full_Match_Test()
        {
            // Arrange
            var group = new Group
            {
                Id = new Guid(),
                Description = "GroupDescription",
                Name = "GroupName",
            };

            // Act
            var weight = group.GetWeight("GroupName");

            // Assert
            Assert.Equal(90, weight);
        }

        [Fact]
        public void Group_Full_Plus_Partial_Match_Test()
        {
            // Arrange
            var group = new Group
            {
                Id = new Guid(),
                Description = "Group",
                Name = "GroupName",
            };

            // Act
            var weight = group.GetWeight("Group");

            // Assert
            Assert.Equal(59, weight);
        }
    }
}

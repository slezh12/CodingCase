using System;
using System.Collections.Generic;
using System.Linq;
using CodingCase.WebApi.Infrastructure;
using CodingCase.WebApi.Infrastructure.Abstraction;
using CodingCase.WebApi.Infrastructure.Models;
using Xunit;

namespace CodingCase.Tests.UnitTests
{
    public class WeightFilterTests
    {
        [Fact]
        public void WeightFilterTest()
        {
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
                Description = "TestDescription",
                Name = "TestName",
                BuildingId = building.Id,
                Building = building,
                Floor = "TestFloor",
                RoomNumber = "TestRoomNumber",
                SerialNumber = "TestSerialNumber",
                Type = "TestType"
            };

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

            var elements = new List<Element>
            {
                building,
                currentLock,
                group,
                medium
            };

            var weightFilter = new WeightFilter();

            weightFilter.SetElements(elements);

            var result = weightFilter.Filter("test");

            Assert.Equal(428, result.Sum(x => x.Weight));
            Assert.Equal(210, result[0].Weight);
            Assert.Equal(169, result[1].Weight);
            Assert.Equal(35, result[2].Weight);
            Assert.Equal(14, result[3].Weight);
        }
    }
}

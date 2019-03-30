using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;
using CodingCase.WebApi.Infrastructure.Abstraction;
using CodingCase.WebApi.Infrastructure.Models;

namespace CodingCase.WebApi.Infrastructure
{
    public class WeightFilter : IWeightFilter
    {
        private List<Element> _elements;

        public WeightFilter() { }

        public WeightFilter(IConfiguration configuration)
        {
            _elements = new List<Element>();

            var json = "";
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                json = wc.DownloadString(configuration.GetSection("JsonUrl").Value);
            }

            var dataFile = Newtonsoft.Json.JsonConvert.DeserializeObject<DataFile>(json);
            InitBuildings(dataFile);
            InitLocks(dataFile);
            InitGroups(dataFile);
            InitMedia(dataFile);
        }

        private void InitBuildings(DataFile dataFile)
        {
            foreach (var building in dataFile.Buildings)
            {
                _elements.Add(building);
            }
        }

        private void InitLocks(DataFile dataFile)
        {
            foreach (var currentLock in dataFile.Locks)
            {
                currentLock.Building = dataFile.Buildings.Single(x => x.Id == currentLock.BuildingId);
                _elements.Add(currentLock);
            }
        }

        private void InitGroups(DataFile dataFile)
        {
            foreach (var group in dataFile.Groups)
            {
                _elements.Add(group);
            }
        }

        private void InitMedia(DataFile dataFile)
        {
            foreach (var medium in dataFile.Media)
            {
                medium.Group = dataFile.Groups.Single(x => x.Id == medium.GroupId);
                _elements.Add(medium);
            }
        }


        public List<Result> Filter(string filter)
        {
            return _elements.Select(x => new Result
            {
                Guid = x.Id,
                Description = x.Description,
                Weight = x.GetWeight(filter),
                ObjectType = x.GetType().Name
            }).OrderByDescending(x => x.Weight).ToList();
        }

        public void SetElements(List<Element> elements)
        {
            _elements = elements;
        }
    }
}

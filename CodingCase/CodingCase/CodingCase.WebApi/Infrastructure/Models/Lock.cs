using System;
using CodingCase.WebApi.Infrastructure.Abstraction;
using CodingCase.WebApi.Infrastructure.Attributes;

namespace CodingCase.WebApi.Infrastructure.Models
{
    public class Lock : Element
    {
        public Guid BuildingId { get; set; }
        [Weight(3)]
        public string Type { get; set; }
        [Weight(10)]
        public string Name { get; set; }
        [Weight(8)]
        public string SerialNumber { get; set; }
        [Weight(6)]
        public string Floor { get; set; }
        [Weight(6)]
        public string RoomNumber { get; set; }
        [Weight(6)]
        public override string Description { get; set; }

        public Building Building { get; set; }

        public override int GetWeight(string filter)
        {
            return base.GetWeight(filter) + GetWeightForObject<LockTransitiveWeightAttribute>(Building, filter);
        }
    }
}

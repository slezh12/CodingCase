using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CodingCase.WebApi.Infrastructure.Abstraction;
using CodingCase.WebApi.Infrastructure.Attributes;


namespace CodingCase.WebApi.Infrastructure.Models
{
    public class Medium : Element
    {
        public Guid GroupId { get; set; } 

        [Weight(3)]
        public string Type { get; set; }

        [Weight(10)]
        public string Owner { get; set; }

        [Weight(8)]
        public string SerialNumber { get; set; }

        [Weight(6)]
        public override string Description { get; set; } 

        public Group Group { get; set; }

        public override int GetWeight(string filter)
        {
            return base.GetWeight(filter) + GetWeightForObject<MediumTransitiveWeightAttribute>(Group, filter);
        }
    }
}

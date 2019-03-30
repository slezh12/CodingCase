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
    public class Group : Element
    {
        [Weight(9)]
        [MediumTransitiveWeight(8)]
        public string Name { get; set; }

        [Weight(5)]
        [MediumTransitiveWeight(0)]
        public override string Description { get; set; } 
    }
}

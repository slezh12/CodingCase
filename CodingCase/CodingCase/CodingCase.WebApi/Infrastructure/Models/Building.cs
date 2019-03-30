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
    public class Building : Element
    { 
        [Weight(7)]
        [LockTransitiveWeight(5)]
        public string ShortCut { get; set; } 

        [Weight(9)]
        [LockTransitiveWeight(8)]
        public string Name { get; set; } 

        [Weight(5)]
        [LockTransitiveWeight(0)]
        public override string Description { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingCase.WebApi.Infrastructure.Abstraction;

namespace CodingCase.WebApi.Infrastructure.Attributes
{
    class MediumTransitiveWeightAttribute : Attribute, IWeight
    {
        public int Weight { get; set; }

        public MediumTransitiveWeightAttribute(int weight)
        {
            Weight = weight;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingCase.WebApi.Infrastructure.Abstraction;

namespace CodingCase.WebApi.Infrastructure.Attributes
{
    class LockTransitiveWeightAttribute : Attribute, IWeight
    {
        public int Weight { get; set; }

        public LockTransitiveWeightAttribute(int weight)
        {
            Weight = weight;
        }
    }
}

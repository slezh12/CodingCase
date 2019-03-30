using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCase.Web.Models
{
    public class ResultView
    {
        public Guid Guid { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public string ObjectType { get; set; }
    }
}

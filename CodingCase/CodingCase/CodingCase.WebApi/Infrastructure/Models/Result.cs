using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingCase.WebApi.Infrastructure.Models
{
    public class Result
    {
        public Guid Guid { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public string ObjectType { get; set; }
    }
}
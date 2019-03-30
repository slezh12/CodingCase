using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodingCase.WebApi.Infrastructure.Models;

namespace CodingCase.WebApi.Infrastructure.Abstraction
{
    public interface IWeightFilter
    {
        List<Result> Filter(string filter);
    }
}
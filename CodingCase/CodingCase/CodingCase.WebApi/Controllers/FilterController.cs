using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingCase.WebApi.Infrastructure.Abstraction;
using CodingCase.WebApi.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingCase.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private IWeightFilter _weightFilter;
        public FilterController(IWeightFilter weightFilter)
        {
            _weightFilter = weightFilter;
        }

        // GET: api/Filter/5
        [HttpGet("{searchFilter?}")]
        public List<Result> GetWeightFilteredElements(string searchFilter = "")
        {
            return _weightFilter.Filter(searchFilter);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CodingCase.WebApi.Infrastructure.Models
{
    public class DataFile
    {
        public List<Building> Buildings { get; set; } = new List<Building>();
        public List<Lock> Locks { get; set; } = new List<Lock>();
        public List<Group> Groups { get; set; } = new List<Group>();
        public List<Medium> Media { get; set; } = new List<Medium>();
    }
}

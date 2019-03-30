using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using CodingCase.Web.Models;
using Microsoft.Extensions.Configuration;
using X.PagedList;

namespace CodingCase.Web.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            string json;
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                json = wc.DownloadString(_configuration.GetSection("WebApiUrl").Value + "filter/" + searchString);
            }

            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultView>>(json);

            var pageSize = 10;
            var pageNumber = (page ?? 1);
            return View(data.ToPagedList(pageNumber, pageSize));
        }


    }
}

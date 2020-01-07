using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarvedRock.Web.Models;
using CarvedRock.Web.Clients;

namespace CarvedRock.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly ProductGraphClient _client;

        public HomeController(ILogger<HomeController> logger, ProductGraphClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetProducts();
            return View(response);
        }

    }
}

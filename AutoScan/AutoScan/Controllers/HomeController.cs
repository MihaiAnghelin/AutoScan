using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoScan.Models;
using Newtonsoft.Json;

namespace AutoScan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static HttpClient _client;

        public HomeController(ILogger<HomeController> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        private static async Task<List<Offer>> GetOffersAsync(string path)
        {
            var response = await _client.GetAsync(path);
            string offerStr = null;
            if (response.IsSuccessStatusCode)
            {
                offerStr = await response.Content.ReadAsStringAsync();
            }

            var offers = JsonConvert.DeserializeObject<List<Offer>>(offerStr);

            return offers;
        }

        public async Task<IActionResult> Index()
        {
            var offers = await GetOffersAsync("");

            return View(offers);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
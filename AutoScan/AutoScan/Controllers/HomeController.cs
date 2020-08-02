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
        private static HttpClient _client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private static async Task<List<Offer>> GetOffersAsync(string path)
        {
            var response = await _client.GetAsync(path);
            Offers JsonList = null;
            if (response.IsSuccessStatusCode)
            {
                JsonList = await response.Content.ReadAsAsync<Offers>();
            }

            //var list = new List<Offer>();

            //foreach (var offer in JsonList)
            //{
            //    var item = JsonConvert.DeserializeObject<Offer>(offer);

            //    list.Add(item);
            //}

            return JsonList.clientads;
        }

        public async Task<IActionResult> Index()
        {
            var offers = await GetOffersAsync("http://autoscan.unicorn-tech.org:5000/clientads");

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
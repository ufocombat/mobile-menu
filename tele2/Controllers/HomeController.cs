using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tele2.Models;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace tele2.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment _env;

        public HomeController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var owners = System.IO.File.ReadAllText(System.IO.Path.Combine(_env.WebRootPath, "2_18_0.json"));
            var json = owners.ToString();
            var jsonModel = JsonSerializer.Deserialize<List<MenuClass>>(json, options);

            ViewBag.list = jsonModel;
            ViewBag.json = json;
            return View();
        }

        [HttpPost]
        public IActionResult Ren([FromBody] string data)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                
                var jsonModel = JsonSerializer.Deserialize<List<MenuClass>>(data, options);
                return PartialView("Menu", jsonModel);
            }
            catch (Exception e)
                {
                return PartialView("Error", e.Message);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

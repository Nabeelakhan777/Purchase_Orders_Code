using Microsoft.AspNetCore.Mvc;
using Purchase_Order.Interfaces;
using Purchase_Order.Models;
using Purchase_Order.Models.API_DTOs.Requests;
using Purchase_Order.Models.DbDTOs.Responses;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Purchase_Order.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IGetOrders data;
        public HomeController(ILogger<HomeController> logger, IGetOrders orders)
        {
            _logger = logger;
            data = orders;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}
        public ActionResult SaveAllData([FromBody] CreateRequest SaveRequest) {
           
            string response = data.savedata(SaveRequest.SaveRequest);
            return View(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Privacy()
        {
            return View(data.getallOrders());
        }
    }
}
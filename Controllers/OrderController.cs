
using Microsoft.AspNetCore.Mvc;
using Purchase_Order.Interfaces;


namespace Purchase_Order.Controllers
{
    public class OrderController : Controller
    {
        public readonly IGetOrders data;
        public OrderController(IGetOrders orders) {
        data = orders;
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetAllOrders() 
        {
               
            return View(data.getallOrders());
        }



    }
}

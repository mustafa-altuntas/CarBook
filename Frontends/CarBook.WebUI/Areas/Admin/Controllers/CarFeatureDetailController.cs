using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarFeatureDetailController : Controller
    {
        public IActionResult Index(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}

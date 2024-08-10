using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CropController : Controller
    {
        public IActionResult addCrop()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace TANE.Kunde.Api.Controllers
{
    public class KundeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

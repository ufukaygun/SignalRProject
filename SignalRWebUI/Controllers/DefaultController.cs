using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    //Anasayfa Olacak kısım
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

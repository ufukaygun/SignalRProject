using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        //Kullanıcı arayüzü 
        public IActionResult Index()
        {
            return View();
        }
    }
}

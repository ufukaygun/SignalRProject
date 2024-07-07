using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        // _httpClientFactory adında field oluşturduk.
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            //İstemci oluşturduk
            var client = _httpClientFactory.CreateClient();
            //GetAsync verileri listelemek için kullanılan metod
            var responseMessage = await client.GetAsync("http://localhost:5205/api/Product");

            //İşlem başarılı dönerse Json dan gelen içeriği string olarak oku
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //values değişkenin içerisini oku. DeserializeObject Json bir datayı çözüp normal metne çevirir. Listeleme
            //SeriAlize da bir metni Json formatına çevirir. Ekle Güncelle
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }
    }
}

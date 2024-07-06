using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;
using SignalRWebUI.Dtos.SliderDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    //Consume İşlemi
    public class _DefaultAboutComponentPartial:ViewComponent
    {
        // _httpClientFactory adında field oluşturduk.
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            //İstemci oluşturduk
            var client = _httpClientFactory.CreateClient();
            //GetAsync verileri listelemek için kullanılan metod
            var responseMessage = await client.GetAsync("http://localhost:5205/api/About");

            //İşlem başarılı dönerse Json dan gelen içeriği string olarak oku
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //values değişkenin içerisini oku. DeserializeObject Json bir datayı çözüp normal metne çevirir. Listeleme
            //SeriAlize da bir metni Json formatına çevirir. Ekle Güncelle
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            return View(values);
        }
    }
}

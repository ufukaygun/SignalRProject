using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.TestimonialDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
        // _httpClientFactory adında field oluşturduk.
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultTestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            //İstemci oluşturduk
            var client = _httpClientFactory.CreateClient();
            //GetAsync verileri listelemek için kullanılan metod
            var responseMessage = await client.GetAsync("http://localhost:5205/api/Testimonial");

            //İşlem başarılı dönerse Json dan gelen içeriği string olarak oku
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //values değişkenin içerisini oku. DeserializeObject Json bir datayı çözüp normal metne çevirir. Listeleme
            //SeriAlize da bir metni Json formatına çevirir. Ekle Güncelle
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
            return View(values);
        }
    }
}

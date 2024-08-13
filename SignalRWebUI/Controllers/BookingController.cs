using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    //Api nin Consume edilme işlemi oluşturmuş olduğumuz apiyi tüketmemiz anlamına geliyor.
    //Amaç Json olarak gelen datayı tabloda göstermek için
    public class BookingController : Controller
    {
        // _httpClientFactory adında field oluşturduk.
        private readonly IHttpClientFactory _httpClientFactory;
        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //Asekron Çalışıyrouz Burada(Task)
        public async Task<IActionResult> Index()
        {
            //İstemci oluşturduk
            var client = _httpClientFactory.CreateClient();
            //GetAsync verileri listelemek için kullanılan metod
            var responseMessage = await client.GetAsync("http://localhost:5205/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                //İşlem başarılı dönerse Json dan gelen içeriği string olarak oku
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //values değişkenin içerisini oku. DeserializeObject Json bir datayı çözüp normal metne çevirir. Listeleme
                //SeriAlize da bir metni Json formatına çevirir. Ekle Güncelle
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "Rezervasyon Alındı";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5205/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
            
        }
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5205/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            //ilk önce güncellemek istediğimiz veriyi getiriyoruz.
            var responseMessage = await client.GetAsync($"http://localhost:5205/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                //güncelleyeceğimiz veriyi Dto aracılığıyla çağırıyruz
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //PutAsync güncelleme işlemi yapacak
            var responseMessage = await client.PutAsync("http://localhost:5205/api/Booking/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> BookingStatusApproved(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"http://localhost:5205/api/Booking/BookingStatusApproved/{id}");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> BookingStatusCancelled(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"http://localhost:5205/api/Booking/BookingStatusCancelled/{id}");
            return RedirectToAction("Index");
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.NotificationDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class NotificationsController : Controller
    {
        // _httpClientFactory adında field oluşturduk.
        private readonly IHttpClientFactory _httpClientFactory;
        public NotificationsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //Asekron Çalışıyrouz Burada(Task)
        public async Task<IActionResult> Index()
        {
            //İstemci oluşturduk
            var client = _httpClientFactory.CreateClient();
            //GetAsync verileri listelemek için kullanılan metod
            var responseMessage = await client.GetAsync("http://localhost:5205/api/Notification");
            if (responseMessage.IsSuccessStatusCode)
            {
                //İşlem başarılı dönerse Json dan gelen içeriği string olarak oku
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //values değişkenin içerisini oku. DeserializeObject Json bir datayı çözüp normal metne çevirir. Listeleme
                //SeriAlize da bir metni Json formatına çevirir. Ekle Güncelle
                var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createNotificationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5205/api/Notification", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5205/api/Notification/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            //ilk önce güncellemek istediğimiz veriyi getiriyoruz.
            var responseMessage = await client.GetAsync($"http://localhost:5205/api/Notification/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                //güncelleyeceğimiz veriyi Dto aracılığıyla çağırıyruz
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);
                return View(values);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateNotificationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //PutAsync güncelleme işlemi yapacak
            var responseMessage = await client.PutAsync("http://localhost:5205/api/Notification/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
		public async Task<IActionResult> NotificationStatusChangeToTrue(int id)
		{
			var client = _httpClientFactory.CreateClient();
			//ilk önce güncellemek istediğimiz veriyi getiriyoruz.
			await client.GetAsync($"http://localhost:5205/api/Notification/NotificationStatusChangeToTrue/{id}");
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> NotificationStatusChangeToFalse(int id)
		{
			var client = _httpClientFactory.CreateClient();
			//ilk önce güncellemek istediğimiz veriyi getiriyoruz.
			await client.GetAsync($"http://localhost:5205/api/Notification/NotificationStatusChangeToFalse/{id}");
			return RedirectToAction("Index");
		}
	}
}

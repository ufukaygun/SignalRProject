using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SliderDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class SliderController : Controller
	{
		// _httpClientFactory adında field oluşturduk.
		private readonly IHttpClientFactory _httpClientFactory;
		public SliderController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		//Asekron Çalışıyrouz Burada(Task)
		public async Task<IActionResult> Index()
		{
			//İstemci oluşturduk
			var client = _httpClientFactory.CreateClient();
			//GetAsync verileri listelemek için kullanılan metod
			var responseMessage = await client.GetAsync("http://localhost:5205/api/Slider");
			if (responseMessage.IsSuccessStatusCode)
			{
				//İşlem başarılı dönerse Json dan gelen içeriği string olarak oku
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				//values değişkenin içerisini oku. DeserializeObject Json bir datayı çözüp normal metne çevirir. Listeleme
				//SeriAlize da bir metni Json formatına çevirir. Ekle Güncelle
				var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateSlider()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createSliderDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5205/api/Slider", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
			;
		}
		public async Task<IActionResult> DeleteSlider(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"http://localhost:5205/api/Slider/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateSlider(int id)
		{
			var client = _httpClientFactory.CreateClient();
			//ilk önce güncellemek istediğimiz veriyi getiriyoruz.
			var responseMessage = await client.GetAsync($"http://localhost:5205/api/Slider/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				//güncelleyeceğimiz veriyi Dto aracılığıyla çağırıyruz
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateSliderDto>(jsonData);
				return View(values);

			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateSliderDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			//PutAsync güncelleme işlemi yapacak
			var responseMessage = await client.PutAsync("http://localhost:5205/api/Slider/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}
	}
}

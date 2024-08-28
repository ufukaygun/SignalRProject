using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.DiscountDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	//Api nin Consume edilme işlemi oluşturmuş olduğumuz apiyi tüketmemiz anlamına geliyor.
	//Amaç Json olarak gelen datayı tabloda göstermek için
	public class DiscountController : Controller
	{
		// _httpClientFactory adında field oluşturduk.
		private readonly IHttpClientFactory _httpClientFactory;
		public DiscountController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		//Asekron Çalışıyrouz Burada(Task)
		public async Task<IActionResult> Index()
		{
			//İstemci oluşturduk
			var client = _httpClientFactory.CreateClient();
			//GetAsync verileri listelemek için kullanılan metod
			var responseMessage = await client.GetAsync("http://localhost:5205/api/Discount");
			if (responseMessage.IsSuccessStatusCode)
			{
				//İşlem başarılı dönerse Json dan gelen içeriği string olarak oku
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				//values değişkenin içerisini oku. DeserializeObject Json bir datayı çözüp normal metne çevirir. Listeleme
				//SeriAlize da bir metni Json formatına çevirir. Ekle Güncelle
				var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateDiscount()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createDiscountDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5205/api/Discount", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
			;
		}
		public async Task<IActionResult> DeleteDiscount(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"http://localhost:5205/api/Discount/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> UpdateDiscount(int id)
		{
			var client = _httpClientFactory.CreateClient();
			//ilk önce güncellemek istediğimiz veriyi getiriyoruz.
			var responseMessage = await client.GetAsync($"http://localhost:5205/api/Discount/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				//güncelleyeceğimiz veriyi Dto aracılığıyla çağırıyruz
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateDiscountDto>(jsonData);
				return View(values);

			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateDiscountDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			//PutAsync güncelleme işlemi yapacak
			var responseMessage = await client.PutAsync("http://localhost:5205/api/Discount/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}

		public async Task<IActionResult> ChangeStatusTrue(int id)
		{
			
				//İstemci oluşturduk
				var client = _httpClientFactory.CreateClient();
				//GetAsync verileri listelemek için kullanılan metod
				await client.GetAsync($"http://localhost:5205/api/Discount/ChangeStatusTrue/{id}");
				return RedirectToAction("Index");

		}
		public async Task<IActionResult> ChangeStatusFalse(int id)
		{
			//İstemci oluşturduk
			var client = _httpClientFactory.CreateClient();
			//GetAsync verileri listelemek için kullanılan metod
			await client.GetAsync($"http://localhost:5205/api/Discount/ChangeStatusFalse/{id}");
			return RedirectToAction("Index");
		}
	}
}

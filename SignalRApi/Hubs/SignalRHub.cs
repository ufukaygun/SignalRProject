using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	//Hub bir sunucu görevi görecek.Biz dağıtım işlerini Hub sınıfı neyse onun üzerinden yapıcaz. Sınıfımız SignalRHub.
	//Hub sınıfı aracılığıyla biz uygulamamızın servera olan kısmını tanıtmış olduk.
	public class SignalRHub : Hub
	{
        //Servisler yazıldı
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public SignalRHub(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task SendCategoryCount()
        {
            // Kategorilerin sayısını alıyoruz
            var value = _categoryService.TCategoryCount();

            // Bu metot ile gelen değeri client tarafına gönderiyoruz
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
        public async Task SendProductCount()
        {
            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);
        }
        public async Task ActivePassiveCategoryCount()
        {
            var value3 = _categoryService.TActiveCategoryCount();
            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);
        }
    }
}

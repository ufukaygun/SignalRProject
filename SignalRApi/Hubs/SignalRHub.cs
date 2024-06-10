using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	//Hub bir sunucu görevi görecek.Biz dağıtım işlerini Hub sınıfı neyse onun üzerinden yapıcaz. Sınıfımız SignalRHub.
	//Hub sınıfı aracılığıyla biz uygulamamızın servera olan kısmını tanıtmış olduk.
	public class SignalRHub : Hub
	{
        private readonly SignalRContext _context;

        public SignalRHub(SignalRContext context)
        {
            _context = context;
        }

        public async Task SendCategoryCount()
        {
            // Kategorilerin sayısını alıyoruz
            var value = _context.Categories.Count();

            // Bu metot ile gelen değeri client tarafına gönderiyoruz
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
    }
}

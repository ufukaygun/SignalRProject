using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	//Hub bir sunucu görevi görecek.Biz dağıtım işlerini Hub sınıfı neyse onun üzerinden yapıcaz. Sınıfımız SignalRHub.
	//Hub sınıfı aracılığıyla biz uygulamamızın servera olan kısmını tanıtmış olduk.
	public class SignalRHub : Hub
	{
		SignalRContext context = new SignalRContext();
        private CancellationToken value;

        public async Task SendCategoryCount()
		{
			var vaşue = context.Categories.Count();
			//Bu metod ile gelen değeri client tarafına göndericez
			await Clients.All.SendAsync("ReceiveCategoryCount", value);
		}
	}
}

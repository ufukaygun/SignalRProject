using Microsoft.AspNetCore.SignalR;

namespace SignalRApi.Hubs
{
	//Hub bir sunucu görevi görecek.Biz dağıtım işlerini Hub sınıfı neyse onun üzerinden yapıcaz. Sınıfımız SignalRHub.
	//Hub sınıfı aracılığıyla biz uygulamamızın servera olan kısmını tanıtmış olduk.
	public class SignalRHub : Hub
	{
	}
}

using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
	//NetCore.MailKit paketi yüklendi
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(CreateMailDto createMailDto)
		{
			MimeMessage mimeMessage = new MimeMessage();

			//MailboxAddress sınıfından nesne örneği alındı From ifadesi mailin kimden gideceğini gösterir
			MailboxAddress mailboxAddressFrom = new MailboxAddress("UA Restoran Rezervasyon", "u.aygun869@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom);

			//mailboxAddressTo buda mailin kime gideceği
			MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
			mimeMessage.To.Add(mailboxAddressTo);

			//mail içeriği
			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = createMailDto.Body;
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			mimeMessage.Subject = createMailDto.Subject;

			//Şifreleme
			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);
			client.Authenticate("u.aygun869@gmail.com", "dxyc motg oyvq fzza");

			client.Send(mimeMessage);
			client.Disconnect(true);

			return RedirectToAction("Index", "Category");
		}
	}
}

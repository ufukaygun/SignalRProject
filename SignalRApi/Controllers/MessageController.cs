using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService  _messageService;
		public MessageController(IMessageService messageService )
		{
			_messageService = messageService;
		}
		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _messageService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			Message message = new Message()
			{
				Mail = createMessageDto.Mail,
				MessageContent = createMessageDto.MessageContent,
				MessageSendDate = DateTime.Now,
				NameSurname = createMessageDto.NameSurname,
				Phone = createMessageDto.Phone,
				Status = false,
				Subject = createMessageDto.Subject
			};
			_messageService.TAdd(message);
			return Ok("Mesaj Başarılı bir şekilde gönderildi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var value = _messageService.TGetByID(id);
			_messageService.TDelete(value);
			return Ok("Mesaj Silindi");
		}
		//Güncelleme için kullanılıyor
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			Message message = new Message()
			{
				Mail = updateMessageDto.Mail,
				MessageContent = updateMessageDto.MessageContent,
				MessageSendDate = updateMessageDto.MessageSendDate,
				NameSurname = updateMessageDto.NameSurname,
				Phone = updateMessageDto.Phone,
				Status = updateMessageDto.Status,
				Subject = updateMessageDto.Subject,
				MessageID = updateMessageDto.MessageID,
			};
			_messageService.TUpdate(message);
			return Ok("Mesaj Alanı Güncellendi");
		}
		//id ye göre getirme işlemi
		//Api de aynı Atribute aynı formatta birden fazla kullanılırsa hata verir.Hata vermemesi için içine isim yazıyoruz.
		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var value = _messageService.TGetByID(id);
			return Ok(value);
		}
	}
}

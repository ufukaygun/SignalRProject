using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
	public class MessageMenager : IMessageService
	{
		private readonly IMessageDal _messageDal;

		public MessageMenager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public void TAdd(Message entity)
		{
			_messageDal.Add(entity);
		}

		public void TDelete(Message entity)
		{
			_messageDal.Delete(entity);	
		}

		public List<Message> TGetAll()
		{
			return _messageDal.GetAll();
		}

		public Message TGetByID(int id)
		{
			return _messageDal.GetByID(id);
		}

		public void TUpdate(Message entity)
		{
			_messageDal.Update(entity);
		}
	}
}

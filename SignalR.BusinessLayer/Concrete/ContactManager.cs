using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDAL _contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void TAdd(Contact entity)
        {
           _contactDAL.Add(entity); 
        }

        public void TDelete(Contact entity)
        {
            _contactDAL.Delete(entity);
        }

        public List<Contact> TGetAll()
        {
            return _contactDAL.GetAll();
        }

        public Contact TGetByID(int id)
        {
            return _contactDAL.GetByID(id);
        }

        public void TUpdate(Contact entity)
        {
            _contactDAL.Update(entity);
        }
    }
}

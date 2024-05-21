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
    public class AboutManager : IAboutService
    {
        //Dependency Injection uyguluyoruz.
        
        private readonly IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public void TAdd(About entity)
        {
           _aboutDAL.Add(entity);
            
        }

        public void TDelete(About entity)
        {
           _aboutDAL.Delete(entity);
        }

        public List<About> TGetAll()
        {
            return _aboutDAL.GetAll();
        }

        public About TGetByID(int id)
        {
            return _aboutDAL.GetByID(id);
        }

        public void TUpdate(About entity)
        {
            _aboutDAL.Update(entity);
        }
    }
}

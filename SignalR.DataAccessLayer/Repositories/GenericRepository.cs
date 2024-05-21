using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Repositories
{
    //Repository Design Pattren kullanıldı.CRUD işlemlerini tekrar etmememi ve Generic bir yapı üzerinde tutmamı sağlayacak
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        //nesne örneği oluşturuldu
        //Başka zaman yeni yazacapımız metodu önce  IGenericDal içerisinde yazıcalacak. Sonrada burada bu metodun içerisini doldurulacak.
        private readonly SignalRContext _context;

        public GenericRepository(SignalRContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
           _context.Remove(entity);
           _context.SaveChanges();
        }

        public List<T> GetAll()
        {
           return _context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
           _context.Update(entity);
            _context.SaveChanges();
        }
    }
}

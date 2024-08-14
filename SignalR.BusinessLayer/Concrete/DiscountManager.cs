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
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDAL _discountDAL;

        public DiscountManager(IDiscountDAL discountDAL)
        {
            _discountDAL = discountDAL;
        }

        public void TAdd(Discount entity)
        {
            _discountDAL.Add(entity);
        }

        public void TChangeStatusFalse(int id)
        {
            _discountDAL.ChangeStatusFalse(id);

        }

        public void TChangeStatusTrue(int id)
        {
            _discountDAL.ChangeStatusTrue(id);
        }

        public void TDelete(Discount entity)
        {
           _discountDAL.Delete(entity);
        }

        public List<Discount> TGetAll()
        {
            return _discountDAL.GetAll();
        }

        public Discount TGetByID(int id)
        {
            return _discountDAL.GetByID(id);
        }

        public void TUpdate(Discount entity)
        {
            _discountDAL.Update(entity);
        }
    }
}

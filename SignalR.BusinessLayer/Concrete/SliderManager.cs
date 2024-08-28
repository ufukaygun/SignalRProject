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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDAL _sliderDAL;

        public SliderManager(ISliderDAL sliderDAL)
        {
            _sliderDAL = sliderDAL;
        }

        public void TAdd(Slider entity)
        {
            _sliderDAL.Add(entity);
        }

        public void TDelete(Slider entity)
        {
           _sliderDAL.Delete(entity);
        }

        public List<Slider> TGetAll()
        {
            return _sliderDAL.GetAll();
        }

        public Slider TGetByID(int id)
        {
            return _sliderDAL.GetByID(id);
        }

        public void TUpdate(Slider entity)
        {
            _sliderDAL.Update(entity);
        }
    }
}

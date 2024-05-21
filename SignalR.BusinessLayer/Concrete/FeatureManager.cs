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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDAL _featureDAL;

        public FeatureManager(IFeatureDAL featureDAL)
        {
            _featureDAL = featureDAL;
        }

        public void TAdd(Feature entity)
        {
            _featureDAL.Add(entity);
        }

        public void TDelete(Feature entity)
        {
            _featureDAL.Delete(entity);
        }

        public List<Feature> TGetAll()
        {
            return _featureDAL.GetAll();    
        }

        public Feature TGetByID(int id)
        {
            return _featureDAL.GetByID(id);
        }

        public void TUpdate(Feature entity)
        {
           _featureDAL.Update(entity);
        }
    }
}

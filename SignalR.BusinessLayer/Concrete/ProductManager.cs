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
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _productDAL;

        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public void TAdd(Product entity)
        {
            _productDAL.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDAL.Delete(entity);
        }

        public List<Product> TGetAll()
        {
            return _productDAL.GetAll();    
        }

        public Product TGetByID(int id)
        {
            return _productDAL.GetByID(id);
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDAL.GetProductsWithCategories();
        }

        public int TProductCount()
        {
            return _productDAL.ProductCount();
        }

        public void TUpdate(Product entity)
        {
            _productDAL.Update(entity);
        }
    }
}

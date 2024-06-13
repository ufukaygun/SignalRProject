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

        public string TProducNametByMaxPrice()
        {
            return _productDAL.ProducNametByMaxPrice();
        }

        public string TProducNametByMinPrice()
        {
           return _productDAL.ProducNametByMinPrice();
        }

        public int TProductCount()
        {
            return _productDAL.ProductCount();
        }

        public int TProductCountByCategoryNameDrink()
        {
            return _productDAL.ProductCountByCategoryNameDrink();
        }

        public int TProductCountByCategoryNameHamburger()
        {
            return _productDAL.ProductCountByCategoryNameHamburger();
        }

        public decimal TProductPriceAvg()
        {
            return _productDAL.ProductPriceAvg();
        }

        public decimal TProductAvgPriceByHamburger()
        {
            return _productDAL.ProductAvgPriceByHamburger();
        }

        public void TUpdate(Product entity)
        {
            _productDAL.Update(entity);
        }
    }
}

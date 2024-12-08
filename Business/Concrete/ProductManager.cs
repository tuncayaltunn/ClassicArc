using System;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(q => q.category_id == id);
        }

        public List<Product> GetByUnitPrice(float min, float max)
        {
            return _productDal.GetAll(q => q.unit_price >= min && q.unit_price <= max);
        }
    }
}


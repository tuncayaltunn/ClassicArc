using System;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfProductDal :IProductDal
	{
        List<Product> _products;

        public EfProductDal()
        {
            _products = new List<Product>
            {
               new Product{ ProductId = 1, CategoryId = 1, ProductName = "Tablo", UnitPrice = 15, UnitsInStock = 15 },
               new Product{ ProductId = 2, CategoryId = 2, ProductName = "Su", UnitPrice = 85, UnitsInStock = 1 },
            };
        }

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}


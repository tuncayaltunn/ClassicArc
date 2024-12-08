using System;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>,IProductDal
	{
        public EfProductDal()
        {

        }

        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.products
                             join c in context.categories
                             on p.category_id equals c.category_id
                             select new ProductDetailDto
                             {
                                 ProductId = p.product_id,
                                 ProductName = p.product_name,
                                 CategoryName = c.category_name,
                                 UnitsInStock = p.units_in_stock
                             };

                return result.ToList();
            }
        }
    }
}


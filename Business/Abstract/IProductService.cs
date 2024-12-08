using System;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
	public interface IProductService
	{
		List<Product> GetAll();
		List<Product> GetAllByCategoryId(int id);
		List<Product> GetByUnitPrice(float min, float max);
		List<ProductDetailDto> GetProductDetails();

    }
}


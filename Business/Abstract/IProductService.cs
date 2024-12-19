using System;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
	public interface IProductService
	{
		IDataResult<List<Product>> GetAll();
		IDataResult<List<Product>> GetAllByCategoryId(int id);
		IDataResult<List<Product>> GetByUnitPrice(float min, float max);
		IDataResult<List<ProductDetailDto>> GetProductDetails();
		IResult Add(Product product);
		IDataResult<Product> GetById(int productId);
		IResult AddTransactionalTest(Product product);
    }
}


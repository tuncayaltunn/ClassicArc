using System;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
	public interface IProductDal : IEntityRepository<Product>
	{
		List<ProductDetailDto> GetProductDetails();
	}
}


using System;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;
        private readonly ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(
                CheckIfProductCountOfCategoryCorrect(product.category_id),
                CheckIfProductNameExists(product.product_name),
                CheckIfCategoryLimitExceeded()
                );

            if (result != null)
            {
                return result;
            }

            //product.discontinued = 0;
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour > 17)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(q => q.category_id == id));
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(q => q.product_id == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(float min, float max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(q => q.unit_price >= min && q.unit_price <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }


        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var productsInCategory = _productDal.GetAll(q => q.category_id == categoryId);

            if (productsInCategory.Count >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var productsInCategory = _productDal.GetAll(q => q.product_name == productName).Any();

            if (productsInCategory)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceeded()
        {
            var result = _categoryService.GetAll();

            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceeded);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);

            if (product.unit_price < 10)
            {
                throw new Exception();
            }

            Add(product);

            return null;
        }
    }
}


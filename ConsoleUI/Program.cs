// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//Console.WriteLine("Hello, World!");

//ProductTest();

//CategoryTest();


ProductManager productManager = new ProductManager(new EfProductDal());

foreach (var item in productManager.GetProductDetails().Data)
{
    Console.WriteLine(item.ProductName + "/" + item.CategoryName);
}



static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal());

    foreach (var item in productManager.GetAll().Data)
    {
        Console.WriteLine(item.product_name);
    }
}

static void CategoryTest()
{
    CategoryManager CategoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var item in CategoryManager.GetAll())
    {
        Console.WriteLine(item.category_name);
    }
}
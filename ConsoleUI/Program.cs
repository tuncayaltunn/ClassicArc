// See https://aka.ms/new-console-template for more information
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//Console.WriteLine("Hello, World!");

//ProductTest();

//CategoryTest();


ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

var result = productManager.GetProductDetails();

if (result.Success)
{
    foreach (var item in result.Data)
    {
        Console.WriteLine(item.ProductName + "/" + item.CategoryName);
    }
}
else
{
    Console.WriteLine(result.Message);
}




static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

    var result = productManager.GetAll();

    if (result.Success)
    {
        foreach (var item in result.Data)
        {
            Console.WriteLine(item.product_name);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }

}

static void CategoryTest()
{
    CategoryManager CategoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var item in CategoryManager.GetAll().Data)
    {
        Console.WriteLine(item.category_name);
    }
}
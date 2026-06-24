using AlmacenesPorAhi.Core.Services;
using AlmacenesPorAhi.Core.ViewModels;

namespace AlmacenesPorAhi.Tests;

public class InventoryWorkflowTests
{
    [Fact]
    public void SaveProduct_AddsNewProduct()
    {
        var service = new AppDataService();
        var viewModel = new InventoryViewModel(service)
        {
            ProductName = "Leche",
            ProductPrice = 2.30m,
            ProductStock = 8
        };

        viewModel.SaveProduct();

        Assert.Contains(service.Products, product => product.Name == "Leche" && product.Price == 2.30m && product.Stock == 8);
    }

    [Fact]
    public void SaveProduct_UpdatesSelectedProduct()
    {
        var service = new AppDataService();
        var viewModel = new InventoryViewModel(service);
        var product = service.Products.First();
        viewModel.SelectedProduct = product;
        viewModel.ProductName = "Arroz Premium";
        viewModel.ProductPrice = 2.00m;
        viewModel.ProductStock = 30;

        viewModel.SaveProduct();

        Assert.Equal("Arroz Premium", product.Name);
        Assert.Equal(2.00m, product.Price);
        Assert.Equal(30, product.Stock);
    }

    [Fact]
    public void DeleteProduct_RemovesSelectedProduct()
    {
        var service = new AppDataService();
        var viewModel = new InventoryViewModel(service);
        var product = service.Products.First();
        viewModel.SelectedProduct = product;

        viewModel.DeleteProduct();

        Assert.DoesNotContain(product, service.Products);
    }
}

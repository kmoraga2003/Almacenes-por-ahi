using AlmacenesPorAhi.Core.Services;
using AlmacenesPorAhi.Core.ViewModels;

namespace AlmacenesPorAhi.Tests;

public class SalesAndReturnsTests
{
    [Fact]
    public void RegisterSale_DiscountsStock()
    {
        var service = new AppDataService();
        var viewModel = new SalesViewModel(service);
        var product = service.Products.First();
        var originalStock = product.Stock;
        viewModel.SelectedProduct = product;
        viewModel.Quantity = 3;

        viewModel.RegisterSale();

        Assert.Equal(originalStock - 3, product.Stock);
        Assert.Equal("Venta realizada correctamente.", viewModel.StatusMessage);
    }

    [Fact]
    public void RegisterReturn_IncreasesStockAndAddsHistory()
    {
        var service = new AppDataService();
        var viewModel = new ReturnsViewModel(service);
        var product = service.Products.First();
        var originalStock = product.Stock;
        viewModel.SelectedProduct = product;
        viewModel.Quantity = 2;
        viewModel.Reason = "Producto dañado";

        viewModel.RegisterReturn();

        Assert.Equal(originalStock + 2, product.Stock);
        Assert.Single(service.ReturnHistory);
        Assert.Equal("Producto dañado", service.ReturnHistory[0].Reason);
        Assert.Equal("Devolución registrada correctamente.", viewModel.StatusMessage);
    }

    [Fact]
    public void Stock_IsUpdatedAcrossSaleAndReturn()
    {
        var service = new AppDataService();
        var product = service.Products.First();

        service.RegisterSale(product, 4);
        service.RegisterReturn(product, 1, "Cliente cambió de opinión");

        Assert.Equal(17, product.Stock);
    }
}

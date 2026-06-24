using System.Collections.ObjectModel;
using AlmacenesPorAhi.Core.Helpers;
using AlmacenesPorAhi.Core.Models;
using AlmacenesPorAhi.Core.Services;

namespace AlmacenesPorAhi.Core.ViewModels;

public class InventoryViewModel : ObservableObject
{
    private readonly AppDataService _dataService;
    private Product? _selectedProduct;
    private string _productName = string.Empty;
    private decimal _productPrice;
    private int _productStock;
    private string _statusMessage = string.Empty;

    public InventoryViewModel(AppDataService dataService)
    {
        _dataService = dataService;
        Products = dataService.Products;
        SaveProductCommand = new RelayCommand(SaveProduct);
        DeleteProductCommand = new RelayCommand(DeleteProduct);
        ClearFormCommand = new RelayCommand(ClearForm);
    }

    public ObservableCollection<Product> Products { get; }

    public Product? SelectedProduct
    {
        get => _selectedProduct;
        set
        {
            if (SetProperty(ref _selectedProduct, value) && value is not null)
            {
                ProductName = value.Name;
                ProductPrice = value.Price;
                ProductStock = value.Stock;
            }
        }
    }

    public string ProductName
    {
        get => _productName;
        set => SetProperty(ref _productName, value);
    }

    public decimal ProductPrice
    {
        get => _productPrice;
        set => SetProperty(ref _productPrice, value);
    }

    public int ProductStock
    {
        get => _productStock;
        set => SetProperty(ref _productStock, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public RelayCommand SaveProductCommand { get; }

    public RelayCommand DeleteProductCommand { get; }

    public RelayCommand ClearFormCommand { get; }

    public void SaveProduct()
    {
        try
        {
            if (SelectedProduct is null)
            {
                _dataService.AddProduct(ProductName, ProductPrice, ProductStock);
                StatusMessage = "Producto agregado correctamente.";
            }
            else
            {
                _dataService.UpdateProduct(SelectedProduct, ProductName, ProductPrice, ProductStock);
                StatusMessage = "Producto actualizado correctamente.";
            }

            ClearForm();
        }
        catch (Exception ex)
        {
            StatusMessage = ex.Message;
        }
    }

    public void DeleteProduct()
    {
        if (SelectedProduct is null)
        {
            StatusMessage = "Seleccione un producto para eliminar.";
            return;
        }

        _dataService.DeleteProduct(SelectedProduct);
        StatusMessage = "Producto eliminado correctamente.";
        ClearForm();
    }

    public void ClearForm()
    {
        SelectedProduct = null;
        ProductName = string.Empty;
        ProductPrice = 0;
        ProductStock = 0;
    }
}

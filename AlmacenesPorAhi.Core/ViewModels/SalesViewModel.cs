using System.Collections.ObjectModel;
using AlmacenesPorAhi.Core.Helpers;
using AlmacenesPorAhi.Core.Models;
using AlmacenesPorAhi.Core.Services;

namespace AlmacenesPorAhi.Core.ViewModels;

public class SalesViewModel : ObservableObject
{
    private readonly AppDataService _dataService;
    private Product? _selectedProduct;
    private int _quantity;
    private string _statusMessage = string.Empty;

    public SalesViewModel(AppDataService dataService)
    {
        _dataService = dataService;
        Products = dataService.Products;
        RegisterSaleCommand = new RelayCommand(RegisterSale);
    }

    public ObservableCollection<Product> Products { get; }

    public Product? SelectedProduct
    {
        get => _selectedProduct;
        set => SetProperty(ref _selectedProduct, value);
    }

    public int Quantity
    {
        get => _quantity;
        set => SetProperty(ref _quantity, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public RelayCommand RegisterSaleCommand { get; }

    public void RegisterSale()
    {
        try
        {
            if (SelectedProduct is null)
            {
                throw new ArgumentException("Seleccione un producto.");
            }

            _dataService.RegisterSale(SelectedProduct, Quantity);
            StatusMessage = "Venta realizada correctamente.";
            Quantity = 0;
        }
        catch (Exception ex)
        {
            StatusMessage = ex.Message;
        }
    }
}

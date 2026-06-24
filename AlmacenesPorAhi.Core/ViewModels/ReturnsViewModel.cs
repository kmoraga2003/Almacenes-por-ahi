using System.Collections.ObjectModel;
using AlmacenesPorAhi.Core.Helpers;
using AlmacenesPorAhi.Core.Models;
using AlmacenesPorAhi.Core.Services;

namespace AlmacenesPorAhi.Core.ViewModels;

public class ReturnsViewModel : ObservableObject
{
    private readonly AppDataService _dataService;
    private Product? _selectedProduct;
    private int _quantity;
    private string _reason = string.Empty;
    private string _statusMessage = string.Empty;

    public ReturnsViewModel(AppDataService dataService)
    {
        _dataService = dataService;
        Products = dataService.Products;
        ReturnHistory = dataService.ReturnHistory;
        RegisterReturnCommand = new RelayCommand(RegisterReturn);
    }

    public ObservableCollection<Product> Products { get; }

    public ObservableCollection<ReturnRecord> ReturnHistory { get; }

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

    public string Reason
    {
        get => _reason;
        set => SetProperty(ref _reason, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public RelayCommand RegisterReturnCommand { get; }

    public void RegisterReturn()
    {
        try
        {
            if (SelectedProduct is null)
            {
                throw new ArgumentException("Seleccione un producto.");
            }

            _dataService.RegisterReturn(SelectedProduct, Quantity, Reason);
            StatusMessage = "Devolución registrada correctamente.";
            Quantity = 0;
            Reason = string.Empty;
        }
        catch (Exception ex)
        {
            StatusMessage = ex.Message;
        }
    }
}

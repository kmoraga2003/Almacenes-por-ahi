using AlmacenesPorAhi.Core.Services;
using AlmacenesPorAhi.Core.ViewModels;

namespace AlmacenesPorAhi.App.Views;

public partial class InventoryPage : ContentPage
{
    public InventoryPage(AppDataService dataService)
    {
        InitializeComponent();
        BindingContext = new InventoryViewModel(dataService);
    }
}

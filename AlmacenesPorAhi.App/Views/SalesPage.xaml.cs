using AlmacenesPorAhi.Core.Services;
using AlmacenesPorAhi.Core.ViewModels;

namespace AlmacenesPorAhi.App.Views;

public partial class SalesPage : ContentPage
{
    public SalesPage(AppDataService dataService)
    {
        InitializeComponent();
        BindingContext = new SalesViewModel(dataService);
    }
}

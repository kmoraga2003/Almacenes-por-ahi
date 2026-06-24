using AlmacenesPorAhi.Core.Services;
using AlmacenesPorAhi.Core.ViewModels;

namespace AlmacenesPorAhi.App.Views;

public partial class ReturnsPage : ContentPage
{
    public ReturnsPage(AppDataService dataService)
    {
        InitializeComponent();
        BindingContext = new ReturnsViewModel(dataService);
    }
}

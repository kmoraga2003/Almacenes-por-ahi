using AlmacenesPorAhi.Core.Services;

namespace AlmacenesPorAhi.App.Views;

public partial class MainMenuPage : ContentPage
{
    private readonly AppDataService _dataService;

    public MainMenuPage(AppDataService dataService)
    {
        InitializeComponent();
        _dataService = dataService;
    }

    private async void OnInventoryClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InventoryPage(_dataService));
    }

    private async void OnSalesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SalesPage(_dataService));
    }

    private async void OnReturnsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReturnsPage(_dataService));
    }
}

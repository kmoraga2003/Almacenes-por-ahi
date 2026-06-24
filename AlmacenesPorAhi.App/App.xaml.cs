using AlmacenesPorAhi.App.Views;
using AlmacenesPorAhi.Core.Services;

namespace AlmacenesPorAhi.App;

public partial class App : Application
{
    public App(AppDataService dataService)
    {
        InitializeComponent();
        MainPage = new NavigationPage(new LoginPage(dataService));
    }
}

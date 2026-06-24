using AlmacenesPorAhi.Core.Services;

namespace AlmacenesPorAhi.App.Views;

public partial class LoginPage : ContentPage
{
    private const string ValidUser = "empleado";
    private const string ValidPassword = "1234";
    private readonly AppDataService _dataService;

    public LoginPage(AppDataService dataService)
    {
        InitializeComponent();
        _dataService = dataService;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (UsernameEntry.Text == ValidUser && PasswordEntry.Text == ValidPassword)
        {
            StatusLabel.Text = string.Empty;
            await Navigation.PushAsync(new MainMenuPage(_dataService));
            return;
        }

        StatusLabel.Text = "Usuario o contraseña incorrectos.";
    }
}

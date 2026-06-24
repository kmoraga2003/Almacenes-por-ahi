using AlmacenesPorAhi.Core.Helpers;

namespace AlmacenesPorAhi.Core.Models;

public class Product : ObservableObject
{
    private int _id;
    private string _name = string.Empty;
    private decimal _price;
    private int _stock;

    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public decimal Price
    {
        get => _price;
        set => SetProperty(ref _price, value);
    }

    public int Stock
    {
        get => _stock;
        set => SetProperty(ref _stock, value);
    }
}

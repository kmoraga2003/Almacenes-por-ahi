using System.Globalization;

namespace AlmacenesPorAhi;

public class BoolToColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool hasStock && hasStock)
            return Color.FromArgb("#10B981"); // Verde si hay stock
        return Color.FromArgb("#EF4444"); // Rojo si sin stock
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

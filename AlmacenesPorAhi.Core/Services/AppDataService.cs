using System.Collections.ObjectModel;
using AlmacenesPorAhi.Core.Models;

namespace AlmacenesPorAhi.Core.Services;

public class AppDataService
{
    private int _nextProductId = 1;

    public AppDataService()
    {
        Products = new ObservableCollection<Product>();
        ReturnHistory = new ObservableCollection<ReturnRecord>();
        SeedProducts();
    }

    public ObservableCollection<Product> Products { get; }

    public ObservableCollection<ReturnRecord> ReturnHistory { get; }

    public Product AddProduct(string name, decimal price, int stock)
    {
        ValidateProduct(name, price, stock);

        var product = new Product
        {
            Id = _nextProductId++,
            Name = name.Trim(),
            Price = price,
            Stock = stock
        };

        Products.Add(product);
        return product;
    }

    public void UpdateProduct(Product product, string name, decimal price, int stock)
    {
        ArgumentNullException.ThrowIfNull(product);
        ValidateProduct(name, price, stock);

        product.Name = name.Trim();
        product.Price = price;
        product.Stock = stock;
    }

    public void DeleteProduct(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);
        Products.Remove(product);
    }

    public void RegisterSale(Product product, int quantity)
    {
        ArgumentNullException.ThrowIfNull(product);

        if (quantity <= 0)
        {
            throw new ArgumentException("La cantidad debe ser mayor a cero.");
        }

        if (quantity > product.Stock)
        {
            throw new InvalidOperationException("No hay suficiente stock disponible.");
        }

        product.Stock -= quantity;
    }

    public ReturnRecord RegisterReturn(Product product, int quantity, string reason)
    {
        ArgumentNullException.ThrowIfNull(product);

        if (quantity <= 0)
        {
            throw new ArgumentException("La cantidad devuelta debe ser mayor a cero.");
        }

        if (string.IsNullOrWhiteSpace(reason))
        {
            throw new ArgumentException("Debe ingresar un motivo para la devolución.");
        }

        product.Stock += quantity;

        var record = new ReturnRecord
        {
            ProductName = product.Name,
            Quantity = quantity,
            Reason = reason.Trim(),
            Date = DateTime.Now
        };

        ReturnHistory.Insert(0, record);
        return record;
    }

    private void SeedProducts()
    {
        AddProduct("Arroz", 1.50m, 20);
        AddProduct("Azúcar", 1.10m, 15);
        AddProduct("Aceite", 3.75m, 10);
    }

    private static void ValidateProduct(string name, decimal price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("El nombre del producto es obligatorio.");
        }

        if (price < 0)
        {
            throw new ArgumentException("El precio no puede ser negativo.");
        }

        if (stock < 0)
        {
            throw new ArgumentException("El stock no puede ser negativo.");
        }
    }
}

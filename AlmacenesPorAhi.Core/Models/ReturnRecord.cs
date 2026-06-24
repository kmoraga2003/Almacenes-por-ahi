namespace AlmacenesPorAhi.Core.Models;

public class ReturnRecord
{
    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public string Reason { get; set; } = string.Empty;

    public DateTime Date { get; set; }
}

namespace Biblioteca;

public sealed class Multa
{
    private decimal _deudaRestante;

    public Multa(string libroPrestado, decimal montoTotal, DateOnly fecha)
    {
        LibroPrestado = libroPrestado;
        MontoTotal = montoTotal;
        _deudaRestante = montoTotal;
        FechaCreacion = fecha;
    }

    public string LibroPrestado { get; }
    public decimal MontoTotal { get; }
    public decimal DeudaRestante => _deudaRestante;
    public DateOnly FechaCreacion { get; }

    public bool EstaPagada => _deudaRestante <= 0;

    public void Pagar(decimal cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentException("El pago debe ser mayor a cero.", nameof(cantidad));
        if (cantidad > _deudaRestante)
            cantidad = _deudaRestante;
        _deudaRestante -= cantidad;
    }
}

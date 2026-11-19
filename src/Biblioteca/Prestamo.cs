namespace Biblioteca;

public sealed class Prestamo
{
    public Prestamo(string titulo, DateOnly fechaInicio)
    {
        Titulo = titulo;
        FechaInicio = fechaInicio;
    }

    public string Titulo { get; }

    public DateOnly FechaInicio { get; }

    public DateOnly FechaExpiracion()
        => FechaInicio.AddDays(7);
}

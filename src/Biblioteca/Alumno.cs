namespace Biblioteca;

public sealed class Alumno
{
    private readonly List<Prestamo> _prestamos = new();
    private readonly List<Multa> _multas = new();

    public Alumno(string nombre)
    {
        Nombre = nombre;
    }

    public string Nombre { get; }

    public IReadOnlyList<Prestamo> Prestamos => _prestamos;
    public IReadOnlyList<Multa> Multas => _multas;

    // Atajo para pruebas: un alumno que ya tiene cierta cantidad de libros prestados.
    public static Alumno ConPrestamos(int cantidad, DateOnly? desde = null)
    {
        var alumno = new Alumno("Ana");
        var fecha = desde ?? DateOnly.FromDateTime(DateTime.Today);
        for (var i = 1; i <= cantidad; i++)
        {
            alumno._prestamos.Add(new Prestamo($"Libro {i}", fecha));
        }
        return alumno;
    }

    public Resultado PedirLibro(string titulo) =>
        PedirLibro(titulo, DateOnly.FromDateTime(DateTime.Today));

    public Resultado PedirLibro(string titulo, DateOnly hoy)
    {
        // RN-001: máximo 3 libros prestados al mismo tiempo.
        if (_prestamos.Count >= 3)
        {
            return Resultado.Rechazo("Ya tienes 3 libros prestados");
        }

        // RN-602: debe una multa → no puede pedir libro.
        if (_multas.Any(m => !m.EstaPagada))
        {
            return Resultado.Rechazo("Tienes una multa pendiente");
        }

        _prestamos.Add(new Prestamo(titulo, hoy));
        return Resultado.Ok();
    }

    // RN-601: un alumno pierde un libro, se le multa con 300 pesos.
    public Multa RegistrarPérdida(string libroPrestado, DateOnly hoy)
    {
        var multa = new Multa(libroPrestado, 300, hoy);
        _multas.Add(multa);
        return multa;
    }

    // Pagar multa de contado o semanalmente.
    public void PagarMulta(decimal cantidad)
    {
        var multaPendiente = _multas.FirstOrDefault(m => !m.EstaPagada);
        if (multaPendiente != null)
        {
            multaPendiente.Pagar(cantidad);
        }
    }
}

namespace Biblioteca;

public sealed class Alumno
{
    private readonly List<Prestamo> _prestamos = new();

    public Alumno(string nombre)
    {
        Nombre = nombre;
    }

    public string Nombre { get; }

    public IReadOnlyList<Prestamo> Prestamos => _prestamos;

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

    // Atajos para pruebas: préstamo con título específico.
    internal static Alumno ConPrestamo(string titulo, DateOnly fecha)
    {
        var alumno = new Alumno("Test");
        alumno._prestamos.Add(new Prestamo(titulo, fecha));
        return alumno;
    }

    // Apartar un libro que está prestado (lo llama otro alumno, no el que tiene el préstamo).
    internal static Resultado ApartarLibro(IReadOnlyList<Prestamo> prestamos, string titulo)
    {
        var prestamo = prestamos.FirstOrDefault(p => p.Titulo == titulo);
        if (prestamo == null)
            return Resultado.Rechazo("No hay préstamo activo para este libro");

        prestamo.Apartado = true;
        return Resultado.Ok($"Reserva creada para {titulo}");
    }

    public Resultado PedirLibro(string titulo) =>
        PedirLibro(titulo, DateOnly.FromDateTime(DateTime.Today));

    public Resultado PedirLibro(string titulo, DateOnly hoy)
    {
        // RN-301: diccionarios y enciclopedias no se prestan
        var tituloLower = titulo.ToLowerInvariant();
        if (tituloLower.Contains("diccionario") || tituloLower.Contains("enciclopedia"))
        {
            return Resultado.Rechazo("Los diccionarios y enciclopedias son de consulta interna");
        }

        // RN-302: no repetir el mismo libro
        if (_prestamos.Any(p => string.Equals(p.Titulo, titulo, StringComparison.OrdinalIgnoreCase)))
        {
            return Resultado.Rechazo("Ya tienes este libro prestado");
        }

        // RN-001: máximo 3 libros prestados al mismo tiempo.
        if (_prestamos.Count >= 3)
        {
            return Resultado.Rechazo("Ya tienes 3 libros prestados");
        }

        _prestamos.Add(new Prestamo(titulo, hoy));
        return Resultado.Ok();
    }

    public Resultado RenovarLibro(string titulo, DateOnly hoy)
    {
        var prestamo = _prestamos.FirstOrDefault(p => p.Titulo == titulo);
        if (prestamo == null)
            return Resultado.Rechazo("No hay préstamo activo para este libro");

        if (prestamo.Apartado)
            return Resultado.Rechazo("El libro está apartado");

        prestamo.FechaInicio = prestamo.FechaInicio.AddDays(7);
        return Resultado.Ok("Préstamo renovado por 7 días");
    }
}

namespace Biblioteca.Tests;

public class PrestamosTests
{
    // AC-007 verifica RN-001: un alumno no puede tener más de 3 libros prestados.
    [Fact]
    [Trait("RN", "RN-001")]
    public void RN001_rechaza_cuarto_prestamo()
    {
        var ana = Alumno.ConPrestamos(3);

        var r = ana.PedirLibro("El Principito");

        Assert.False(r.Exito);
        Assert.Equal("Ya tienes 3 libros prestados", r.Mensaje);
        Assert.Equal(3, ana.Prestamos.Count);
    }

    [Fact]
    [Trait("RN", "RN-001")]
    public void RN001_permite_el_tercer_prestamo()
    {
        var ana = Alumno.ConPrestamos(2);

        var r = ana.PedirLibro("El Principito");

        Assert.True(r.Exito);
        Assert.Equal(3, ana.Prestamos.Count);
    }

    [Fact]
    [Trait("RN", "RN-301")]
    public void RN301_rechaza_prestamo_diccionario()
    {
        var ana = Alumno.ConPrestamos(1);

        var r = ana.PedirLibro("Diccionario de la Lengua Española");

        Assert.False(r.Exito);
        Assert.Equal("Los diccionarios y enciclopedias son de consulta interna", r.Mensaje);
        Assert.Equal(1, ana.Prestamos.Count);
    }

    [Fact]
    [Trait("RN", "RN-301")]
    public void RN301_rechaza_prestamo_enciclopedia()
    {
        var ana = Alumno.ConPrestamos(1);

        var r = ana.PedirLibro("Enciclopedia Universal");

        Assert.False(r.Exito);
        Assert.Equal("Los diccionarios y enciclopedias son de consulta interna", r.Mensaje);
        Assert.Equal(1, ana.Prestamos.Count);
    }

    [Fact]
    [Trait("RN", "RN-302")]
    public void RN302_rechaza_prestamo_duplicado()
    {
        var ana = Alumno.ConPrestamos(1);

        var r = ana.PedirLibro("Libro 1");

        Assert.False(r.Exito);
        Assert.Equal("Ya tienes este libro prestado", r.Mensaje);
        Assert.Equal(1, ana.Prestamos.Count);
    }

    // AC-501 verifica RN-501: alumno de nuevo ingreso solo puede tener 1 libro.
    [Fact]
    [Trait("RN", "RN-501")]
    public void RN501_rechaza_solicitud_si_tiene_libro_nuevo_ingreso()
    {
        var luis = Alumno.ConPrestamos(1, esNuevoIngreso: true);

        var r = luis.PedirLibro("Rayuela");

        Assert.False(r.Exito);
        Assert.Equal("Los alumnos de nuevo ingreso solo pueden tener 1 libro prestado", r.Mensaje);
        Assert.Equal(1, luis.Prestamos.Count);
    }

    [Fact]
    [Trait("RN", "RN-501")]
    public void RN501_permite_primer_prestamo_nuevo_ingreso()
    {
        var luis = Alumno.ConPrestamos(0, esNuevoIngreso: true);

        var r = luis.PedirLibro("Rayuela");

        Assert.True(r.Exito);
        Assert.Equal(1, luis.Prestamos.Count);
    }

    [Fact]
    [Trait("RN", "RN-501")]
    public void RN501_no_aplica_a_alumno_regular()
    {
        var ana = Alumno.ConPrestamos(2);

        var r = ana.PedirLibro("Rayuela");

        Assert.True(r.Exito);
        Assert.Equal(3, ana.Prestamos.Count);
    }

    [Fact]
    [Trait("RN", "RN-501")]
    public void RN501_no_aplica_despues_del_primer_mes()
    {
        var luis = Alumno.ConPrestamos(1, desde: DateOnly.FromDateTime(DateTime.Today.AddDays(-60)), esNuevoIngreso: true);

        var r = luis.PedirLibro("Rayuela");

        Assert.True(r.Exito);
        Assert.Equal(2, luis.Prestamos.Count);
    }
}

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
    [Trait("RN", "RN-101")]
    public void RN101_duracion_del_prestamo_es_7_dias()
    {
        var fecha = new DateOnly(2026, 11, 19);
        var prestamo = new Prestamo("El Principito", fecha);

        var expiracion = prestamo.FechaExpiracion();

        Assert.Equal(new DateOnly(2026, 11, 26), expiracion);
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
}

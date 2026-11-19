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
}

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

    // RN-401: apartar un libro prestado.
    [Fact]
    [Trait("RN", "RN-401")]
    public void RN401_puede_apartar_libro_prestado()
    {
        var ana = Alumno.ConPrestamo("Rayuela", new DateOnly(2026, 11, 19));

        var r = Alumno.ApartarLibro(ana.Prestamos, "Rayuela");

        Assert.True(r.Exito);
        var prestamo = Assert.Single(ana.Prestamos);
        Assert.True(prestamo.Apartado);
    }

    [Fact]
    [Trait("RN", "RN-401")]
    public void RN401_no_se_puede_apartar_libro_no_prestado()
    {
        var ana = Alumno.ConPrestamos(1);

        var r = Alumno.ApartarLibro(ana.Prestamos, "Rayuela");

        Assert.False(r.Exito);
        Assert.Equal("No hay préstamo activo para este libro", r.Mensaje);
    }

    // RN-402: libro apartado no se renueva.
    [Fact]
    [Trait("RN", "RN-402")]
    public void RN402_no_se_puede_renovar_libro_apartado()
    {
        var ana = Alumno.ConPrestamo("Rayuela", new DateOnly(2026, 11, 19));

        var apartar = Alumno.ApartarLibro(ana.Prestamos, "Rayuela");
        Assert.True(apartar.Exito);

        var r = ana.RenovarLibro("Rayuela", new DateOnly(2026, 11, 25));

        Assert.False(r.Exito);
        Assert.Equal("El libro está apartado", r.Mensaje);
    }

    [Fact]
    [Trait("RN", "RN-402")]
    public void RN402_se_puede_renovar_libro_no_apartado()
    {
        var ana = Alumno.ConPrestamo("Rayuela", new DateOnly(2026, 11, 19));

        var r = ana.RenovarLibro("Rayuela", new DateOnly(2026, 11, 25));

        Assert.True(r.Exito);
    }
}

namespace Biblioteca.Tests;

public class PrestamosTests
{
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
    [Trait("RN", "RN-601")]
    public void RN601_creacionMultaPerdida()
    {
        var ana = new Alumno("Ana");
        var fecha = DateOnly.Parse("2026-01-15");

        var multa = ana.RegistrarPérdida("Cien Años de Soledad", fecha);

        Assert.Equal(300, multa.MontoTotal);
        Assert.Equal(300, multa.DeudaRestante);
        Assert.False(multa.EstaPagada);
        Assert.Single(ana.Multas);
    }

    [Fact]
    [Trait("RN", "RN-601")]
    public void RN601_pagoContado_multaPagada()
    {
        var ana = new Alumno("Ana");
        var fecha = DateOnly.Parse("2026-01-15");

        var multa = ana.RegistrarPérdida("Cien Años de Soledad", fecha);

        ana.PagarMulta(300);

        Assert.Equal(0, multa.DeudaRestante);
        Assert.True(multa.EstaPagada);
    }

    [Fact]
    [Trait("RN", "RN-601")]
    public void RN601_pagoParcial_deudaRestante()
    {
        var ana = new Alumno("Ana");
        var fecha = DateOnly.Parse("2026-01-15");

        var multa = ana.RegistrarPérdida("Cien Años de Soledad", fecha);

        ana.PagarMulta(100);

        Assert.Equal(200, multa.DeudaRestante);
        Assert.False(multa.EstaPagada);
    }

    [Fact]
    [Trait("RN", "RN-602")]
    public void RN602_multaPendiente_rechazaPrestamo()
    {
        var ana = new Alumno("Ana");
        var fecha = DateOnly.Parse("2026-01-15");

        ana.RegistrarPérdida("Cien Años de Soledad", fecha);

        var r = ana.PedirLibro("1984");

        Assert.False(r.Exito);
        Assert.Equal("Tienes una multa pendiente", r.Mensaje);
        Assert.Empty(ana.Prestamos);
    }

    [Fact]
    [Trait("RN", "RN-602")]
    public void RN602_multaPagada_permitePrestamo()
    {
        var ana = new Alumno("Ana");
        var fecha = DateOnly.Parse("2026-01-15");

        ana.RegistrarPérdida("Cien Años de Soledad", fecha);
        ana.PagarMulta(300);

        var r = ana.PedirLibro("1984");

        Assert.True(r.Exito);
        Assert.Single(ana.Prestamos);
    }

    [Fact]
    [Trait("RN", "RN-602")]
    public void RN602_multaParcial_rechazaPrestamo()
    {
        var ana = new Alumno("Ana");
        var fecha = DateOnly.Parse("2026-01-15");

        ana.RegistrarPérdida("Cien Años de Soledad", fecha);
        ana.PagarMulta(100);

        var r = ana.PedirLibro("1984");

        Assert.False(r.Exito);
        Assert.Equal("Tienes una multa pendiente", r.Mensaje);
    }

    [Fact]
    [Trait("RN", "RN-602")]
    public void RN602_sinMultas_permitePrestamo()
    {
        var ana = new Alumno("Ana");

        var r = ana.PedirLibro("El Principito");

        Assert.True(r.Exito);
    }

    [Fact]
    [Trait("RN", "RN-001")]
    public void RN001_y_RN602_combinados_rechazaPorMulta()
    {
        var ana = Alumno.ConPrestamos(2);
        var fecha = DateOnly.Parse("2026-01-15");

        ana.RegistrarPérdida("Cien Años de Soledad", fecha);

        var r = ana.PedirLibro("1984");

        Assert.False(r.Exito);
        Assert.Equal("Tienes una multa pendiente", r.Mensaje);
    }
}

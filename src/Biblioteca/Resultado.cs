namespace Biblioteca;

public sealed record Resultado(bool Exito, string Mensaje)
{
    public static Resultado Ok(string mensaje = "") => new(true, mensaje);

    public static Resultado Rechazo(string mensaje) => new(false, mensaje);
}

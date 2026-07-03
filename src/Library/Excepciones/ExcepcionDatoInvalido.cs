namespace ProyectoPII.Excepciones;

/// <summary>
/// Excepción lanzada cuando se recibe un dato inválido para una operación del dominio.
/// </summary>
public class ExcepcionDatoInvalido : ExcepcionDominio
{
    /// <summary>
    /// Inicializa una nueva excepción indicando el dato inválido.
    /// </summary>
    /// <param name="mensaje">Mensaje que describe el dato inválido.</param>
    public ExcepcionDatoInvalido(string mensaje)
        : base(mensaje)
    {
    }
}
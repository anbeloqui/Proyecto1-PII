namespace ProyectoPII.Excepciones;

/// <summary>
/// Excepción lanzada cuando se intenta operar con un usuario inexistente.
/// </summary>
public class ExcepcionUsuarioNoEncontrado : ExcepcionDominio
{
    /// <summary>
    /// Inicializa una nueva excepción indicando el usuario no encontrado.
    /// </summary>
    /// <param name="nombreUsuario">Nombre del usuario que no fue encontrado.</param>
    public ExcepcionUsuarioNoEncontrado(string nombreUsuario)
        : base($"No se encontró el usuario '{nombreUsuario}'.")
    {
    }
}
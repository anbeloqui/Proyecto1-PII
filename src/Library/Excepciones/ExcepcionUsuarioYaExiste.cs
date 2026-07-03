namespace ProyectoPII.Excepciones;

/// <summary>
/// Excepción lanzada cuando se intenta registrar un usuario que ya existe.
/// </summary>
public class ExcepcionUsuarioYaExiste : ExcepcionDominio
{
    /// <summary>
    /// Inicializa una nueva excepción indicando el usuario duplicado.
    /// </summary>
    /// <param name="nombreUsuario">Nombre del usuario que ya existe.</param>
    public ExcepcionUsuarioYaExiste(string nombreUsuario)
        : base($"El usuario '{nombreUsuario}' ya está registrado.")
    {
    }
}
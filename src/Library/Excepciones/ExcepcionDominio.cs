namespace ProyectoPII.Excepciones;

/// <summary>
/// Excepción base para los errores propios del dominio.
/// 
/// Se utiliza para representar reglas de negocio incumplidas,
/// diferenciándolas de errores técnicos inesperados del sistema.
/// </summary>
public abstract class ExcepcionDominio : Exception
{
    /// <summary>
    /// Inicializa una nueva excepción de dominio con un mensaje descriptivo.
    /// </summary>
    /// <param name="mensaje">Mensaje que describe el error de dominio.</param>
    protected ExcepcionDominio(string mensaje)
        : base(mensaje)
    {
    }
}
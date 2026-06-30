namespace ProyectoPII.Modelos;

// ---------------------------------------------------------
// CLASE USUARIO
// ---------------------------------------------------------
// Representa a una persona que usa el sistema.
//
// Cada usuario tiene preferencias, por ejemplo "rock" o "pop".
// También tiene un historial con los ID de las canciones
// que ya consumió.
//
// Ese historial permite evitar recomendar canciones repetidas.
// ---------------------------------------------------------

/// <summary>
/// Representa un usuario del sistema.
/// Almacena su información, preferencias e historial de interacciones.
/// </summary>
public class Usuario
{
    /// <summary>
    /// Identificador único del usuario.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre del usuario.
    /// </summary>
    public string Nombre { get; set; } = "";

    /// <summary>
    /// Lista de preferencias registradas por el usuario.
    /// </summary>
    public List<string> Preferencias { get; set; } = new();

    /// <summary>
    /// Identificadores de los elementos consumidos por el usuario.
    /// </summary>
    public List<int> HistorialIds { get; set; } = new();

    /// <summary>
    /// Historial completo de interacciones realizadas por el usuario.
    /// </summary>
    public Historial Historial { get; set; } = new();
}
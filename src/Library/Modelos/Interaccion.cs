namespace ProyectoPII.Modelos;

// ---------------------------------------------------------
// CLASE INTERACCION
// ---------------------------------------------------------
// Representa una acción realizada por un usuario.
//
// Por ejemplo:
// - Escuchar una canción.
// - Dar like.
// - Dar dislike.
//
// Esta clase sirve como base para registrar actividad
// del usuario dentro del sistema.
// ---------------------------------------------------------

/// <summary>
/// Representa una interacción realizada por un usuario sobre un elemento recomendable.
/// </summary>
public class Interaccion
{
    /// <summary>
    /// Identificador del usuario que realizó la interacción.
    /// </summary>
    public int UsuarioId { get; set; }

    /// <summary>
    /// Identificador del elemento sobre el que se realizó la interacción.
    /// </summary>
    public int ItemId { get; set; }

    /// <summary>
    /// Tipo de interacción realizada.
    /// </summary>
    public TipoInteraccion Tipo { get; set; }

    /// <summary>
    /// Fecha y hora en que se registró la interacción.
    /// </summary>
    public DateTime Fecha { get; set; } = DateTime.Now;
}
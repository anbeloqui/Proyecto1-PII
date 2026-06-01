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

public class Interaccion
{
    public int UsuarioId { get; set; }
    public int ItemId { get; set; }
    public string Tipo { get; set; } = "";
}
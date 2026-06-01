using ProyectoPII.Interfaces;

namespace ProyectoPII.Modelos;

// ---------------------------------------------------------
// CLASE CANCION
// ---------------------------------------------------------
// Representa una canción dentro del sistema.
//
// Implementa IRecomendable porque una canción puede ser
// recomendada por el sistema.
//
// Sus atributos, como "rock", "pop" o "clasica",
// se usan para compararlos con las preferencias del usuario.
// ---------------------------------------------------------

public class Cancion : IRecomendable
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Artista { get; set; } = "";
    public List<string> Atributos { get; set; } = new();
}
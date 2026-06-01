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

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public List<string> Preferencias { get; set; } = new();
    public List<int> HistorialIds { get; set; } = new();
}
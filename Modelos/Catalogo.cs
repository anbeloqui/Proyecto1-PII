namespace ProyectoPII.Modelos;

// ---------------------------------------------------------
// CLASE CATALOGO
// ---------------------------------------------------------
// Representa el conjunto de canciones disponibles
// dentro del sistema.
//
// La fachada usa esta clase para agregar canciones
// y obtener la lista completa cuando se quieren generar
// recomendaciones.
// ---------------------------------------------------------


public class Catalogo
{
    public List<Cancion> Canciones { get; set; } = new();

// Agrega una nueva canción al catálogo.
    public void AgregarCancion(Cancion cancion)
    {
        Canciones.Add(cancion);
    }

// Devuelve todas las canciones disponibles.
    public List<Cancion> ObtenerCanciones()
    {
        return Canciones;
    }
}
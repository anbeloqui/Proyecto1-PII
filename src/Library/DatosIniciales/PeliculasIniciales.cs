using ProyectoPII.Modelos;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;

namespace ProyectoPII.DatosIniciales;

/// <summary>
/// Proporciona un conjunto inicial de películas para el catálogo del sistema.
/// </summary>
public static class PeliculasIniciales
{
    /// <summary>
    /// Agrega las películas iniciales a la fachada recibida.
    /// </summary>
    /// <param name="fachada">Fachada del sistema donde se cargarán las películas.</param>
    public static void Cargar(FachadaProyecto fachada)
    {
        ArgumentNullException.ThrowIfNull(fachada);

        foreach (Pelicula pelicula in Obtener())
        {
            fachada.AgregarItem(pelicula);
        }
    }
    
    /// <summary>
    /// Obtiene la colección inicial de películas.
    /// </summary>
    /// <returns>Lista de películas predefinidas.</returns>
    public static List<Pelicula> Obtener()
    {
        return new List<Pelicula>
        {
            new Pelicula
            {
                Id = 1001,
                Nombre = "The Matrix",
                Director = "Lana y Lilly Wachowski",
                Atributos = new List<string>
                {
                    "accion",
                    "ciencia ficcion"
                }
            },

            new Pelicula
            {
                Id = 1002,
                Nombre = "Interstellar",
                Director = "Christopher Nolan",
                Atributos = new List<string>
                {
                    "ciencia ficcion",
                    "drama"
                }
            },

            new Pelicula
            {
                Id = 1003,
                Nombre = "El Señor de los Anillos",
                Director = "Peter Jackson",
                Atributos = new List<string>
                {
                    "fantasia",
                    "aventura"
                }
            },

            new Pelicula
            {
                Id = 1004,
                Nombre = "El Padrino",
                Director = "Francis Ford Coppola",
                Atributos = new List<string>
                {
                    "drama",
                    "crimen"
                }
            },

            new Pelicula
            {
                Id = 1005,
                Nombre = "Toy Story",
                Director = "John Lasseter",
                Atributos = new List<string>
                {
                    "animacion",
                    "familia"
                }
            }
        };
    }
}
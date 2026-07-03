using ProyectoPII.Modelos;

namespace ProyectoPII.DatosIniciales;

/// <summary>
/// Proporciona un conjunto inicial de películas para el catálogo del sistema.
/// </summary>
public static class PeliculasIniciales
{
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
                Id = 1,
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
                Id = 2,
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
                Id = 3,
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
                Id = 4,
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
                Id = 5,
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
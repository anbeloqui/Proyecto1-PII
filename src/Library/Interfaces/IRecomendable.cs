namespace ProyectoPII.Interfaces;

// ---------------------------------------------------------
// INTERFAZ IRECOMENDABLE
// ---------------------------------------------------------
// Define qué información mínima debe tener cualquier elemento
// que pueda ser recomendado por el sistema.
//
// Gracias a esta interfaz, el recomendador no depende
// directamente de una clase específica como Cancion.
// En el futuro también podría recomendar películas,
// podcasts u otros contenidos.
// ---------------------------------------------------------

public interface IRecomendable
{
    int Id { get; }
    string Nombre { get; }
    List<string> Atributos { get; }
}
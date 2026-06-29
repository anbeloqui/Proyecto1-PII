// Importamos las clases e interfaces que vamos a utilizar.
using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Servicios;

// ---------------------------------------------------------
// PROGRAMA PRINCIPAL
// ---------------------------------------------------------
// Este archivo sirve para probar el funcionamiento del sistema.
//
// Creamos un usuario, un catálogo de canciones y luego usamos
// el recomendador para obtener canciones sugeridas.
//
// La salida esperada es que recomiende canciones que coincidan
// con las preferencias del usuario, pero que no estén en su historial.
// ---------------------------------------------------------

Usuario usuario = new Usuario
{
    Id = 1,
    Nombre = "Ana",

    // Preferencias musicales del usuario.
    Preferencias = new List<string> { "rock", "pop" },

    // La canción con ID 1 ya fue escuchada.
    HistorialIds = new List<int> { 1 }
};

// Creamos un pequeño catálogo de canciones para probar
// el funcionamiento del recomendador.
List<IRecomendable> canciones = new List<IRecomendable>
{
    new Cancion
    {
        Id = 1,
        Nombre = "Ya escuchada",
        Artista = "Banda A",
        Atributos = new() { "rock" }
    },

    new Cancion
    {
        Id = 2,
        Nombre = "Rock nuevo",
        Artista = "Banda B",
        Atributos = new() { "rock" }
    },

    new Cancion
    {
        Id = 3,
        Nombre = "Clásica",
        Artista = "Banda C",
        Atributos = new() { "clasica" }
    },

    new Cancion
    {
        Id = 4,
        Nombre = "Pop moderno",
        Artista = "Banda D",
        Atributos = new() { "pop" }
    }
};


// Instanciamos el recomendador.
Recomendador recomendador = new Recomendador();

// Generamos las recomendaciones para el usuario.
List<IRecomendable> recomendaciones =
    recomendador.Recomendar(usuario, canciones);

// Mostramos el resultado por consola.
Console.WriteLine($"Recomendaciones para {usuario.Nombre}:");

foreach (IRecomendable item in recomendaciones)
{
    Console.WriteLine($"- {item.Nombre}");
} 
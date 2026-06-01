using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Servicios;

namespace ProyectoPII.Tests;

// ---------------------------------------------------------
// TESTS DEL RECOMENDADOR
// ---------------------------------------------------------
// Estos tests verifican que el recomendador funcione
// correctamente según las preferencias del usuario
// y su historial de canciones escuchadas.
// ---------------------------------------------------------

public class RecomendadorTests
{
    [Fact]
    public void RecomiendaCancionesSegunPreferencias()
    {
        // Creamos un usuario que prefiere rock.
        Usuario usuario = new Usuario
        {
            Id = 1,
            Nombre = "Ana",
            Preferencias = new List<string> { "rock" },
            HistorialIds = new List<int>()
        };

        // Creamos canciones de prueba.
        List<IRecomendable> canciones = new()
        {
            new Cancion
            {
                Id = 1,
                Nombre = "Rock nuevo",
                Artista = "Banda A",
                Atributos = new() { "rock" }
            },

            new Cancion
            {
                Id = 2,
                Nombre = "Pop moderno",
                Artista = "Banda B",
                Atributos = new() { "pop" }
            }
        };

        Recomendador recomendador = new Recomendador();

        List<IRecomendable> resultado =
            recomendador.RecomendarPorPreferencias(usuario, canciones);

        Assert.Single(resultado);
        Assert.Equal("Rock nuevo", resultado[0].Nombre);
    }

    [Fact]
    public void NoRecomiendaCancionesYaEscuchadas()
    {
        // Usuario que ya escuchó la canción con ID 1.
        Usuario usuario = new Usuario
        {
            Id = 1,
            Nombre = "Ana",
            Preferencias = new List<string> { "rock" },
            HistorialIds = new List<int> { 1 }
        };

        List<IRecomendable> canciones = new()
        {
            new Cancion
            {
                Id = 1,
                Nombre = "Ya escuchada",
                Artista = "Banda A",
                Atributos = new() { "rock" }
            }
        };

        Recomendador recomendador = new Recomendador();

        List<IRecomendable> resultado =
            recomendador.RecomendarPorPreferencias(usuario, canciones);

        Assert.Empty(resultado);
    }

    [Fact]
    public void DevuelveListaVaciaSiNoHayCoincidencias()
    {
        // Usuario que prefiere rock.
        Usuario usuario = new Usuario
        {
            Id = 1,
            Nombre = "Ana",
            Preferencias = new List<string> { "rock" },
            HistorialIds = new List<int>()
        };

        // Solo existe una canción clásica.
        List<IRecomendable> canciones = new()
        {
            new Cancion
            {
                Id = 1,
                Nombre = "Clásica",
                Artista = "Banda C",
                Atributos = new() { "clasica" }
            }
        };

        Recomendador recomendador = new Recomendador();

        List<IRecomendable> resultado =
            recomendador.RecomendarPorPreferencias(usuario, canciones);

        Assert.Empty(resultado);
    }
}
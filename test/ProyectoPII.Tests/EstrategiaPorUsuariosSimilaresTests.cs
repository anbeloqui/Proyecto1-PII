using ProyectoPII.Estrategias;
using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Servicios;

namespace ProyectoPII.Tests;

public class EstrategiaPorUsuariosSimilaresTests
{
    [Fact]
    public void RecomiendaItemsConsumidosPorUsuariosSimilares()
    {
        Usuario usuario1 = new Usuario
        {
            Id = 1,
            Nombre = "Ana",
            Preferencias = new() { "rock" }
        };

        Usuario usuario2 = new Usuario
        {
            Id = 2,
            Nombre = "Luis",
            Preferencias = new() { "rock" }
        };

        usuario2.Historial.Agregar(new Interaccion
        {
            UsuarioId = 2,
            ItemId = 2,
            Tipo = TipoInteraccion.Consumido
        });

        List<Usuario> usuarios = new()
        {
            usuario1,
            usuario2
        };

        List<IRecomendable> items = new()
        {
            new Cancion
            {
                Id = 1,
                Nombre = "Pop",
                Artista = "Artista A",
                Atributos = new() { "pop" }
            },
            new Cancion
            {
                Id = 2,
                Nombre = "Rock recomendado",
                Artista = "Artista B",
                Atributos = new() { "rock" }
            }
        };

        Recomendador recomendador =
            new Recomendador(
                new EstrategiaPorUsuariosSimilares(usuarios));

        List<IRecomendable> resultado =
            recomendador.Recomendar(usuario1, items);

        Assert.Single(resultado);
        Assert.Equal(2, resultado[0].Id);
    }

    [Fact]
    public void NoRecomiendaSiNoHayUsuariosSimilares()
    {
        Usuario usuario1 = new Usuario
        {
            Id = 1,
            Nombre = "Ana",
            Preferencias = new() { "rock" }
        };

        Usuario usuario2 = new Usuario
        {
            Id = 2,
            Nombre = "Luis",
            Preferencias = new() { "pop" }
        };

        usuario2.Historial.Agregar(new Interaccion
        {
            UsuarioId = 2,
            ItemId = 2,
            Tipo = TipoInteraccion.Consumido
        });

        List<Usuario> usuarios = new()
        {
            usuario1,
            usuario2
        };

        List<IRecomendable> items = new()
        {
            new Cancion
            {
                Id = 2,
                Nombre = "Rock recomendado",
                Artista = "Artista B",
                Atributos = new() { "rock" }
            }
        };

        Recomendador recomendador =
            new Recomendador(
                new EstrategiaPorUsuariosSimilares(usuarios));

        List<IRecomendable> resultado =
            recomendador.Recomendar(usuario1, items);

        Assert.Empty(resultado);
    }
}
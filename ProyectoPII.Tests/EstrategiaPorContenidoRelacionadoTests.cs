using ProyectoPII.Estrategias;
using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Servicios;

namespace ProyectoPII.Tests;

public class EstrategiaPorContenidoRelacionadoTests
{
    [Fact]
    public void RecomiendaContenidoRelacionadoAlConsumido()
    {
        Usuario usuario = new Usuario
        {
            Id = 1,
            Nombre = "Ana"
        };

        usuario.Historial.Agregar(new Interaccion
        {
            UsuarioId = 1,
            ItemId = 1,
            Tipo = TipoInteraccion.Consumido
        });

        List<IRecomendable> catalogo = new()
        {
            new Cancion
            {
                Id = 1,
                Nombre = "Rock 1",
                Artista = "A",
                Atributos = new() { "rock", "80s" }
            },
            new Cancion
            {
                Id = 2,
                Nombre = "Rock 2",
                Artista = "B",
                Atributos = new() { "rock" }
            },
            new Cancion
            {
                Id = 3,
                Nombre = "Pop",
                Artista = "C",
                Atributos = new() { "pop" }
            }
        };

        Recomendador recomendador =
            new Recomendador(new EstrategiaPorContenidoRelacionado());

        List<IRecomendable> resultado =
            recomendador.Recomendar(usuario, catalogo);

        Assert.Single(resultado);
        Assert.Equal(2, resultado[0].Id);
    }

    [Fact]
    public void NoRecomiendaSiNoHayContenidoRelacionado()
    {
        Usuario usuario = new Usuario
        {
            Id = 1,
            Nombre = "Ana"
        };

        usuario.Historial.Agregar(new Interaccion
        {
            UsuarioId = 1,
            ItemId = 1,
            Tipo = TipoInteraccion.Consumido
        });

        List<IRecomendable> catalogo = new()
        {
            new Cancion
            {
                Id = 1,
                Nombre = "Rock",
                Artista = "A",
                Atributos = new() { "rock" }
            },
            new Cancion
            {
                Id = 2,
                Nombre = "Jazz",
                Artista = "B",
                Atributos = new() { "jazz" }
            }
        };

        Recomendador recomendador =
            new Recomendador(new EstrategiaPorContenidoRelacionado());

        List<IRecomendable> resultado =
            recomendador.Recomendar(usuario, catalogo);

        Assert.Empty(resultado);
    }
}
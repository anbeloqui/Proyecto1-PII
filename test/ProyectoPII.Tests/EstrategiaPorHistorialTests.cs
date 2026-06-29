using ProyectoPII.Estrategias;
using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Servicios;

namespace ProyectoPII.Tests;

public class EstrategiaPorHistorialTests
{
    [Fact]
    public void RecomiendaItemsSimilaresSegunHistorial()
    {
        Usuario usuario = new Usuario { Id = 1, Nombre = "Ana" };

        usuario.Historial.Agregar(new Interaccion
        {
            UsuarioId = 1,
            ItemId = 1,
            Tipo = TipoInteraccion.Like
        });

        List<IRecomendable> items = new()
        {
            new Cancion
            {
                Id = 1,
                Nombre = "Rock escuchado",
                Artista = "Banda A",
                Atributos = new() { "rock" }
            },
            new Cancion
            {
                Id = 2,
                Nombre = "Rock recomendado",
                Artista = "Banda B",
                Atributos = new() { "rock" }
            },
            new Cancion
            {
                Id = 3,
                Nombre = "Pop moderno",
                Artista = "Banda C",
                Atributos = new() { "pop" }
            }
        };

        Recomendador recomendador =
            new Recomendador(new EstrategiaPorHistorial());

        List<IRecomendable> resultado =
            recomendador.Recomendar(usuario, items);

        Assert.Single(resultado);
        Assert.Equal("Rock recomendado", resultado[0].Nombre);
    }

    [Fact]
    public void NoRecomiendaItemsYaConsumidosSegunHistorial()
    {
        Usuario usuario = new Usuario { Id = 1, Nombre = "Ana" };

        usuario.Historial.Agregar(new Interaccion
        {
            UsuarioId = 1,
            ItemId = 1,
            Tipo = TipoInteraccion.Like
        });

        usuario.Historial.Agregar(new Interaccion
        {
            UsuarioId = 1,
            ItemId = 2,
            Tipo = TipoInteraccion.Consumido
        });

        List<IRecomendable> items = new()
        {
            new Cancion
            {
                Id = 1,
                Nombre = "Rock base",
                Artista = "Banda A",
                Atributos = new() { "rock" }
            },
            new Cancion
            {
                Id = 2,
                Nombre = "Rock consumido",
                Artista = "Banda B",
                Atributos = new() { "rock" }
            }
        };

        Recomendador recomendador =
            new Recomendador(new EstrategiaPorHistorial());

        List<IRecomendable> resultado =
            recomendador.Recomendar(usuario, items);

        Assert.Empty(resultado);
    }
}
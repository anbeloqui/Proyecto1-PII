using ProyectoPII.Estrategias;
using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Servicios;

namespace ProyectoPII.Tests;

public class EstrategiaPorPopularidadTests
{
    [Fact]
    public void RecomiendaElementosOrdenadosPorPopularidad()
    {
        Usuario usuarioActual = new Usuario { Id = 1, Nombre = "Ana" };

        Usuario usuario2 = new Usuario { Id = 2, Nombre = "Luis" };
        usuario2.Historial.Agregar(new Interaccion { UsuarioId = 2, ItemId = 2, Tipo = TipoInteraccion.Like });
        usuario2.Historial.Agregar(new Interaccion { UsuarioId = 2, ItemId = 2, Tipo = TipoInteraccion.Guardado });

        Usuario usuario3 = new Usuario { Id = 3, Nombre = "Marta" };
        usuario3.Historial.Agregar(new Interaccion { UsuarioId = 3, ItemId = 3, Tipo = TipoInteraccion.Like });

        List<Usuario> usuarios = new() { usuarioActual, usuario2, usuario3 };

        List<IRecomendable> catalogo = new()
        {
            new Cancion { Id = 2, Nombre = "Más popular", Artista = "A", Atributos = new() { "rock" } },
            new Cancion { Id = 3, Nombre = "Menos popular", Artista = "B", Atributos = new() { "pop" } }
        };

        Recomendador recomendador =
            new Recomendador(new EstrategiaPorPopularidad(usuarios));

        List<IRecomendable> resultado =
            recomendador.Recomendar(usuarioActual, catalogo);

        Assert.Equal(2, resultado.Count);
        Assert.Equal(2, resultado[0].Id);
        Assert.Equal(3, resultado[1].Id);
    }

    [Fact]
    public void NoRecomiendaElementosYaConsumidosPorElUsuario()
    {
        Usuario usuarioActual = new Usuario { Id = 1, Nombre = "Ana" };
        usuarioActual.Historial.Agregar(new Interaccion { UsuarioId = 1, ItemId = 2, Tipo = TipoInteraccion.Consumido });

        Usuario usuario2 = new Usuario { Id = 2, Nombre = "Luis" };
        usuario2.Historial.Agregar(new Interaccion { UsuarioId = 2, ItemId = 2, Tipo = TipoInteraccion.Like });

        List<Usuario> usuarios = new() { usuarioActual, usuario2 };

        List<IRecomendable> catalogo = new()
        {
            new Cancion { Id = 2, Nombre = "Popular consumida", Artista = "A", Atributos = new() { "rock" } }
        };

        Recomendador recomendador =
            new Recomendador(new EstrategiaPorPopularidad(usuarios));

        List<IRecomendable> resultado =
            recomendador.Recomendar(usuarioActual, catalogo);

        Assert.Empty(resultado);
    }
}
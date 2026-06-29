using ProyectoPII.Filtros;
using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;

namespace ProyectoPII.Tests;

public class FilterChainTests
{
    [Fact]
    public void AplicaFiltrosEnOrden()
    {
        Usuario usuario = new Usuario { Id = 1, Nombre = "Ana" };

        usuario.Historial.Agregar(new Interaccion
        {
            UsuarioId = 1,
            ItemId = 1,
            Tipo = TipoInteraccion.Consumido
        });

        List<IRecomendable> items = new()
        {
            new Cancion { Id = 1, Nombre = "Rock viejo", Artista = "A", Atributos = new() { "rock" } },
            new Cancion { Id = 2, Nombre = "Rock nuevo", Artista = "B", Atributos = new() { "rock" } },
            new Cancion { Id = 3, Nombre = "Pop", Artista = "C", Atributos = new() { "pop" } }
        };

        FilterChain filtros = new();
        filtros.AgregarFiltro(new FiltroNoRepetirConsumidos(usuario));
        filtros.AgregarFiltro(new FiltroPorAtributo("rock"));

        List<IRecomendable> resultado = filtros.Filtrar(items);

        Assert.Single(resultado);
        Assert.Equal(2, resultado[0].Id);
    }
}
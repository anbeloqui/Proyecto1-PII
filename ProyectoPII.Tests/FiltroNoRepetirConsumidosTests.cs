using ProyectoPII.Filtros;
using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;

namespace ProyectoPII.Tests;

public class FiltroNoRepetirConsumidosTests
{
    [Fact]
    public void NoDevuelveItemsYaConsumidos()
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
            new Cancion { Id = 1, Nombre = "Ya consumida", Artista = "A" },
            new Cancion { Id = 2, Nombre = "Nueva", Artista = "B" }
        };

        FiltroNoRepetirConsumidos filtro =
            new FiltroNoRepetirConsumidos(usuario);

        List<IRecomendable> resultado = filtro.Filtrar(items);

        Assert.Single(resultado);
        Assert.Equal(2, resultado[0].Id);
    }
}
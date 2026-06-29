using ProyectoPII.Filtros;
using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;

namespace ProyectoPII.Tests;

public class FiltroPorAtributoTests
{
    [Fact]
    public void FiltraElementosPorAtributo()
    {
        List<IRecomendable> items = new()
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
                Nombre = "Pop",
                Artista = "B",
                Atributos = new() { "pop" }
            }
        };

        FiltroPorAtributo filtro = new FiltroPorAtributo("rock");

        List<IRecomendable> resultado = filtro.Filtrar(items);

        Assert.Single(resultado);
        Assert.Equal(1, resultado[0].Id);
    }

    [Fact]
    public void DevuelveListaVaciaSiNoHayCoincidencias()
    {
        List<IRecomendable> items = new()
        {
            new Cancion
            {
                Id = 1,
                Nombre = "Jazz",
                Artista = "A",
                Atributos = new() { "jazz" }
            }
        };

        FiltroPorAtributo filtro = new FiltroPorAtributo("rock");

        List<IRecomendable> resultado = filtro.Filtrar(items);

        Assert.Empty(resultado);
    }
}
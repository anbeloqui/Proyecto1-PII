using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Ordenadores;

namespace ProyectoPII.Tests;

public class OrdenadorPorNombreTests
{
    [Fact]
    public void OrdenaElementosAlfabeticamente()
    {
        List<IRecomendable> items = new()
        {
            new Cancion
            {
                Id = 1,
                Nombre = "Zeta",
                Artista = "A"
            },
            new Cancion
            {
                Id = 2,
                Nombre = "Alfa",
                Artista = "B"
            },
            new Cancion
            {
                Id = 3,
                Nombre = "Beta",
                Artista = "C"
            }
        };

        OrdenadorPorNombre ordenador = new();

        List<IRecomendable> resultado = ordenador.Ordenar(items);

        Assert.Equal("Alfa", resultado[0].Nombre);
        Assert.Equal("Beta", resultado[1].Nombre);
        Assert.Equal("Zeta", resultado[2].Nombre);
    }

    [Fact]
    public void MantieneListaVacia()
    {
        OrdenadorPorNombre ordenador = new();

        List<IRecomendable> resultado =
            ordenador.Ordenar(new List<IRecomendable>());

        Assert.Empty(resultado);
    }
}
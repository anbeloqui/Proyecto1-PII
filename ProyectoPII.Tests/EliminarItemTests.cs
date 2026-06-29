using ProyectoPII.Fachada;
using ProyectoPII.Modelos;

namespace ProyectoPII.Tests;

public class EliminarItemTests
{
    [Fact]
    public void EliminarItemLoQuitaDelCatalogo()
    {
        Fachada.Fachada fachada = new();

        fachada.AgregarCancion(
            1,
            "Canción",
            "Artista",
            new List<string> { "rock" });

        fachada.EliminarItem(1);

        Assert.Empty(fachada.ObtenerItems());
    }

    [Fact]
    public void EliminarItemInexistenteNoGeneraError()
    {
        Fachada.Fachada fachada = new();

        fachada.EliminarItem(99);

        Assert.Empty(fachada.ObtenerItems());
    }
}
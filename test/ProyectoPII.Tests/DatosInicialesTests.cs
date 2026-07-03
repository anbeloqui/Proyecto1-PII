using ProyectoPII.DatosIniciales;
using ProyectoPII.Fachada;
using ProyectoPII.Modelos;

namespace ProyectoPII.Tests;

/// <summary>
/// Pruebas relacionadas con los datos iniciales del sistema.
/// </summary>
public class DatosInicialesTests
{
    /// <summary>
    /// Verifica que las películas iniciales se agreguen al catálogo.
    /// </summary>
    [Fact]
    public void CargarPeliculasIniciales_AgregaPeliculasAlCatalogo()
    {
        ProyectoPII.Fachada.Fachada fachada = new ProyectoPII.Fachada.Fachada();

        PeliculasIniciales.Cargar(fachada);

        Assert.Contains(
            fachada.ObtenerItems(),
            item => item is Pelicula && item.Nombre == "The Matrix");
    }
}
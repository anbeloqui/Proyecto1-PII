using ProyectoPII.DatosIniciales;
using ProyectoPII.Fachada;
using ProyectoPII.Modelos;

namespace ProyectoPII.Tests;

/// <summary>
/// Pruebas de recomendaciones con múltiples tipos de elementos.
/// </summary>
public class RecomendacionesTests
{
    /// <summary>
    /// Verifica que el sistema pueda recomendar canciones y películas.
    /// </summary>
    [Fact]
    public void Recomendar_DevuelveCancionesYPeliculas()
    {
        ProyectoPII.Fachada.Fachada fachada = new ProyectoPII.Fachada.Fachada(true);

        CancionesIniciales.Cargar(fachada);
        PeliculasIniciales.Cargar(fachada);

        fachada.RegistrarUsuario(1, "alejandro");
        fachada.AgregarPreferencia("alejandro", "ciencia ficcion");
        fachada.AgregarPreferencia("alejandro", "rock");

        var recomendaciones = fachada.Recomendar("alejandro");

        Assert.Contains(recomendaciones, item => item is Cancion);
        Assert.Contains(recomendaciones, item => item is Pelicula);
    }
}
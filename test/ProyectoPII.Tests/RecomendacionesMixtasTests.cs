using ProyectoPII.DatosIniciales;
using ProyectoPII.Fachada;
using ProyectoPII.Modelos;

namespace ProyectoPII.Tests;

public class RecomendacionesMixtasTests
{
    [Fact]
    public void Recomendar_ConPreferenciasMixtas_DevuelveCancionesYPeliculas()
    {
        ProyectoPII.Fachada.Fachada fachada = new ProyectoPII.Fachada.Fachada(true);

        CancionesIniciales.Cargar(fachada);
        PeliculasIniciales.Cargar(fachada);

        fachada.RegistrarUsuario(1, "alejandro");
        fachada.AgregarPreferencia("alejandro", "rock");
        fachada.AgregarPreferencia("alejandro", "ciencia ficcion");

        var recomendaciones = fachada.Recomendar("alejandro");

        Assert.Contains(recomendaciones, item => item is Cancion);
        Assert.Contains(recomendaciones, item => item is Pelicula);
    }
}
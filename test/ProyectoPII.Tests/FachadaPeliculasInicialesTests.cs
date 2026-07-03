using System.Collections.Generic;
using Xunit;

using ProyectoPII.Fachada;
using ProyectoPII.Interfaces;

namespace ProyectoPII.Tests;

/// <summary>
/// Pruebas relacionadas con la carga inicial de películas en la fachada.
/// </summary>
public class FachadaPeliculasInicialesTests
{
    /// <summary>
    /// Verifica que la fachada cargue las películas iniciales al crearse.
    /// </summary>
    [Fact]
    public void Fachada_AlCrearse_CargaPeliculasIniciales()
    {
        ProyectoPII.Fachada.Fachada fachada = new ProyectoPII.Fachada.Fachada(true);

        List<IRecomendable> items = fachada.ObtenerItems();

        Assert.Contains(items, item => item.Nombre == "The Matrix");
        Assert.Contains(items, item => item.Nombre == "Interstellar");
    }

    /// <summary>
    /// Verifica que un usuario con la preferencia "ciencia ficcion"
    /// reciba recomendaciones de películas de ese género.
    /// </summary>
    [Fact]
    public void Recomendar_ConPreferenciaCienciaFiccion_RecomiendaPeliculas()
    {
        ProyectoPII.Fachada.Fachada fachada = new ProyectoPII.Fachada.Fachada(true);

        fachada.RegistrarUsuario(1, "alejandro");
        fachada.AgregarPreferencia("alejandro", "ciencia ficcion");

        List<IRecomendable> recomendaciones = fachada.Recomendar("alejandro");

        Assert.Contains(recomendaciones, item => item.Nombre == "The Matrix");
        Assert.Contains(recomendaciones, item => item.Nombre == "Interstellar");
    }
}
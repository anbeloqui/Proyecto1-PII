using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Estrategias;

namespace ProyectoPII.Servicios;

/// <summary>
/// Motor principal de recomendación.
/// Utiliza una estrategia intercambiable para generar recomendaciones.
/// </summary>
public class Recomendador
{
    private IEstrategiaRecomendacion estrategia;

    /// <summary>
    /// Crea un recomendador usando la estrategia por preferencias.
    /// </summary>
    public Recomendador()
    {
        estrategia = new EstrategiaPorPreferencias();
    }

    /// <summary>
    /// Crea un recomendador con una estrategia específica.
    /// </summary>
    /// <param name="estrategia">Estrategia de recomendación a utilizar.</param>
    public Recomendador(IEstrategiaRecomendacion estrategia)
    {
        this.estrategia = estrategia;
    }

    /// <summary>
    /// Genera recomendaciones para un usuario según la estrategia configurada.
    /// </summary>
    /// <param name="usuario">Usuario para el que se generan recomendaciones.</param>
    /// <param name="items">Elementos disponibles para recomendar.</param>
    /// <returns>Lista de elementos recomendados.</returns>
    public List<IRecomendable> Recomendar(
        Usuario usuario,
        List<IRecomendable> catalogo)
    {
        return estrategia.Recomendar(usuario, catalogo);
    }
}
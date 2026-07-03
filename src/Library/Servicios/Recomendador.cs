using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Estrategias;

namespace ProyectoPII.Servicios;

/// <summary>
/// Coordina el proceso de recomendación.
/// 
/// Esta clase actúa como intermediaria entre la fachada y el motor de recomendaciones,
/// seleccionando la estrategia correspondiente y delegando la ejecución al
/// RecommendationEngine.
/// </summary>
public class Recomendador
{
    private IEstrategiaRecomendacion estrategia;

    /// <summary>
    /// Crea un recomendador usando la estrategia por preferencias.
    /// </summary>
    /// <remarks>
    /// Postcondición: el recomendador queda configurado con una estrategia
    /// por preferencias por defecto.
    /// </remarks>
    public Recomendador()
    {
        estrategia = new EstrategiaPorPreferencias();
    }

    /// <summary>
    /// Crea un recomendador con una estrategia específica.
    /// </summary>
    /// <param name="estrategia">Estrategia de recomendación a utilizar.</param>
    /// <remarks>
    /// Precondición: se debe proporcionar una estrategia válida.
    /// Postcondición: el recomendador queda configurado con la estrategia indicada.
    /// </remarks>
    public Recomendador(IEstrategiaRecomendacion estrategia)
    {
        this.estrategia = estrategia;
    }

    /// <summary>
    /// Genera recomendaciones para un usuario según la estrategia configurada.
    /// </summary>
    /// <param name="usuario">Usuario para el que se generan recomendaciones.</param>
    /// <param name="catalogo">Elementos disponibles para recomendar.</param>
    /// <returns>Lista de elementos recomendados.</returns>
    /// <remarks>
    /// Precondición: el usuario y el catálogo deben ser válidos.
    /// Postcondición: se devuelve una lista de recomendaciones generada
    /// por la estrategia configurada.
    /// </remarks>
    public List<IRecomendable> Recomendar(
        Usuario usuario,
        List<IRecomendable> catalogo)
    {
        return estrategia.Recomendar(usuario, catalogo);
    }

    /// <summary>
    /// Genera recomendaciones buscando al usuario por nombre y utilizando la estrategia indicada.
    /// </summary>
    /// <param name="nombreUsuario">Nombre del usuario.</param>
    /// <param name="tipoEstrategia">Tipo de estrategia a utilizar.</param>
    /// <param name="usuarios">Lista de usuarios del sistema.</param>
    /// <param name="catalogo">Catálogo de elementos recomendables.</param>
    /// <returns>Lista de elementos recomendados.</returns>
    /// <remarks>
    /// Precondición: el usuario debe existir en la lista de usuarios.
    /// Precondición: el tipo de estrategia debe corresponder a una estrategia disponible.
    /// Postcondición: se devuelve una lista de recomendaciones generada por el motor
    /// de recomendaciones, aplicando estrategia, filtros y ranking.
    /// </remarks>
    public List<IRecomendable> Recomendar(
        string nombreUsuario,
        string tipoEstrategia,
        List<Usuario> usuarios,
        Catalogo catalogo)
    {
        Usuario? usuario = usuarios.Find(u => u.Nombre == nombreUsuario);

        if (usuario == null)
        {
            return new List<IRecomendable>();
        }

        IEstrategiaRecomendacion estrategiaSeleccionada =
            StrategyFactory.Crear(tipoEstrategia, usuarios);

        RecommendationEngine engine =
            new RecommendationEngine(estrategiaSeleccionada);

        return engine.Recomendar(
            usuario,
            catalogo.ObtenerItems());
    }
}
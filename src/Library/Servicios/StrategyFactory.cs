using ProyectoPII.Estrategias;
using ProyectoPII.Modelos;
using ProyectoPII.Interfaces;

namespace ProyectoPII.Servicios;

/// <summary>
/// Crea estrategias de recomendación según el tipo solicitado.
/// </summary>
public static class StrategyFactory
{
    /// <summary>
    /// Devuelve una estrategia de recomendación.
    /// </summary>
    public static IEstrategiaRecomendacion Crear(
        string tipo,
        List<Usuario> usuarios)
    {
        return tipo.ToLower() switch
        {
            "preferencias" => new EstrategiaPorPreferencias(),
            "historial" => new EstrategiaPorHistorial(),
            "popularidad" => new EstrategiaPorPopularidad(usuarios),
            "similares" => new EstrategiaPorUsuariosSimilares(usuarios),
            "contenido" => new EstrategiaPorContenidoRelacionado(),
            _ => new EstrategiaPorPreferencias()
        };
    }
}
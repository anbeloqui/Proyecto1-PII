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
    /// Devuelve una estrategia de recomendación según el tipo indicado.
    /// </summary>
    /// <param name="tipo">Tipo de estrategia solicitada.</param>
    /// <param name="usuarios">Lista de usuarios del sistema.</param>
    /// <returns>Estrategia de recomendación correspondiente.</returns>
    /// <remarks>
    /// Precondición: la lista de usuarios debe estar inicializada.
    /// Postcondición: se devuelve una estrategia válida. Si el tipo no coincide
    /// con una estrategia conocida, se devuelve la estrategia por preferencias.
    /// </remarks>
    public static IEstrategiaRecomendacion Crear(
        string tipo,
        List<Usuario> usuarios)
    {
        string tipoNormalizado = (tipo ?? "preferencias")
            .Trim()
            .ToLowerInvariant();

        return tipoNormalizado switch
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
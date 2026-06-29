using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;

namespace ProyectoPII.Estrategias;

// ---------------------------------------------------------
// CLASE EstrategiaPorPopularidad
// ---------------------------------------------------------

/// <summary>
/// Recomienda los elementos más populares según las
/// interacciones positivas registradas por los usuarios.
/// </summary>
public class EstrategiaPorPopularidad : IEstrategiaRecomendacion
{
    private List<Usuario> usuarios;

    public EstrategiaPorPopularidad(List<Usuario> usuarios)
    {
        this.usuarios = usuarios;
    }

    public List<IRecomendable> Recomendar(
        Usuario usuario,
        List<IRecomendable> catalogo)
    {
        List<int> consumidosUsuario =
            usuario.Historial.ObtenerItemsConsumidos();

        var popularidad = usuarios
            .SelectMany(u => u.Historial.ObtenerTodas())
            .Where(i =>
                i.Tipo == TipoInteraccion.Like ||
                i.Tipo == TipoInteraccion.Guardado ||
                i.Tipo == TipoInteraccion.Consumido)
            .GroupBy(i => i.ItemId)
            .ToDictionary(g => g.Key, g => g.Count());

        return catalogo
            .Where(item => !consumidosUsuario.Contains(item.Id))
            .Where(item => popularidad.ContainsKey(item.Id))
            .OrderByDescending(item => popularidad[item.Id])
            .ToList();
    }
}
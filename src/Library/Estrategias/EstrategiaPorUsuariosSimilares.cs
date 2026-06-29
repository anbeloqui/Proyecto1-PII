using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;

namespace ProyectoPII.Estrategias;

// ---------------------------------------------------------
// CLASE ESTRATEGIAPORUSUARIOSSIMILARES
// ---------------------------------------------------------

/// <summary>
/// Recomienda elementos consumidos o marcados positivamente
/// por usuarios con preferencias similares al usuario actual.
/// </summary>
public class EstrategiaPorUsuariosSimilares : IEstrategiaRecomendacion
{
    private List<Usuario> usuarios;

    public EstrategiaPorUsuariosSimilares(List<Usuario> usuarios)
    {
        this.usuarios = usuarios;
    }

    public List<IRecomendable> Recomendar(
        Usuario usuario,
        List<IRecomendable> catalogo)
    {
        List<int> consumidosUsuario = usuario.Historial.ObtenerItemsConsumidos();

        List<Usuario> similares = usuarios
            .Where(u => u.Id != usuario.Id)
            .Where(u => u.Preferencias.Any(p => usuario.Preferencias.Contains(p)))
            .ToList();

        List<int> idsRecomendados = similares
            .SelectMany(u => u.Historial.ObtenerItemsConsumidos())
            .Where(id => !consumidosUsuario.Contains(id))
            .Distinct()
            .ToList();

        return catalogo
            .Where(item => idsRecomendados.Contains(item.Id))
            .ToList();
    }
}
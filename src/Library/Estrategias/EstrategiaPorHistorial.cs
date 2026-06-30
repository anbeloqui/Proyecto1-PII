using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;

namespace ProyectoPII.Estrategias;

// ---------------------------------------------------------
// CLASE ESTRATEGIAPORHISTORIAL
// ---------------------------------------------------------
// Recomienda elementos similares a los que el usuario
// marcó con Like o Guardado.
//
// Evita recomendar elementos ya consumidos.
// ---------------------------------------------------------

/// <summary>
/// Recomienda elementos a partir del historial de interacciones del usuario.
/// </summary>
public class EstrategiaPorHistorial : IEstrategiaRecomendacion
{
    public List<IRecomendable> Recomendar(
        Usuario usuario,
        List<IRecomendable> catalogo)
    {
        List<IRecomendable> resultado = new();

        List<int> consumidos = usuario.Historial.ObtenerItemsConsumidos();
        List<int> positivos = usuario.Historial.ObtenerItemsConLike();

        positivos.AddRange(usuario.Historial.ObtenerItemsGuardados());

        List<string> atributosBase = catalogo
            .Where(item => positivos.Contains(item.Id))
            .SelectMany(item => item.Atributos)
            .Distinct()
            .ToList();

        foreach (IRecomendable item in catalogo)
        {
            if (consumidos.Contains(item.Id))
            {
                continue;
            }

            if (positivos.Contains(item.Id))
            {
                continue;
            }

            bool coincide = item.Atributos.Any(a => atributosBase.Contains(a));

            if (coincide)
            {
                resultado.Add(item);
            }
        }

        return resultado;
    }
}
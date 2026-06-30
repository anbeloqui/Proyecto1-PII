using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;

namespace ProyectoPII.Estrategias;

// ---------------------------------------------------------
// CLASE ESTRATEGIAPORPREFERENCIAS
// ---------------------------------------------------------
// Implementa una estrategia de recomendación basada
// en las preferencias del usuario.
//
// Recorre el catálogo y recomienda aquellos elementos
// cuyos atributos coinciden con las preferencias del usuario,
// evitando recomendar contenidos ya consumidos.
// ---------------------------------------------------------

/// <summary>
/// Recomienda elementos según las preferencias registradas por el usuario.
/// </summary>
public class EstrategiaPorPreferencias : IEstrategiaRecomendacion
{
    public List<IRecomendable> Recomendar(
        Usuario usuario,
        List<IRecomendable> catalogo)
    {
        List<IRecomendable> resultado = new();

        foreach (IRecomendable item in catalogo)
        {
            if (usuario.HistorialIds.Contains(item.Id))
            {
                continue;
            }

            foreach (string preferencia in usuario.Preferencias)
            {
                if (item.Atributos.Contains(preferencia))
                {
                    resultado.Add(item);
                    break;
                }
            }
        }

        return resultado;
    }
}
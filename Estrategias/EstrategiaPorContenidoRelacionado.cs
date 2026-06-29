using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;

namespace ProyectoPII.Estrategias;

// ---------------------------------------------------------
// CLASE EstrategiaPorContenidoRelacionado
// ---------------------------------------------------------

/// <summary>
/// Recomienda elementos relacionados a partir de los
/// atributos de contenidos que el usuario ya consumió.
/// </summary>
public class EstrategiaPorContenidoRelacionado : IEstrategiaRecomendacion
{
    public List<IRecomendable> Recomendar(
        Usuario usuario,
        List<IRecomendable> catalogo)
    {
        List<int> consumidos = usuario.Historial.ObtenerItemsConsumidos();

        List<string> atributosConsumidos = catalogo
            .Where(item => consumidos.Contains(item.Id))
            .SelectMany(item => item.Atributos)
            .Distinct()
            .ToList();

        return catalogo
            .Where(item => !consumidos.Contains(item.Id))
            .Where(item => item.Atributos.Any(a => atributosConsumidos.Contains(a)))
            .ToList();
    }
}
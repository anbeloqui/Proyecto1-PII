using ProyectoPII.Interfaces;

namespace ProyectoPII.Interfaces;

/// <summary>
/// Define el comportamiento común para los ordenadores
/// de recomendaciones.
/// </summary>
public interface IOrdenadorRecomendacion
{
    List<IRecomendable> Ordenar(List<IRecomendable> items);
}
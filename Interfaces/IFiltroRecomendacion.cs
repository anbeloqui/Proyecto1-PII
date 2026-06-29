using ProyectoPII.Interfaces;

namespace ProyectoPII.Interfaces;

public interface IFiltroRecomendacion
{
    List<IRecomendable> Filtrar(List<IRecomendable> items);
}
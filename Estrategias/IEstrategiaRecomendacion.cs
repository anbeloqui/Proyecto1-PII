using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;

namespace ProyectoPII.Estrategias;

// ---------------------------------------------------------
// INTERFAZ IESTRATEGIARECOMENDACION
// ---------------------------------------------------------
// Define el comportamiento común para las distintas
// estrategias de recomendación.
//
// Permite que el recomendador pueda cambiar la forma de
// generar sugerencias sin depender de una clase concreta.
// ---------------------------------------------------------

public interface IEstrategiaRecomendacion
{
    List<IRecomendable> Recomendar(
        Usuario usuario,
        List<IRecomendable> catalogo);
}
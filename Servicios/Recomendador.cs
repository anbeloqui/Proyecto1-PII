using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Estrategias;

namespace ProyectoPII.Servicios;

// ---------------------------------------------------------
// CLASE RECOMENDADOR
// ---------------------------------------------------------
// Contiene el motor principal de recomendación.
//
// En lugar de tener una única lógica fija, utiliza una
// estrategia de recomendación intercambiable.
//
// Esto permite cambiar la forma de recomendar sin modificar
// el recomendador.
// ---------------------------------------------------------

public class Recomendador
{
    private IEstrategiaRecomendacion estrategia;

    public Recomendador()
    {
        estrategia = new EstrategiaPorPreferencias();
    }

    public Recomendador(IEstrategiaRecomendacion estrategia)
    {
        this.estrategia = estrategia;
    }

    public List<IRecomendable> Recomendar(
        Usuario usuario,
        List<IRecomendable> catalogo)
    {
        return estrategia.Recomendar(usuario, catalogo);
    }
}
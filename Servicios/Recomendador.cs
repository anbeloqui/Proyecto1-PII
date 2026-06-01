using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;

namespace ProyectoPII.Servicios;

// ---------------------------------------------------------
// CLASE RECOMENDADOR
// ---------------------------------------------------------
// Contiene la lógica principal de recomendación.
//
// El recomendador compara las preferencias del usuario
// con los atributos de cada canción.
//
// Además, revisa el historial del usuario para evitar
// recomendar canciones que ya fueron consumidas.
// ---------------------------------------------------------


public class Recomendador
{
    public List<IRecomendable> RecomendarPorPreferencias(
        Usuario usuario,
        List<IRecomendable> catalogo)
    {
        List<IRecomendable> resultado = new();

        foreach (IRecomendable item in catalogo)
        {
            // Si el usuario ya consumió este contenido,
            // se saltea y no se recomienda.
            if (usuario.HistorialIds.Contains(item.Id))
            {
                continue;
            }
            
            // Se comparan las preferencias del usuario
            // con los atributos del contenido.
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
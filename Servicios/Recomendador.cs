using RecomendadorBot.Interfaces;
using RecomendadorBot.Models;

namespace RecomendadorBot.Services;

public class Recomendador
{
    public List<IRecomendable> RecomendarPorPreferencias(
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
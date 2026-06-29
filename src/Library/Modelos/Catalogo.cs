using ProyectoPII.Interfaces;

namespace ProyectoPII.Modelos;

/// <summary>
/// Representa el catálogo de elementos recomendables del sistema.
/// </summary>
public class Catalogo
{
    private List<IRecomendable> items = new();

    /// <summary>
    /// Agrega un elemento recomendable al catálogo.
    /// </summary>
    public void AgregarItem(IRecomendable item)
    {
        items.Add(item);
    }

    /// <summary>
    /// Elimina un elemento del catálogo por su identificador.
    /// </summary>
    public void EliminarItem(int id)
    {
        IRecomendable? item = items.FirstOrDefault(i => i.Id == id);

        if (item != null)
        {
            items.Remove(item);
        }
    }

    /// <summary>
    /// Devuelve todos los elementos recomendables del catálogo.
    /// </summary>
    public List<IRecomendable> ObtenerItems()
    {
        return items;
    }
}
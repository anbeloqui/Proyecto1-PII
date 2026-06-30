using ProyectoPII.Interfaces;

namespace ProyectoPII.Modelos;

/// <summary>
/// Representa el catálogo de elementos recomendables del sistema.
/// Permite agregar, eliminar y consultar los elementos disponibles.
/// </summary>
public class Catalogo
{
    private List<IRecomendable> items = new();

    /// <summary>
    /// Agrega un elemento recomendable al catálogo.
    /// </summary>
    /// <param name="item">Elemento recomendable que se agregará al catálogo.</param>
    public void AgregarItem(IRecomendable item)
    {
        items.Add(item);
    }

    /// <summary>
    /// Elimina un elemento del catálogo según su identificador.
    /// </summary>
    /// <param name="id">Identificador del elemento que se desea eliminar.</param>
    public void EliminarItem(int id)
    {
        IRecomendable? item = items.FirstOrDefault(i => i.Id == id);

        if (item != null)
        {
            items.Remove(item);
        }
    }

    /// <summary>
    /// Obtiene todos los elementos recomendables registrados en el catálogo.
    /// </summary>
    /// <returns>Lista de elementos recomendables disponibles.</returns>
    public List<IRecomendable> ObtenerItems()
    {
        return items;
    }
}
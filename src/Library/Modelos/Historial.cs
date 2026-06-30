namespace ProyectoPII.Modelos;

// ---------------------------------------------------------
// CLASE HISTORIAL
// ---------------------------------------------------------
// Representa el historial de interacciones realizadas
// por un usuario sobre los elementos del catálogo.
//
// Esta clase permite registrar las interacciones y
// consultarlas posteriormente para generar
// recomendaciones personalizadas.
// ---------------------------------------------------------

/// <summary>
/// Almacena las interacciones realizadas por un usuario y permite consultarlas
/// para obtener información utilizada por el sistema de recomendaciones.
/// </summary>
public class Historial
{
    private List<Interaccion> interacciones = new();

    /// <summary>
    /// Agrega una nueva interacción al historial.
    /// </summary>
    /// <param name="interaccion">Interacción que se desea registrar.</param>
    public void Agregar(Interaccion interaccion)
    {
        interacciones.Add(interaccion);
    }

    /// <summary>
    /// Obtiene todas las interacciones registradas.
    /// </summary>
    /// <returns>Lista con todas las interacciones del historial.</returns>
    public List<Interaccion> ObtenerTodas()
    {
        return interacciones;
    }

    /// <summary>
    /// Obtiene los identificadores de los elementos consumidos por el usuario.
    /// </summary>
    /// <returns>Lista de identificadores de elementos consumidos.</returns>
    public List<int> ObtenerItemsConsumidos()
    {
        return interacciones
            .Where(i => i.Tipo == TipoInteraccion.Consumido)
            .Select(i => i.ItemId)
            .ToList();
    }

    /// <summary>
    /// Obtiene los identificadores de los elementos marcados con "Like".
    /// </summary>
    /// <returns>Lista de identificadores de elementos con Like.</returns>
    public List<int> ObtenerItemsConLike()
    {
        return interacciones
            .Where(i => i.Tipo == TipoInteraccion.Like)
            .Select(i => i.ItemId)
            .ToList();
    }

    /// <summary>
    /// Obtiene los identificadores de los elementos guardados para ver después.
    /// </summary>
    /// <returns>Lista de identificadores de elementos guardados.</returns>
    public List<int> ObtenerItemsGuardados()
    {
        return interacciones
            .Where(i => i.Tipo == TipoInteraccion.Guardado)
            .Select(i => i.ItemId)
            .ToList();
    }
}
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

public class Historial
{
    private List<Interaccion> interacciones = new();

    public void Agregar(Interaccion interaccion)
    {
        interacciones.Add(interaccion);
    }

    public List<Interaccion> ObtenerTodas()
    {
        return interacciones;
    }

    public List<int> ObtenerItemsConsumidos()
    {
        return interacciones
            .Where(i => i.Tipo == TipoInteraccion.Consumido)
            .Select(i => i.ItemId)
            .ToList();
    }

    public List<int> ObtenerItemsConLike()
    {
        return interacciones
            .Where(i => i.Tipo == TipoInteraccion.Like)
            .Select(i => i.ItemId)
            .ToList();
    }

    public List<int> ObtenerItemsGuardados()
    {
        return interacciones
            .Where(i => i.Tipo == TipoInteraccion.Guardado)
            .Select(i => i.ItemId)
            .ToList();
    }
}
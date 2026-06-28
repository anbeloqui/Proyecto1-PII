/// <summary>
/// Representa los distintos tipos de interacción que un usuario puede
/// realizar sobre un elemento del catálogo.
/// </summary>

namespace ProyectoPII.Modelos;

public enum TipoInteraccion
{
    /// <summary>
    /// El usuario consumió el contenido.
    /// </summary>
    Consumido,
    /// <summary>
    /// El usuario indicó que le gusta el contenido.
    /// </summary>
    Like,
    /// <summary>
    /// El usuario indicó que no le gusta el contenido.
    /// </summary>
    Dislike,
    /// <summary>
    /// El usuario guardó el contenido para consultarlo más adelante.
    /// </summary>
    Guardado
}
/// -----------------------------------------
/// CLASE TipoInteraccion
/// -----------------------------------------
/// Representa los distintos tipos de 
/// interacción que un usuario puede
/// realizar sobre un elemento del catálogo.
/// -----------------------------------------

namespace ProyectoPII.Modelos;

/// <summary>
/// Representa los distintos tipos de interacción que un usuario puede realizar
/// sobre un elemento del catálogo.
/// </summary>
public enum TipoInteraccion
{
    /// <summary>
    /// El usuario consumió el elemento.
    /// </summary>
    Consumido,

    /// <summary>
    /// El usuario indicó que le gusta el elemento.
    /// </summary>
    Like,

    /// <summary>
    /// El usuario indicó que no le gusta el elemento.
    /// </summary>
    Dislike,

    /// <summary>
    /// El usuario guardó el elemento para verlo o consumirlo más adelante.
    /// </summary>
    Guardado
}
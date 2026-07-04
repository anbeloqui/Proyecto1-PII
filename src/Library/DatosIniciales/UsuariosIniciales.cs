using FachadaProyecto = ProyectoPII.Fachada.Fachada;
using ProyectoPII.Modelos;

namespace ProyectoPII.DatosIniciales;

/// <summary>
/// Carga usuarios iniciales con preferencias e interacciones para demostración.
/// </summary>
public static class UsuariosIniciales
{
    /// <summary>
    /// Agrega usuarios iniciales a la fachada recibida.
    /// </summary>
    /// <param name="fachada">Fachada del sistema donde se cargarán los usuarios.</param>
    public static void Cargar(FachadaProyecto fachada)
    {
        ArgumentNullException.ThrowIfNull(fachada);

        fachada.RegistrarUsuario(901, "Ana");
        fachada.RegistrarUsuario(902, "Luis");
        fachada.RegistrarUsuario(903, "Maria");
        fachada.RegistrarUsuario(904, "Carlos");
        fachada.RegistrarUsuario(905, "Sofia");

        fachada.AgregarPreferencia("Ana", "rock");
        fachada.AgregarPreferencia("Luis", "ciencia ficcion");
        fachada.AgregarPreferencia("Maria", "aventura");
        fachada.AgregarPreferencia("Maria", "fantasia");
        fachada.AgregarPreferencia("Carlos", "rock");
        fachada.AgregarPreferencia("Carlos", "ciencia ficcion");
        fachada.AgregarPreferencia("Sofia", "pop");
        fachada.AgregarPreferencia("Sofia", "drama");

        fachada.AgregarInteraccion("Ana", 1, TipoInteraccion.Like);
        fachada.AgregarInteraccion("Ana", 5, TipoInteraccion.Consumido);
        fachada.AgregarInteraccion("Ana", 7, TipoInteraccion.Like);

        fachada.AgregarInteraccion("Luis", 1001, TipoInteraccion.Consumido);
        fachada.AgregarInteraccion("Luis", 1002, TipoInteraccion.Like);
        fachada.AgregarInteraccion("Luis", 1012, TipoInteraccion.Consumido);

        fachada.AgregarInteraccion("Maria", 1003, TipoInteraccion.Consumido);
        fachada.AgregarInteraccion("Maria", 1008, TipoInteraccion.Like);
        fachada.AgregarInteraccion("Maria", 1012, TipoInteraccion.Like);

        fachada.AgregarInteraccion("Carlos", 1, TipoInteraccion.Like);
        fachada.AgregarInteraccion("Carlos", 1001, TipoInteraccion.Like);
        fachada.AgregarInteraccion("Carlos", 1002, TipoInteraccion.Consumido);

        fachada.AgregarInteraccion("Sofia", 1002, TipoInteraccion.Like);
        fachada.AgregarInteraccion("Sofia", 1, TipoInteraccion.Like);
        fachada.AgregarInteraccion("Sofia", 1008, TipoInteraccion.Like);
    }
}
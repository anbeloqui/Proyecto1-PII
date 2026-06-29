using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Servicios;

namespace ProyectoPII.Fachada;

/// <summary>
/// Punto de entrada principal del sistema.
/// Coordina usuarios, catálogo y recomendador.
/// </summary>
public class Fachada
{
    private List<Usuario> usuarios;
    private Catalogo catalogo;
    private Recomendador recomendador;

    public Fachada()
    {
        usuarios = new List<Usuario>();
        catalogo = new Catalogo();
        recomendador = new Recomendador();
    }

    /// <summary>
    /// Registra un nuevo usuario en el sistema.
    /// </summary>
    /// <param name="id">Identificador del usuario.</param>
    /// <param name="nombre">Nombre del usuario.</param>
    public void RegistrarUsuario(int id, string nombre)
    {
        usuarios.Add(new Usuario { Id = id, Nombre = nombre });
    }

    /// <summary>
    /// Agrega un elemento recomendable al catálogo.
    /// </summary>
    /// <param name="item">Elemento a agregar.</param>
    public void AgregarItem(IRecomendable item)
    {
        catalogo.AgregarItem(item);
    }

    /// <summary>
    /// Elimina un elemento del catálogo según su identificador.
    /// </summary>
    /// <param name="id">Identificador del elemento a eliminar.</param>
    public void EliminarItem(int id)
    {
        catalogo.EliminarItem(id);
    }

    /// <summary>
    /// Agrega una canción al catálogo del sistema.
    /// </summary>
    /// <param name="id">Identificador de la canción.</param>
    /// <param name="nombre">Nombre de la canción.</param>
    /// <param name="artista">Artista de la canción.</param>
    /// <param name="atributos">Atributos usados para recomendar.</param>
    public void AgregarCancion(int id, string nombre, string artista, List<string> atributos)
    {
        Cancion cancion = new Cancion
        {
            Id = id,
            Nombre = nombre,
            Artista = artista,
            Atributos = atributos
        };

        AgregarItem(cancion);
    }

    /// <summary>
    /// Busca un usuario por su nombre.
    /// </summary>
    /// <param name="nombre">Nombre del usuario.</param>
    /// <returns>Usuario encontrado, o null si no existe.</returns>
    public Usuario? ObtenerUsuario(string nombre)
    {
        return usuarios.Find(u => u.Nombre == nombre);
    }
    
    /// <summary>
    /// Agrega una preferencia a un usuario.
    /// </summary>
    /// <param name="nombreUsuario">Nombre del usuario.</param>
    /// <param name="preferencia">Preferencia a agregar.</param>
    public void AgregarPreferencia(string nombreUsuario, string preferencia)
    {
        Usuario? usuario = ObtenerUsuario(nombreUsuario);

        if (usuario == null)
        {
            return;
        }

        usuario.Preferencias.Add(preferencia);
    }

    /// <summary>
    /// Registra una interacción de un usuario con un elemento.
    /// </summary>
    /// <param name="nombreUsuario">Nombre del usuario.</param>
    /// <param name="itemId">Identificador del elemento.</param>
    /// <param name="tipo">Tipo de interacción realizada.</param>
    public void AgregarInteraccion(
        string nombreUsuario,
        int itemId,
        TipoInteraccion tipo)
    {
        Usuario? usuario = ObtenerUsuario(nombreUsuario);

        if (usuario == null)
        {
            return;
        }

        Interaccion interaccion = new Interaccion
        {
            UsuarioId = usuario.Id,
            ItemId = itemId,
            Tipo = tipo,
            Fecha = DateTime.Now
        };

        usuario.Historial.Agregar(interaccion);

        // Compatibilidad con el recomendador actual.
        if (tipo == TipoInteraccion.Consumido)
        {
            usuario.HistorialIds.Add(itemId);
        }
    }

    /// <summary>
    /// Registra un Like de un usuario sobre un elemento.
    /// </summary>
    /// <param name="nombreUsuario">Nombre del usuario.</param>
    /// <param name="itemId">Identificador del elemento.</param>
    public void Like(string nombreUsuario, int itemId)
    {
        AgregarInteraccion(nombreUsuario, itemId, TipoInteraccion.Like);
    }

    /// <summary>
    /// Registra un Dislike de un usuario sobre un elemento.
    /// </summary>
    /// <param name="nombreUsuario">Nombre del usuario.</param>
    /// <param name="itemId">Identificador del elemento.</param>
    public void Dislike(string nombreUsuario, int itemId)
    {
        AgregarInteraccion(nombreUsuario, itemId, TipoInteraccion.Dislike);
    }

    /// <summary>
    /// Guarda un elemento para verlo después.
    /// </summary>
    /// <param name="nombreUsuario">Nombre del usuario.</param>
    /// <param name="itemId">Identificador del elemento.</param>
    public void GuardarParaDespues(string nombreUsuario, int itemId)
    {
        AgregarInteraccion(nombreUsuario, itemId, TipoInteraccion.Guardado);
    }

    /// <summary>
    /// Devuelve todos los elementos recomendables del catálogo.
    /// </summary>
    /// <returns>Lista de elementos recomendables.</returns>
    public List<IRecomendable> ObtenerItems()
    {
        return catalogo.ObtenerItems();
    }

    /// <summary>
    /// Devuelve el historial de interacciones de un usuario.
    /// </summary>
    /// <param name="nombreUsuario">Nombre del usuario.</param>
    /// <returns>Lista de interacciones del usuario.</returns>
    public List<Interaccion> VerHistorial(string nombreUsuario)
    {
        Usuario? usuario = ObtenerUsuario(nombreUsuario);

        if (usuario == null)
        {
            return new List<Interaccion>();
        }

        return usuario.Historial.ObtenerTodas();
    }
    
    /// <summary>
    /// Genera recomendaciones para un usuario.
    /// </summary>
    /// <param name="nombreUsuario">Nombre del usuario.</param>
    /// <returns>Lista de elementos recomendados.</returns>
    public List<IRecomendable> Recomendar(string nombreUsuario)
    {
        Usuario? usuario = ObtenerUsuario(nombreUsuario);

        if (usuario == null)
        {
            return new List<IRecomendable>();
        }

        return recomendador.Recomendar(
            usuario,
            ObtenerItems()
        );
    }
}
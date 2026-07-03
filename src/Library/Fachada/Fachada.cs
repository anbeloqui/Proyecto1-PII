using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Servicios;
using ProyectoPII.Excepciones;

namespace ProyectoPII.Fachada;

/// <summary>
/// Inicializa una nueva instancia de la fachada.
/// 
/// Aplica el patrón Facade, centralizando el acceso al sistema
/// y ocultando la complejidad interna de usuarios, catálogo y recomendaciones.
/// </summary>
public class Fachada
{
    private List<Usuario> usuarios;
    private Catalogo catalogo;
    private Recomendador recomendador;
    
    /// <summary>
    /// Inicializa una nueva instancia de la fachada, creando la lista de usuarios,
    /// el catálogo y el motor de recomendaciones por preferencias.
    /// </summary>
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
/// <remarks>
/// Precondición: no debe existir previamente un usuario con el mismo nombre.
/// Postcondición: el usuario queda agregado a la lista de usuarios registrados.
/// </remarks>
/// <exception cref="ExcepcionUsuarioYaExiste">
/// Se lanza cuando ya existe un usuario registrado con el mismo nombre.
/// </exception>
    public void RegistrarUsuario(int id, string nombre)
{
    if (ObtenerUsuario(nombre) != null)
    {
        throw new ExcepcionUsuarioYaExiste(nombre);
    }

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
    
    private Usuario ObtenerUsuarioRegistrado(string nombreUsuario)
{
    Usuario? usuario = ObtenerUsuario(nombreUsuario);

    if (usuario == null)
    {
        throw new ExcepcionUsuarioNoEncontrado(nombreUsuario);
    }

    return usuario;
}
    /// <summary>
/// Agrega una preferencia a un usuario registrado.
/// </summary>
/// <param name="nombreUsuario">Nombre del usuario.</param>
/// <param name="preferencia">Preferencia a agregar.</param>
/// <remarks>
/// Precondición: el usuario debe estar registrado en el sistema.
/// Postcondición: la preferencia queda agregada al usuario indicado.
/// </remarks>
/// <exception cref="ExcepcionUsuarioNoEncontrado">
/// Se lanza cuando no existe un usuario registrado con el nombre indicado.
/// </exception>
   public void AgregarPreferencia(string nombreUsuario, string preferencia)
{
    Usuario usuario = ObtenerUsuarioRegistrado(nombreUsuario);

    usuario.Preferencias.Add(preferencia);
}

/// <summary>
/// Registra una interacción de un usuario registrado con un elemento recomendable.
/// </summary>
/// <param name="nombreUsuario">Nombre del usuario.</param>
/// <param name="itemId">Identificador del elemento.</param>
/// <param name="tipo">Tipo de interacción realizada.</param>
/// <remarks>
/// Precondición: el usuario debe estar registrado en el sistema.
/// Postcondición: la interacción queda agregada al historial del usuario.
/// Si la interacción es de tipo Consumido, también se registra el identificador
/// del elemento en el historial de consumidos.
/// </remarks>
/// <exception cref="ExcepcionUsuarioNoEncontrado">
/// Se lanza cuando no existe un usuario registrado con el nombre indicado.
/// </exception>
    public void AgregarInteraccion(
    string nombreUsuario,
    int itemId,
    TipoInteraccion tipo)
{
    Usuario usuario = ObtenerUsuarioRegistrado(nombreUsuario);

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
/// Registra un Like de un usuario registrado sobre un elemento recomendable.
/// </summary>
/// <param name="nombreUsuario">Nombre del usuario.</param>
/// <param name="itemId">Identificador del elemento.</param>
/// <remarks>
/// Precondición: el usuario debe estar registrado en el sistema.
/// Postcondición: queda registrada una interacción de tipo Like
/// en el historial del usuario.
/// </remarks>
/// <exception cref="ExcepcionUsuarioNoEncontrado">
/// Se lanza cuando no existe un usuario registrado con el nombre indicado.
/// </exception>
    public void Like(string nombreUsuario, int itemId)
    {
        AgregarInteraccion(nombreUsuario, itemId, TipoInteraccion.Like);
    }

    /// <summary>
/// Registra un Dislike de un usuario registrado sobre un elemento recomendable.
/// </summary>
/// <param name="nombreUsuario">Nombre del usuario.</param>
/// <param name="itemId">Identificador del elemento.</param>
/// <remarks>
/// Precondición: el usuario debe estar registrado en el sistema.
/// Postcondición: queda registrada una interacción de tipo Dislike
/// en el historial del usuario.
/// </remarks>
/// <exception cref="ExcepcionUsuarioNoEncontrado">
/// Se lanza cuando no existe un usuario registrado con el nombre indicado.
/// </exception>
    public void Dislike(string nombreUsuario, int itemId)
    {
        AgregarInteraccion(nombreUsuario, itemId, TipoInteraccion.Dislike);
    }

   /// <summary>
/// Guarda un elemento recomendable para que el usuario pueda verlo después.
/// </summary>
/// <param name="nombreUsuario">Nombre del usuario.</param>
/// <param name="itemId">Identificador del elemento.</param>
/// <remarks>
/// Precondición: el usuario debe estar registrado en el sistema.
/// Postcondición: queda registrada una interacción de tipo Guardado
/// en el historial del usuario.
/// </remarks>
/// <exception cref="ExcepcionUsuarioNoEncontrado">
/// Se lanza cuando no existe un usuario registrado con el nombre indicado.
/// </exception>
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
/// Devuelve el historial de interacciones de un usuario registrado.
/// </summary>
/// <param name="nombreUsuario">Nombre del usuario.</param>
/// <returns>Lista de interacciones del usuario.</returns>
/// <remarks>
/// Precondición: el usuario debe estar registrado en el sistema.
/// Postcondición: se devuelve la lista de interacciones asociada al usuario.
/// </remarks>
/// <exception cref="ExcepcionUsuarioNoEncontrado">
/// Se lanza cuando no existe un usuario registrado con el nombre indicado.
/// </exception>
   public List<Interaccion> VerHistorial(string nombreUsuario)
{
    Usuario usuario = ObtenerUsuarioRegistrado(nombreUsuario);

    return usuario.Historial.ObtenerTodas();
}
    
    /// <summary>
/// Genera recomendaciones para un usuario registrado utilizando la estrategia por preferencias.
/// </summary>
/// <param name="nombreUsuario">Nombre del usuario.</param>
/// <returns>Lista de elementos recomendados.</returns>
/// <remarks>
/// Precondición: el usuario debe estar registrado en el sistema.
/// Postcondición: se devuelve una lista de elementos recomendables para el usuario.
/// </remarks>
/// <exception cref="ExcepcionUsuarioNoEncontrado">
/// Se lanza cuando no existe un usuario registrado con el nombre indicado.
/// </exception>
    public List<IRecomendable> Recomendar(string nombreUsuario)
    {
        return Recomendar(nombreUsuario, "preferencias");
    }
    
    /// <summary>
/// Genera recomendaciones para un usuario registrado utilizando la estrategia indicada.
/// </summary>
/// <param name="nombreUsuario">Nombre del usuario.</param>
/// <param name="tipoEstrategia">Tipo de estrategia a utilizar.</param>
/// <returns>Lista de elementos recomendados.</returns>
/// <remarks>
/// Precondición: el usuario debe estar registrado en el sistema.
/// Precondición: el tipo de estrategia debe corresponder a una estrategia disponible.
/// Postcondición: se devuelve una lista de elementos recomendables para el usuario.
/// </remarks>
/// <exception cref="ExcepcionUsuarioNoEncontrado">
/// Se lanza cuando no existe un usuario registrado con el nombre indicado.
/// </exception>
public List<IRecomendable> Recomendar(
    string nombreUsuario,
    string tipoEstrategia)
{
    ObtenerUsuarioRegistrado(nombreUsuario);

    return recomendador.Recomendar(
        nombreUsuario,
        tipoEstrategia,
        usuarios,
        catalogo);
}
}
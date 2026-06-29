using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Servicios;

namespace ProyectoPII.Fachada;

// ---------------------------------------------------------
// CLASE FACHADA
// ---------------------------------------------------------
// Funciona como punto de entrada al sistema.
//
// En vez de que Program.cs tenga que manejar directamente
// usuarios, catálogo y recomendador, se comunica con esta clase.
//
// Esto hace que el código quede más ordenado y más fácil
// de usar desde afuera.
// ---------------------------------------------------------

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

    // Registra un nuevo usuario en el sistema.
    public void RegistrarUsuario(int id, string nombre)
    {
        usuarios.Add(new Usuario { Id = id, Nombre = nombre });
    }

    // Agrega una canción al catálogo del sistema.
    public void AgregarCancion(int id, string nombre, string artista, List<string> atributos)
    {
        Cancion cancion = new Cancion
        {
            Id = id,
            Nombre = nombre,
            Artista = artista,
            Atributos = atributos
        };

        catalogo.AgregarCancion(cancion);
    }

     // Busca un usuario por su nombre.
    public Usuario? ObtenerUsuario(string nombre)
    {
        return usuarios.Find(u => u.Nombre == nombre);
    }
    
    // Agrega una preferencia a un usuario registrado.
    public void AgregarPreferencia(string nombreUsuario, string preferencia)
    {
        Usuario? usuario = ObtenerUsuario(nombreUsuario);

        if (usuario == null)
        {
            return;
        }

        usuario.Preferencias.Add(preferencia);
    }

    // Registra una interacción realizada por un usuario.
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

     // Devuelve todas las canciones cargadas en el catálogo.
    public List<Cancion> ObtenerCanciones()
    {
        return catalogo.ObtenerCanciones();
    }
    
    // Genera recomendaciones para un usuario específico.
    public List<IRecomendable> Recomendar(string nombreUsuario)
    {
        Usuario? usuario = ObtenerUsuario(nombreUsuario);

        if (usuario == null)
        {
            return new List<IRecomendable>();
        }

        return recomendador.RecomendarPorPreferencias(
            usuario,
            catalogo.ObtenerCanciones().Cast<IRecomendable>().ToList()
        );
    }
}
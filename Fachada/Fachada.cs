using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Servicios;

namespace ProyectoPII.Fachada;

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

    public void RegistrarUsuario(int id, string nombre)
    {
        usuarios.Add(new Usuario { Id = id, Nombre = nombre });
    }

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

    public Usuario? ObtenerUsuario(string nombre)
    {
        return usuarios.Find(u => u.Nombre == nombre);
    }

    public List<Cancion> ObtenerCanciones()
    {
        return catalogo.ObtenerCanciones();
    }

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
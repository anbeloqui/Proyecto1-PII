namespace ProyectoPII;

public class Fachada
{
    private List<Usuario> usuarios;
    private Catalogo catalogo;

    public Fachada()
    {
        usuarios = new List<Usuario>();
        catalogo = new Catalogo();
    }

    public void RegistrarUsuario(string nombre)
    {
        usuarios.Add(new Usuario(nombre));
    }

    public void AgregarItem(string nombre, string artista, List<string> atributos)
    {
        var item = new Item(nombre, artista, atributos);
        catalogo.AgregarItem(item);
    }

    public Usuario ObtenerUsuario(string nombre)
    {
        return usuarios.Find(u => u.Nombre == nombre);
    }

    public List<Item> ObtenerItems()
    {
        return catalogo.ObtenerItems();
    }
}
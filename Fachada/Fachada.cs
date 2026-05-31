namespace ProyectoPII;

public class Fachada
{
    private List<Usuario> usuarios;
    private Catalogo catalogo;
    private Recomendador motor;

    public Fachada()
    {
        usuarios = new List<Usuario>();
        catalogo = new Catalogo();
        motor = new Recomendador();
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

    public Usuario? ObtenerUsuario(string nombre)
    {
        return usuarios.Find(u => u.Nombre == nombre);
    }

    public List<Item> ObtenerItems()
    {
        return catalogo.ObtenerItems();
    }

    public List<Item> Recomendar(string nombreUsuario)
    {
        Usuario? usuario = ObtenerUsuario(nombreUsuario);

        if (usuario == null)
        {
            return new List<Item>();
        }

        return motor.Recomendar(usuario, catalogo.ObtenerItems());
    }
}
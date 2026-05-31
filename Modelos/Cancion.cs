namespace ProyectoPII;

public class Item
{
    public string Nombre { get; set; }
    public string Artista { get; set; }
    public List<string> Atributos { get; set; }
    public bool Eliminado { get; set; }

    public Item(string nombre, string artista, List<string> atributos)
    {
        Nombre = nombre;
        Artista = artista;
        Atributos = atributos;
        Eliminado = false;
    }
}
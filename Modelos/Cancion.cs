using ProyectoPII.Interfaces;

namespace ProyectoPII.Modelos;

public class Cancion : IRecomendable
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Artista { get; set; } = "";
    public List<string> Atributos { get; set; } = new();
}
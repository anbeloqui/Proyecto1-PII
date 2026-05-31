namespace ProyectoPII.Modelos;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public List<string> Preferencias { get; set; } = new();
    public List<int> HistorialIds { get; set; } = new();
}
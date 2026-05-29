namespace ProyectoPII;

public class Usuario
{
    public string Nombre { get; set; }
    public List<string> Preferencias { get; set; }
    public List<Interaccion> Historial { get; set; }

    public Usuario(string nombre)
    {
        Nombre = nombre;
        Preferencias = new List<string>();
        Historial = new List<Interaccion>();
    }

    public void AgregarPreferencia(string preferencia)
    {
        Preferencias.Add(preferencia);
    }

    public void AgregarInteraccion(Interaccion interaccion)
    {
        Historial.Add(interaccion);
    }
}
namespace ProyectoPII.Modelos;

public class Catalogo
{
    public List<Cancion> Canciones { get; set; } = new();

    public void AgregarCancion(Cancion cancion)
    {
        Canciones.Add(cancion);
    }

    public List<Cancion> ObtenerCanciones()
    {
        return Canciones;
    }
}
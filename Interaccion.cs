namespace ProyectoPII;

public class Interaccion
{
    public Item Item { get; set; }
    public string Tipo { get; set; } // ejemplo: "escuchó", "vio"
    public bool? LeGusto { get; set; }

    public Interaccion(Item item, string tipo, bool? leGusto)
    {
        Item = item;
        Tipo = tipo;
        LeGusto = leGusto;
    }
}
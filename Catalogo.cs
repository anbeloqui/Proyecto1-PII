namespace ProyectoPII;

public class Catalogo
{
    public List<Item> Items { get; set; }

    public Catalogo()
    {
        Items = new List<Item>();
    }

    public void AgregarItem(Item item)
    {
        Items.Add(item);
    }

    public List<Item> ObtenerItems()
    {
        return Items;
    }
}
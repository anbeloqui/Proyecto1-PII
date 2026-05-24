namespace ProyectoPII;

public class MotorRecomendacion
{
    public List<Item> Recomendar(Usuario usuario, List<Item> items)
    {
        List<Item> recomendaciones = new List<Item>();

        foreach (Item item in items)
        {
            foreach (string preferencia in usuario.Preferencias)
            {
                if (item.Atributos.Contains(preferencia) && !item.Eliminado)
                {
                    recomendaciones.Add(item);
                    break;
                }
            }
        }

        return recomendaciones;
    }
}
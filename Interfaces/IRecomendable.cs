namespace ProyectoPII.Interfaces;

public interface IRecomendable
{
    int Id { get; }
    string Nombre { get; }
    List<string> Atributos { get; }
}
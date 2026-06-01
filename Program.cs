using ProyectoPII.Fachada;

Fachada fachada = new Fachada();

fachada.RegistrarUsuario(1, "Andres");

fachada.AgregarCancion(1, "Song A", "Artista 1", new List<string> { "rock" });
fachada.AgregarCancion(2, "Song B", "Artista 2", new List<string> { "pop" });

var usuario = fachada.ObtenerUsuario("Andres");

if (usuario != null)
{
    usuario.Preferencias.Add("rock");
}

var recomendaciones = fachada.Recomendar("Andres");

foreach (var item in recomendaciones)
{
    Console.WriteLine(item.Nombre);
}
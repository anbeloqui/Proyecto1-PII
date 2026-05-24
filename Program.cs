var fachada = new Fachada();

fachada.RegistrarUsuario("Andres");

fachada.AgregarItem("Song A", "Artista 1", new List<string> { "rock" });
fachada.AgregarItem("Song B", "Artista 2", new List<string> { "pop" });

var usuario = fachada.ObtenerUsuario("Andres");
usuario.AgregarPreferencia("rock");

var recomendaciones = fachada.Recomendar("Andres");

foreach (var item in recomendaciones)
{
    Console.WriteLine(item.Nombre);
}
Usuario usuario = new Usuario
{
    Id = 1,
    Nombre = "Ana",
    Preferencias = new List<string> { "rock", "pop" },
    HistorialIds = new List<int> { 1 }
};

List<IRecomendable> canciones = new List<IRecomendable>
{
    new Cancion { Id = 1, Nombre = "Ya escuchada", Artista = "Banda A", Atributos = new() { "rock" } },
    new Cancion { Id = 2, Nombre = "Rock nuevo", Artista = "Banda B", Atributos = new() { "rock" } },
    new Cancion { Id = 3, Nombre = "Clásica", Artista = "Banda C", Atributos = new() { "clasica" } },
    new Cancion { Id = 4, Nombre = "Pop moderno", Artista = "Banda D", Atributos = new() { "pop" } }
};

Recomendador recomendador = new Recomendador();

List<IRecomendable> recomendaciones =
    recomendador.RecomendarPorPreferencias(usuario, canciones);

Console.WriteLine($"Recomendaciones para {usuario.Nombre}:");

foreach (IRecomendable item in recomendaciones)
{
    Console.WriteLine($"- {item.Nombre}");
}
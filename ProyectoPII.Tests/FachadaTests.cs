using ProyectoPII.Fachada;
using ProyectoPII.Modelos;
using ProyectoPII.Interfaces;

namespace ProyectoPII.Tests;

public class FachadaTests
{
    // Comprueba que un usuario registrado mediante la
    // fachada pueda recuperarse correctamente.
    [Fact]
    public void RegistrarUsuarioGuardaCorrectamenteElUsuario()
    {
        
        Fachada.Fachada fachada = new();

        fachada.RegistrarUsuario(1, "Ana");

        var usuario = fachada.ObtenerUsuario("Ana");

        Assert.NotNull(usuario);
        Assert.Equal(1, usuario!.Id);
        Assert.Equal("Ana", usuario.Nombre);
    }

    [Fact]
    public void AgregarPreferenciaGuardaPreferenciaEnUsuario()
    {
        Fachada.Fachada fachada = new();

        fachada.RegistrarUsuario(1, "Ana");
        fachada.AgregarPreferencia("Ana", "rock");

        Usuario? usuario = fachada.ObtenerUsuario("Ana");

        Assert.NotNull(usuario);
        Assert.Contains("rock", usuario!.Preferencias);
    }

    [Fact]
    public void AgregarInteraccionGuardaInteraccionEnHistorial()
    {
        Fachada.Fachada fachada = new();

        fachada.RegistrarUsuario(1, "Ana");
        fachada.AgregarInteraccion("Ana", 10, TipoInteraccion.Consumido);

        Usuario? usuario = fachada.ObtenerUsuario("Ana");

        Assert.NotNull(usuario);
        Assert.Contains(
            usuario!.Historial.ObtenerTodas(),
            i => i.ItemId == 10 && i.Tipo == TipoInteraccion.Consumido
        );
    }

    [Fact]
    public void RecomendarDevuelveElementosSegunPreferencias()
    {
        Fachada.Fachada fachada = new();

        fachada.RegistrarUsuario(1, "Ana");
        fachada.AgregarPreferencia("Ana", "rock");

        fachada.AgregarCancion(
            1,
            "Rock",
            "Artista A",
            new List<string> { "rock" });

        fachada.AgregarCancion(
            2,
            "Pop",
            "Artista B",
            new List<string> { "pop" });

        List<IRecomendable> resultado = fachada.Recomendar("Ana");

        Assert.Single(resultado);
        Assert.Equal("Rock", resultado[0].Nombre);
    }
}
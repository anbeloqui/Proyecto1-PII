using ProyectoPII.Fachada;

namespace ProyectoPII.Tests;

public class FachadaTests
{
    // Comprueba que un usuario registrado mediante la
    // fachada pueda recuperarse correctamente.
    [Fact]
    public void RegistrarUsuarioGuardaCorrectamenteElUsuario()
    {
        
        ProyectoPII.Fachada.Fachada fachada = new ProyectoPII.Fachada.Fachada();

        fachada.RegistrarUsuario(1, "Ana");

        var usuario = fachada.ObtenerUsuario("Ana");

        Assert.NotNull(usuario);
        Assert.Equal(1, usuario!.Id);
        Assert.Equal("Ana", usuario.Nombre);
    }
}
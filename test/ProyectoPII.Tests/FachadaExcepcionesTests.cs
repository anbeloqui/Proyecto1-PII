using ProyectoPII.Excepciones;
using Xunit;

namespace ProyectoPII.Tests;

public class FachadaExcepcionesTests
{
    [Fact]
    public void RegistrarUsuarioLanzaExcepcionSiUsuarioYaExiste()
    {
        ProyectoPII.Fachada.Fachada fachada = new ProyectoPII.Fachada.Fachada();

        fachada.RegistrarUsuario(1, "Andres");

        Assert.Throws<ExcepcionUsuarioYaExiste>(() =>
        {
            fachada.RegistrarUsuario(2, "Andres");
        });
    }

    [Fact]
    public void AgregarPreferenciaLanzaExcepcionSiUsuarioNoExiste()
    {
        ProyectoPII.Fachada.Fachada fachada = new ProyectoPII.Fachada.Fachada();

        Assert.Throws<ExcepcionUsuarioNoEncontrado>(() =>
        {
            fachada.AgregarPreferencia("NoExiste", "rock");
        });
    }

    [Fact]
    public void RecomendarLanzaExcepcionSiUsuarioNoExiste()
    {
        ProyectoPII.Fachada.Fachada fachada = new ProyectoPII.Fachada.Fachada();

        Assert.Throws<ExcepcionUsuarioNoEncontrado>(() =>
        {
            fachada.Recomendar("NoExiste");
        });
    }

    [Fact]
    public void LikeLanzaExcepcionSiUsuarioNoExiste()
    {
        ProyectoPII.Fachada.Fachada fachada = new ProyectoPII.Fachada.Fachada();

        Assert.Throws<ExcepcionUsuarioNoEncontrado>(() =>
        {
            fachada.Like("NoExiste", 1);
        });
    }

    [Fact]
    public void DislikeLanzaExcepcionSiUsuarioNoExiste()
    {
        ProyectoPII.Fachada.Fachada fachada = new ProyectoPII.Fachada.Fachada();

        Assert.Throws<ExcepcionUsuarioNoEncontrado>(() =>
        {
            fachada.Dislike("NoExiste", 1);
        });
    }

    [Fact]
    public void GuardarParaDespuesLanzaExcepcionSiUsuarioNoExiste()
    {
        ProyectoPII.Fachada.Fachada fachada = new ProyectoPII.Fachada.Fachada();

        Assert.Throws<ExcepcionUsuarioNoEncontrado>(() =>
        {
            fachada.GuardarParaDespues("NoExiste", 1);
        });
    }
}
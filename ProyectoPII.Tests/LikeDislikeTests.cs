using ProyectoPII.Fachada;
using ProyectoPII.Modelos;

namespace ProyectoPII.Tests;

public class LikeDislikeTests
{
    [Fact]
    public void LikeRegistraInteraccionTipoLike()
    {
        Fachada.Fachada fachada = new();

        fachada.RegistrarUsuario(1, "Ana");
        fachada.Like("Ana", 10);

        Usuario? usuario = fachada.ObtenerUsuario("Ana");

        Assert.NotNull(usuario);
        Assert.Contains(
            usuario!.Historial.ObtenerTodas(),
            i => i.ItemId == 10 && i.Tipo == TipoInteraccion.Like
        );
    }

    [Fact]
    public void DislikeRegistraInteraccionTipoDislike()
    {
        Fachada.Fachada fachada = new();

        fachada.RegistrarUsuario(1, "Ana");
        fachada.Dislike("Ana", 20);

        Usuario? usuario = fachada.ObtenerUsuario("Ana");

        Assert.NotNull(usuario);
        Assert.Contains(
            usuario!.Historial.ObtenerTodas(),
            i => i.ItemId == 20 && i.Tipo == TipoInteraccion.Dislike
        );
    }
}
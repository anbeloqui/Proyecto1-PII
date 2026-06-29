using ProyectoPII.Fachada;
using ProyectoPII.Modelos;

namespace ProyectoPII.Tests;

public class GuardarParaDespuesTests
{
    [Fact]
    public void GuardarParaDespuesRegistraInteraccionTipoGuardado()
    {
        Fachada.Fachada fachada = new();

        fachada.RegistrarUsuario(1, "Ana");
        fachada.GuardarParaDespues("Ana", 30);

        Usuario? usuario = fachada.ObtenerUsuario("Ana");

        Assert.NotNull(usuario);
        Assert.Contains(
            usuario!.Historial.ObtenerTodas(),
            i => i.ItemId == 30 && i.Tipo == TipoInteraccion.Guardado
        );
    }
}
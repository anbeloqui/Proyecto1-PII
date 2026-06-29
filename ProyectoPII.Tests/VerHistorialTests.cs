using ProyectoPII.Fachada;
using ProyectoPII.Modelos;

namespace ProyectoPII.Tests;

public class VerHistorialTests
{
    [Fact]
    public void VerHistorialDevuelveInteraccionesDelUsuario()
    {
        Fachada.Fachada fachada = new();

        fachada.RegistrarUsuario(1, "Ana");
        fachada.AgregarInteraccion("Ana", 10, TipoInteraccion.Consumido);
        fachada.Like("Ana", 20);

        List<Interaccion> historial = fachada.VerHistorial("Ana");

        Assert.Equal(2, historial.Count);
        Assert.Contains(historial, i => i.ItemId == 10);
        Assert.Contains(historial, i => i.ItemId == 20);
    }

    [Fact]
    public void VerHistorialDevuelveListaVaciaSiUsuarioNoExiste()
    {
        Fachada.Fachada fachada = new();

        List<Interaccion> historial = fachada.VerHistorial("NoExiste");

        Assert.Empty(historial);
    }
}
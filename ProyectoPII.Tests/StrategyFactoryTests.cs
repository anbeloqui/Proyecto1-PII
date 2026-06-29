using ProyectoPII.Estrategias;
using ProyectoPII.Modelos;
using ProyectoPII.Servicios;

namespace ProyectoPII.Tests;

public class StrategyFactoryTests
{
    [Fact]
    public void CrearPreferenciasDevuelveEstrategiaPorPreferencias()
    {
        List<Usuario> usuarios = new();

        var estrategia = StrategyFactory.Crear("preferencias", usuarios);

        Assert.IsType<EstrategiaPorPreferencias>(estrategia);
    }

    [Fact]
    public void CrearPopularidadDevuelveEstrategiaPorPopularidad()
    {
        List<Usuario> usuarios = new();

        var estrategia = StrategyFactory.Crear("popularidad", usuarios);

        Assert.IsType<EstrategiaPorPopularidad>(estrategia);
    }

    [Fact]
    public void CrearTipoInvalidoDevuelveEstrategiaPorPreferencias()
    {
        List<Usuario> usuarios = new();

        var estrategia = StrategyFactory.Crear("invalido", usuarios);

        Assert.IsType<EstrategiaPorPreferencias>(estrategia);
    }
}
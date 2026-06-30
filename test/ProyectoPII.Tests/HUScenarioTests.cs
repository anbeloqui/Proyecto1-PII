using ProyectoPII.Fachada;
using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using Xunit;
using ProyectoPII.Filtros;
using ProyectoPII.Ordenadores;

namespace ProyectoPII.Tests;

public class HUScenarioTests
{
    [Fact]
    public void HU1_RegistrarUsuario_CreaUsuario()
    {
        Fachada.Fachada sistema = new();

        sistema.RegistrarUsuario(1, "Ana");

        Assert.NotNull(sistema.ObtenerUsuario("Ana"));
    }

    [Fact]
    public void HU2_AgregarPreferencia_LaUsaParaRecomendar()
    {
        Fachada.Fachada sistema = new();
        sistema.RegistrarUsuario(1, "Ana");
        sistema.AgregarPreferencia("Ana", "rock");
        sistema.AgregarCancion(1, "Rock nuevo", "Banda A", new List<string> { "rock" });

        List<IRecomendable> recomendaciones = sistema.Recomendar("Ana");

        Assert.Contains(recomendaciones, item => item.Nombre == "Rock nuevo");
    }

    [Fact]
    public void HU3_VerRecomendaciones_DevuelveLista()
    {
        Fachada.Fachada sistema = new();
        sistema.RegistrarUsuario(1, "Ana");
        sistema.AgregarPreferencia("Ana", "pop");
        sistema.AgregarCancion(1, "Pop moderno", "Banda B", new List<string> { "pop" });

        List<IRecomendable> recomendaciones = sistema.Recomendar("Ana");

        Assert.NotEmpty(recomendaciones);
        Assert.Contains(recomendaciones, item => item.Nombre == "Pop moderno");
    }

    [Fact]
    public void HU4_RecomendacionPorHistorial_NoIncluyeConsumidos()
    {
        Fachada.Fachada sistema = new();
        sistema.RegistrarUsuario(1, "Ana");
        sistema.AgregarPreferencia("Ana", "rock");

        sistema.AgregarCancion(1, "Rock escuchado", "Banda A", new List<string> { "rock" });
        sistema.AgregarCancion(2, "Rock nuevo", "Banda B", new List<string> { "rock" });

        sistema.AgregarInteraccion("Ana", 1, TipoInteraccion.Consumido);

        List<IRecomendable> recomendaciones = sistema.Recomendar("Ana");

        Assert.DoesNotContain(recomendaciones, item => item.Id == 1);
        Assert.Contains(recomendaciones, item => item.Id == 2);
    }

    [Fact]
    public void HU5_RecomendacionPorPreferencias_CoincideConAtributos()
    {
        Fachada.Fachada sistema = new();
        sistema.RegistrarUsuario(1, "Ana");
        sistema.AgregarPreferencia("Ana", "jazz");

        sistema.AgregarCancion(1, "Jazz suave", "Banda C", new List<string> { "jazz" });
        sistema.AgregarCancion(2, "Metal fuerte", "Banda D", new List<string> { "metal" });

        List<IRecomendable> recomendaciones = sistema.Recomendar("Ana", "preferencias");

        Assert.Contains(recomendaciones, item => item.Id == 1);
        Assert.DoesNotContain(recomendaciones, item => item.Id == 2);
    }

    [Fact]
    public void HU6_RecomendacionPorUsuariosSimilares_RecomiendaItemsDeUsuarioSimilar()
    {
        Fachada.Fachada sistema = new();

        sistema.RegistrarUsuario(1, "Ana");
        sistema.RegistrarUsuario(2, "Luis");

        sistema.AgregarPreferencia("Ana", "rock");
        sistema.AgregarPreferencia("Luis", "rock");

        sistema.AgregarCancion(1, "Cancion compartida", "Banda A", new List<string> { "rock" });
        sistema.AgregarCancion(2, "Cancion nueva", "Banda B", new List<string> { "pop" });

        sistema.AgregarInteraccion("Ana", 1, TipoInteraccion.Consumido);
        sistema.AgregarInteraccion("Luis", 1, TipoInteraccion.Consumido);
        sistema.AgregarInteraccion("Luis", 2, TipoInteraccion.Consumido);

        List<IRecomendable> recomendaciones = sistema.Recomendar("Ana", "similares");

        Assert.Contains(recomendaciones, item => item.Id == 2);
        Assert.DoesNotContain(recomendaciones, item => item.Id == 1);
    }

    [Fact]
    public void HU7_RecomendacionPorPopularidad_NoFallaSinHistorial()
    {
        Fachada.Fachada sistema = new();

        sistema.RegistrarUsuario(1, "Nuevo");
        sistema.RegistrarUsuario(2, "Ana");
        sistema.RegistrarUsuario(3, "Luis");

        sistema.AgregarCancion(1, "Popular", "Banda A", new List<string> { "rock" });

        sistema.AgregarInteraccion("Ana", 1, TipoInteraccion.Consumido);
        sistema.AgregarInteraccion("Luis", 1, TipoInteraccion.Consumido);

        List<IRecomendable> recomendaciones = sistema.Recomendar("Nuevo", "popularidad");

        Assert.Contains(recomendaciones, item => item.Id == 1);
    }

    [Fact]
    public void HU8_FiltrarPorAtributo_RefinaRecomendacionesPorAtributo()
    {
        List<IRecomendable> items = new()
        {
            new Cancion { Id = 1, Nombre = "Rock", Artista = "A", Atributos = new() { "rock" } },
            new Cancion { Id = 2, Nombre = "Metal", Artista = "B", Atributos = new() { "metal" } }
        };

        FiltroPorAtributo filtro = new("metal");

        List<IRecomendable> filtrados = filtro.Filtrar(items);

        Assert.Single(filtrados);
        Assert.Contains(filtrados, item => item.Id == 2);
        Assert.DoesNotContain(filtrados, item => item.Id == 1);
    }

    [Fact]
    public void HU9_OrdenarRecomendaciones_AplicaCriterioDeOrden()
    {
        List<IRecomendable> items = new()
        {
            new Cancion { Id = 1, Nombre = "Zeta", Artista = "A", Atributos = new() { "rock" } },
            new Cancion { Id = 2, Nombre = "Alfa", Artista = "B", Atributos = new() { "pop" } }
        };

        OrdenadorPorNombre ordenador = new();

        List<IRecomendable> ordenados = ordenador.Ordenar(items);

        Assert.Equal("Alfa", ordenados[0].Nombre);
        Assert.Equal("Zeta", ordenados[1].Nombre);
    }

    [Fact]
    public void HU10_RegistrarInteraccion_GuardaConsumoEnHistorial()
    {
        Fachada.Fachada sistema = new();

        sistema.RegistrarUsuario(1, "Ana");
        sistema.AgregarInteraccion("Ana", 1, TipoInteraccion.Consumido);

        List<Interaccion> historial = sistema.VerHistorial("Ana");

        Assert.Contains(historial, i =>
            i.ItemId == 1 &&
            i.Tipo == TipoInteraccion.Consumido);
    }

    [Fact]
    public void HU11_LikeDislike_RegistraValoraciones()
    {
        Fachada.Fachada sistema = new();

        sistema.RegistrarUsuario(1, "Ana");
        sistema.Like("Ana", 1);
        sistema.Dislike("Ana", 2);

        List<Interaccion> historial = sistema.VerHistorial("Ana");

        Assert.Contains(historial, i => i.ItemId == 1 && i.Tipo == TipoInteraccion.Like);
        Assert.Contains(historial, i => i.ItemId == 2 && i.Tipo == TipoInteraccion.Dislike);
    }

    [Fact]
    public void HU12_VerHistorial_MuestraInteracciones()
    {
        Fachada.Fachada sistema = new();

        sistema.RegistrarUsuario(1, "Ana");
        sistema.AgregarInteraccion("Ana", 1, TipoInteraccion.Consumido);

        List<Interaccion> historial = sistema.VerHistorial("Ana");

        Assert.Single(historial);
        Assert.Equal(1, historial[0].ItemId);
    }

    [Fact]
    public void HU13_NoRecomendarConsumidos_ExcluyeItemsDelHistorial()
    {
        Fachada.Fachada sistema = new();

        sistema.RegistrarUsuario(1, "Ana");
        sistema.AgregarPreferencia("Ana", "rock");

        sistema.AgregarCancion(1, "Rock viejo", "Banda A", new List<string> { "rock" });
        sistema.AgregarCancion(2, "Rock nuevo", "Banda B", new List<string> { "rock" });

        sistema.AgregarInteraccion("Ana", 1, TipoInteraccion.Consumido);

        List<IRecomendable> recomendaciones = sistema.Recomendar("Ana");

        Assert.DoesNotContain(recomendaciones, item => item.Id == 1);
        Assert.Contains(recomendaciones, item => item.Id == 2);
    }

    [Fact]
    public void HU14_GuardarParaDespues_RegistraGuardado()
    {
        Fachada.Fachada sistema = new();

        sistema.RegistrarUsuario(1, "Ana");
        sistema.GuardarParaDespues("Ana", 1);

        List<Interaccion> historial = sistema.VerHistorial("Ana");

        Assert.Contains(historial, i =>
            i.ItemId == 1 &&
            i.Tipo == TipoInteraccion.Guardado);
    }

    [Fact]
    public void HU15_ContenidoRelacionado_RecomiendaItemsSimilares()
    {
        Fachada.Fachada sistema = new();

        sistema.RegistrarUsuario(1, "Ana");

        sistema.AgregarCancion(1, "Rock base", "Banda A", new List<string> { "rock", "guitarra" });
        sistema.AgregarCancion(2, "Rock relacionado", "Banda B", new List<string> { "rock", "guitarra" });
        sistema.AgregarCancion(3, "Pop distinto", "Banda C", new List<string> { "pop" });

        sistema.AgregarInteraccion("Ana", 1, TipoInteraccion.Consumido);

        List<IRecomendable> recomendaciones = sistema.Recomendar("Ana", "contenido");

        Assert.Contains(recomendaciones, item => item.Id == 2);
        Assert.DoesNotContain(recomendaciones, item => item.Id == 3);
    }

    [Fact]
    public void HU16_EliminarItem_NoApareceEnCatalogo()
    {
        Fachada.Fachada sistema = new();

        sistema.AgregarCancion(1, "Cancion eliminada", "Banda A", new List<string> { "rock" });
        sistema.EliminarItem(1);

        List<IRecomendable> items = sistema.ObtenerItems();

        Assert.DoesNotContain(items, item => item.Id == 1);
    }
}
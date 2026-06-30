classDiagram
direction LR

class IRecomendable {
  <<interface>>
  +int Id
  +string Nombre
  +List~string~ Atributos
}

class Cancion {
  +int Id
  +string Nombre
  +string Artista
  +List~string~ Atributos
}

Cancion ..|> IRecomendable

class Usuario {
  +int Id
  +string Nombre
  +List~string~ Preferencias
  +List~int~ HistorialIds
  +Historial Historial
}

class TipoInteraccion {
  <<enum>>
  Consumido
  Like
  Dislike
  Guardado
}

class Interaccion {
  +int UsuarioId
  +int ItemId
  +TipoInteraccion Tipo
  +DateTime Fecha
}

class Historial {
  +Agregar(Interaccion)
  +ObtenerTodas() List~Interaccion~
  +ObtenerItemsConsumidos() List~int~
  +ObtenerItemsConLike() List~int~
  +ObtenerItemsGuardados() List~int~
}

Usuario "1" --> "1" Historial
Historial "1" --> "*" Interaccion
Interaccion --> TipoInteraccion

class Catalogo {
  +AgregarItem(IRecomendable)
  +EliminarItem(int)
  +ObtenerItems() List~IRecomendable~
}

Catalogo "1" --> "*" IRecomendable

class Fachada {
  +RegistrarUsuario(int, string)
  +AgregarItem(IRecomendable)
  +EliminarItem(int)
  +AgregarCancion(int, string, string, List~string~)
  +ObtenerUsuario(string) Usuario
  +AgregarPreferencia(string, string)
  +AgregarInteraccion(string, int, TipoInteraccion)
  +Like(string, int)
  +Dislike(string, int)
  +GuardarParaDespues(string, int)
  +ObtenerItems() List~IRecomendable~
  +VerHistorial(string) List~Interaccion~
  +Recomendar(string) List~IRecomendable~
  +Recomendar(string, string) List~IRecomendable~
}

Fachada --> Usuario
Fachada --> Catalogo
Fachada --> RecommendationEngine
Fachada --> StrategyFactory

class IEstrategiaRecomendacion {
  <<interface>>
  +Recomendar(Usuario, List~IRecomendable~) List~IRecomendable~
}

class EstrategiaPorPreferencias
class EstrategiaPorHistorial
class EstrategiaPorPopularidad
class EstrategiaPorUsuariosSimilares
class EstrategiaPorContenidoRelacionado

EstrategiaPorPreferencias ..|> IEstrategiaRecomendacion
EstrategiaPorHistorial ..|> IEstrategiaRecomendacion
EstrategiaPorPopularidad ..|> IEstrategiaRecomendacion
EstrategiaPorUsuariosSimilares ..|> IEstrategiaRecomendacion
EstrategiaPorContenidoRelacionado ..|> IEstrategiaRecomendacion

class StrategyFactory {
  +Crear(string, List~Usuario~) IEstrategiaRecomendacion
}

StrategyFactory ..> IEstrategiaRecomendacion : create

class IFiltroRecomendacion {
  <<interface>>
  +Filtrar(List~IRecomendable~) List~IRecomendable~
}

class FilterChain {
  +AgregarFiltro(IFiltroRecomendacion)
  +Filtrar(List~IRecomendable~) List~IRecomendable~
}

class FiltroNoRepetirConsumidos
class FiltroPorAtributo

FilterChain ..|> IFiltroRecomendacion
FiltroNoRepetirConsumidos ..|> IFiltroRecomendacion
FiltroPorAtributo ..|> IFiltroRecomendacion
FilterChain "1" --> "*" IFiltroRecomendacion

class IRanker {
  <<interface>>
  +Ordenar(List~IRecomendable~) List~IRecomendable~
}

class PreferenceRanker {
  +Ordenar(List~IRecomendable~) List~IRecomendable~
}

PreferenceRanker ..|> IRanker

class IOrdenadorRecomendacion {
  <<interface>>
  +Ordenar(List~IRecomendable~) List~IRecomendable~
}

class OrdenadorPorNombre {
  +Ordenar(List~IRecomendable~) List~IRecomendable~
}

OrdenadorPorNombre ..|> IOrdenadorRecomendacion

class RecommendationEngine {
  +RecommendationEngine(IEstrategiaRecomendacion)
  +RecommendationEngine(IEstrategiaRecomendacion, IFiltroRecomendacion, IRanker)
  +Recomendar(Usuario, List~IRecomendable~) List~IRecomendable~
}

RecommendationEngine --> IEstrategiaRecomendacion
RecommendationEngine --> IFiltroRecomendacion
RecommendationEngine --> FilterChain
RecommendationEngine --> IRanker

class Recomendador {
  +Recomendador()
  +Recomendador(IEstrategiaRecomendacion)
  +Recomendar(Usuario, List~IRecomendable~) List~IRecomendable~
}

Recomendador --> IEstrategiaRecomendacion
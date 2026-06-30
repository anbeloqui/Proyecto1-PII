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
}

Usuario "1" --> "1" Historial
Historial "1" --> "*" Interaccion

class Catalogo {
  +AgregarItem(IRecomendable)
  +EliminarItem(int)
  +ObtenerItems() List~IRecomendable~
}

Catalogo "1" --> "*" IRecomendable

class Fachada {
  +RegistrarUsuario(int, string)
  +AgregarCancion(int, string, string, List~string~)
  +AgregarPreferencia(string, string)
  +AgregarInteraccion(string, int, TipoInteraccion)
  +Like(string, int)
  +Dislike(string, int)
  +GuardarParaDespues(string, int)
  +Recomendar(string) List~IRecomendable~
  +Recomendar(string, string) List~IRecomendable~
  +VerHistorial(string) List~Interaccion~
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

class RecommendationEngine {
  +Recomendar(Usuario, List~IRecomendable~) List~IRecomendable~
}

RecommendationEngine --> IEstrategiaRecomendacion
RecommendationEngine --> FilterChain
RecommendationEngine --> IRanker

class StrategyFactory {
  +Crear(string, List~Usuario~) IEstrategiaRecomendacion
}

StrategyFactory ..> IEstrategiaRecomendacion : create

class IFiltroRecomendacion {
  <<interface>>
  +Filtrar(Usuario, List~IRecomendable~) List~IRecomendable~
}

class FilterChain {
  +AgregarFiltro(IFiltroRecomendacion)
  +Filtrar(Usuario, List~IRecomendable~) List~IRecomendable~
}

FilterChain "1" --> "*" IFiltroRecomendacion

class IRanker {
  <<interface>>
  +Ordenar(List~IRecomendable~, Usuario) List~IRecomendable~
}

class PreferenceRanker

PreferenceRanker ..|> IRanker
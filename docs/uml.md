classDiagram
direction LR

class DiscordBot
class BotCore
class IComandoDiscord {
  <<interface>>
  +Nombre string
  +EjecutarAsync(SocketMessage, string[]) Task
}

class ComandoPing
class ComandoAyuda
class ComandoRegistrar
class ComandoPreferencia
class ComandoRecomendar
class ComandoHistorial
class ComandoLike
class ComandoDislike
class ComandoGuardar
class ComandoConsumido

DiscordBot --> BotCore
BotCore --> IComandoDiscord

IComandoDiscord <|.. ComandoPing
IComandoDiscord <|.. ComandoAyuda
IComandoDiscord <|.. ComandoRegistrar
IComandoDiscord <|.. ComandoPreferencia
IComandoDiscord <|.. ComandoRecomendar
IComandoDiscord <|.. ComandoHistorial
IComandoDiscord <|.. ComandoLike
IComandoDiscord <|.. ComandoDislike
IComandoDiscord <|.. ComandoGuardar
IComandoDiscord <|.. ComandoConsumido

ComandoRegistrar --> Fachada
ComandoPreferencia --> Fachada
ComandoRecomendar --> Fachada
ComandoHistorial --> Fachada
ComandoLike --> Fachada
ComandoDislike --> Fachada
ComandoGuardar --> Fachada
ComandoConsumido --> Fachada

class Fachada {
  +RegistrarUsuario(int, string)
  +AgregarPreferencia(string, string)
  +AgregarInteraccion(string, int, TipoInteraccion)
  +Like(string, int)
  +Dislike(string, int)
  +GuardarParaDespues(string, int)
  +VerHistorial(string) List~Interaccion~
  +Recomendar(string) List~IRecomendable~
  +Recomendar(string, string) List~IRecomendable~
  +ObtenerItems() List~IRecomendable~
}

class Recomendador
class RecommendationEngine
class StrategyFactory

Fachada --> Catalogo
Fachada --> Usuario
Fachada --> Recomendador
Recomendador --> StrategyFactory
Recomendador --> RecommendationEngine
RecommendationEngine --> IEstrategiaRecomendacion
RecommendationEngine --> IFiltroRecomendacion
RecommendationEngine --> IRanker

class IEstrategiaRecomendacion {
  <<interface>>
  +Recomendar(Usuario, List~IRecomendable~) List~IRecomendable~
}

class EstrategiaPorPreferencias
class EstrategiaPorHistorial
class EstrategiaPorPopularidad
class EstrategiaPorUsuariosSimilares
class EstrategiaPorContenidoRelacionado

IEstrategiaRecomendacion <|.. EstrategiaPorPreferencias
IEstrategiaRecomendacion <|.. EstrategiaPorHistorial
IEstrategiaRecomendacion <|.. EstrategiaPorPopularidad
IEstrategiaRecomendacion <|.. EstrategiaPorUsuariosSimilares
IEstrategiaRecomendacion <|.. EstrategiaPorContenidoRelacionado

StrategyFactory ..> IEstrategiaRecomendacion : crea

class IFiltroRecomendacion {
  <<interface>>
  +Filtrar(List~IRecomendable~) List~IRecomendable~
}

class FilterChain
class FiltroNoRepetirConsumidos
class FiltroPorAtributo

IFiltroRecomendacion <|.. FilterChain
IFiltroRecomendacion <|.. FiltroNoRepetirConsumidos
IFiltroRecomendacion <|.. FiltroPorAtributo
FilterChain --> IFiltroRecomendacion

class IRanker {
  <<interface>>
  +Ordenar(List~IRecomendable~) List~IRecomendable~
}

class PreferenceRanker
IRanker <|.. PreferenceRanker

class IOrdenadorRecomendacion {
  <<interface>>
  +Ordenar(List~IRecomendable~) List~IRecomendable~
}

class OrdenadorPorNombre
IOrdenadorRecomendacion <|.. OrdenadorPorNombre

class IRecomendable {
  <<interface>>
  +Id int
  +Nombre string
  +Atributos List~string~
}

class Cancion {
  +Id int
  +Nombre string
  +Artista string
  +Atributos List~string~
}

class Pelicula {
  +Id int
  +Nombre string
  +Director string
  +Atributos List~string~
}

IRecomendable <|.. Cancion
IRecomendable <|.. Pelicula

class Catalogo {
  +AgregarItem(IRecomendable)
  +EliminarItem(int)
  +ObtenerItems() List~IRecomendable~
}

Catalogo --> IRecomendable

class Usuario {
  +Id int
  +Nombre string
  +Preferencias List~string~
  +Historial Historial
}

class Historial {
  +Agregar(Interaccion)
  +ObtenerTodas() List~Interaccion~
  +ObtenerItemsConsumidos() List~int~
  +ObtenerItemsConLike() List~int~
  +ObtenerItemsGuardados() List~int~
}

class Interaccion {
  +UsuarioId int
  +ItemId int
  +Tipo TipoInteraccion
  +Fecha DateTime
}

class TipoInteraccion {
  <<enum>>
  Consumido
  Like
  Dislike
  Guardado
}

Usuario --> Historial
Historial --> Interaccion
Interaccion --> TipoInteraccion

class CancionesIniciales
class PeliculasIniciales
class UsuariosIniciales

DiscordBot --> CancionesIniciales
DiscordBot --> PeliculasIniciales
DiscordBot --> UsuariosIniciales

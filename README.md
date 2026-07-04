# Proyecto PII

Sistema de recomendaciones para Discord desarrollado en C# como proyecto de Programación II.

El sistema permite registrar usuarios, gestionar preferencias, recomendar canciones y películas, registrar interacciones y consultar el historial mediante un bot de Discord.

## Integrantes

- Alejandro Erburo
- Andrés Beloqui

---

## Funcionalidades

- Registro de usuarios.
- Preferencias personalizadas.
- Recomendación de canciones y películas.
- Estrategias de recomendación:
  - Preferencias
  - Historial
  - Popularidad
  - Usuarios similares
  - Contenido relacionado
- Historial de interacciones.
- Registro de Like, Dislike, Guardado y Consumido.
- Catálogo inicial de canciones, películas y usuarios de demostración.
- Bot de Discord funcional.

---

## Arquitectura

El proyecto fue desarrollado aplicando principios **SOLID**, GRASP y patrones de diseño.

Patrones utilizados:

- Facade
- Strategy
- Factory
- Composite / FilterChain
- Command

Los comandos del bot interactúan exclusivamente con la **Fachada**, evitando el acceso directo al dominio y al motor de recomendaciones.

---

## Tecnologías

- C#
- .NET 10
- Discord.Net
- xUnit
- Doxygen
- Mermaid
- Git / GitHub

---

## Ejecutar el proyecto

Restaurar dependencias:

```bash
dotnet restore
```

Compilar:

```bash
dotnet build
```

Ejecutar pruebas:

```bash
dotnet test
```

Ejecutar el bot:

```bash
dotnet run --project src/Program
```

El token del bot se lee desde:

```text
~/.microsoft/usersecrets/RecommenderBot/secrets.json
```

---

## Comandos del bot

| Comando | Descripción |
|---------|-------------|
| `!ping` | Verifica el funcionamiento del bot. |
| `!ayuda` | Muestra los comandos y preferencias disponibles. |
| `!registrar` | Registra al usuario de Discord. |
| `!preferencia <preferencia>` | Agrega una preferencia al usuario. |
| `!recomendar` | Recomienda canciones y películas usando preferencias. |
| `!recomendar canciones` | Recomienda solo canciones. |
| `!recomendar peliculas` | Recomienda solo películas. |
| `!recomendar popularidad` | Recomienda según popularidad. |
| `!recomendar historial` | Recomienda según historial del usuario. |
| `!recomendar similares` | Recomienda según usuarios similares. |
| `!recomendar contenido` | Recomienda contenido relacionado. |
| `!recomendar popularidad canciones` | Combina estrategia y tipo de contenido. |
| `!like <id>` | Registra un Like. |
| `!dislike <id>` | Registra un Dislike. |
| `!guardar <id>` | Guarda un elemento. |
| `!consumido <id>` | Marca un elemento como consumido. |
| `!historial` | Muestra el historial del usuario. |

---

## Ejemplo de uso

```text
!registrar
!preferencia rock
!preferencia ciencia ficcion
!recomendar
!recomendar popularidad canciones
!like 23
!guardar 1001
!consumido 1002
!historial
```

---

## Documentación

- UML: `docs/uml.md`
- Imagen UML: `docs/UML.png`
- Doxygen: `docs/html/index.html`

---

## Organización del proyecto

```text
src/
 ├── Library/
 │   ├── Bot/
 │   ├── DatosIniciales/
 │   ├── Estrategias/
 │   ├── Excepciones/
 │   ├── Fachada/
 │   ├── Filtros/
 │   ├── Interfaces/
 │   ├── Modelos/
 │   ├── Ordenadores/
 │   └── Servicios/
 └── Program/

test/
docs/
```

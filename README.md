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
- Historial de interacciones.
- Registro de Like, Dislike, Guardado y Consumido.
- Catálogo inicial de canciones y películas.
- Bot de Discord.

---

## Arquitectura

El proyecto fue desarrollado aplicando principios **SOLID**, GRASP y distintos patrones de diseño.

Patrones utilizados:

- Facade
- Strategy
- Factory
- Composite (FilterChain)
- Command

Los comandos del bot interactúan exclusivamente con la **Fachada**, evitando el acceso directo al dominio.

---

## Tecnologías

- C#
- .NET 10
- Discord.Net
- xUnit
- Doxygen
- Mermaid

---

## Ejecutar el proyecto

Restaurar dependencias

```bash
dotnet restore
```

Compilar

```bash
dotnet build
```

Ejecutar pruebas

```bash
dotnet test
```

Ejecutar el bot

```bash
dotnet run --project src/Program
```

---

## Comandos del bot

| Comando | Descripción |
|---------|-------------|
| `!registrar` | Registra al usuario. |
| `!preferencia <preferencia>` | Agrega una preferencia. |
| `!recomendar` | Recomienda canciones y películas. |
| `!recomendar canciones` | Recomienda solo canciones. |
| `!recomendar peliculas` | Recomienda solo películas. |
| `!like <id>` | Registra un Like. |
| `!dislike <id>` | Registra un Dislike. |
| `!guardar <id>` | Guarda un elemento. |
| `!consumido <id>` | Marca un elemento como consumido. |
| `!historial` | Muestra el historial del usuario. |
| `!ping` | Verifica el funcionamiento del bot. |

---

## Ejemplo

```text
!registrar
!preferencia rock
!preferencia ciencia ficcion
!recomendar peliculas
!like 1001
!historial
```

---

## Documentación

- UML: `docs/uml.png`
- Doxygen: `docs/html/index.html`

---

## Organización del proyecto

```
src/
 ├── Library
 │   ├── Bot
 │   ├── DatosIniciales
 │   ├── Estrategias
 │   ├── Fachada
 │   ├── Filtros
 │   ├── Interfaces
 │   ├── Modelos
 │   ├── Ordenadores
 │   └── Servicios
 └── Program

test/
docs/
```

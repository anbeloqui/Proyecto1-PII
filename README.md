# Proyecto PII

Sistema de recomendaciones musicales desarrollado en C# para el curso Programación II.

El proyecto implementa un motor de recomendaciones desacoplado basado en estrategias, filtros y ordenadores. Permite registrar usuarios, cargar preferencias, registrar interacciones y generar recomendaciones de canciones mediante una arquitectura orientada a objetos.

---

# Integrantes

- Alejandro Erburo
- Andrés Beloqui

---

# Descripción

El sistema permite:

- Registrar usuarios.
- Administrar un catálogo de canciones recomendables.
- Registrar preferencias musicales de los usuarios.
- Registrar historial de interacciones.
- Generar recomendaciones utilizando distintas estrategias, como preferencias, historial, usuarios similares y contenido relacionado.
- Interactuar con el sistema mediante un bot de Discord.

El proyecto fue desarrollado aplicando principios **SOLID**, buenas prácticas de programación orientada a objetos y patrones de diseño.

---

# Patrones de diseño utilizados

## Facade

Se utiliza el patrón **Facade** mediante la clase `Fachada`.

Esta clase proporciona un único punto de acceso al sistema y evita que las capas externas, como el bot de Discord o los tests, accedan directamente a las clases internas del dominio.

## Strategy

Se utiliza el patrón **Strategy** para permitir cambiar el algoritmo de recomendación sin modificar el resto del sistema.

De esta forma, el motor de recomendaciones puede trabajar con distintas estrategias de recomendación.

## Factory

Se utiliza una fábrica para encapsular la creación de las distintas estrategias de recomendación.

Esto permite centralizar la decisión de qué estrategia utilizar según el tipo de recomendación solicitado.

## Composite / FilterChain

Se utilizan filtros encadenados para aplicar distintas condiciones sobre las recomendaciones antes de devolver el resultado final.

## Command

Los comandos del bot de Discord están separados en clases independientes.

Cada comando implementa una interfaz común, lo que permite registrar y ejecutar comandos de forma ordenada desde `BotCore`.

## Ordenadores

Se implementaron componentes independientes para ordenar las recomendaciones según distintos criterios, manteniendo desacoplado el motor de recomendaciones.

---

# Tecnologías utilizadas

- C#
- .NET 10
- Discord.Net
- xUnit
- Doxygen
- Mermaid
- Git
- GitHub

---

# Estructura del proyecto

```text
ProyectoPII/
│
├── src/
│   ├── Library/
│   │   ├── Bot/
│   │   ├── DatosIniciales/
│   │   ├── Estrategias/
│   │   ├── Excepciones/
│   │   ├── Fachada/
│   │   ├── Filtros/
│   │   ├── Interfaces/
│   │   ├── Modelos/
│   │   ├── Ordenadores/
│   │   ├── Servicios/
│   │   └── ProyectoPII.csproj
│   │
│   └── Program/
│       ├── Program.cs
│       └── ProyectoPII.Program.csproj
│
├── test/
│   └── ProyectoPII.Tests/
│
├── docs/
│   ├── uml.md
│   ├── uml.png
│   └── html/
│
├── ProyectoPII.slnx
└── README.md
```

---

# Principales componentes

## Fachada

La clase `Fachada` centraliza el acceso al sistema.

Desde esta clase se puede:

- Registrar usuarios.
- Agregar canciones al catálogo.
- Agregar preferencias.
- Registrar interacciones.
- Consultar historial.
- Generar recomendaciones.

El uso de la Fachada permite que las demás capas no dependan directamente de las clases internas del dominio.

## Motor de recomendaciones

El motor de recomendaciones trabaja con estrategias, filtros y ordenadores.

Esto permite separar responsabilidades y facilitar futuras modificaciones o nuevas formas de recomendar contenido.

## Bot de Discord

El proyecto incluye un bot de Discord que permite interactuar con el sistema mediante comandos.

La clase `DiscordBot` se encarga de configurar el cliente de Discord, iniciar la conexión y delegar los mensajes recibidos a `BotCore`.

La clase `BotCore` registra los comandos disponibles, identifica cuál debe ejecutarse y maneja las excepciones de dominio para evitar que el bot se detenga ante errores esperados.

## Comandos del bot

Cada comando del bot está implementado en una clase separada.

Esto permite mantener el código organizado y evita que toda la lógica quede concentrada en una sola clase.

## Catálogo inicial

El sistema carga un catálogo inicial de canciones desde la clase:

```text
ProyectoPII.DatosIniciales.CancionesIniciales
```

Esta clase contiene un conjunto amplio de canciones populares y conocidas, con atributos como:

```text
rock, pop, latino, reggaeton, electronica, romantica, fiesta, motivacional, clasico, baile
```

Estos atributos son utilizados por el sistema para generar recomendaciones a partir de las preferencias del usuario.

---

# Requisitos

- .NET 10 SDK
- Git
- Cuenta de Discord
- Bot creado en el portal de desarrolladores de Discord

---

# Restaurar dependencias

Desde la raíz del proyecto:

```bash
dotnet restore ProyectoPII.slnx
```

---

# Compilar el proyecto

Desde la raíz del proyecto:

```bash
dotnet build ProyectoPII.slnx
```

---

# Ejecutar las pruebas

Desde la raíz del proyecto:

```bash
dotnet test ProyectoPII.slnx
```

---

# Ejecutar el bot de Discord

Para ejecutar el bot es necesario configurar el token de Discord como variable de entorno.

El token no debe escribirse directamente en el código ni subirse al repositorio.

## Configurar token en PowerShell

```powershell
$env:DISCORD_TOKEN="TU_TOKEN_DE_DISCORD"
```

## Ejecutar el bot

Desde la raíz del proyecto:

```bash
dotnet run --project src/Program/ProyectoPII.Program.csproj
```

Si el token fue configurado correctamente, el bot iniciará sesión en Discord y quedará escuchando mensajes.

---

# Comandos disponibles del bot

| Comando | Descripción |
|---|---|
| `!ping` | Verifica si el bot responde correctamente. |
| `!registrar` | Registra al usuario de Discord en el sistema. |
| `!preferencia <preferencia>` | Agrega una preferencia musical al usuario. |
| `!recomendar` | Genera recomendaciones según las preferencias del usuario. |
| `!historial` | Muestra el historial de interacciones del usuario. |
| `!like <id>` | Registra una interacción positiva sobre una canción. |
| `!dislike <id>` | Registra una interacción negativa sobre una canción. |
| `!guardar <id>` | Guarda una canción para escuchar después. |

---

# Ejemplo de uso del bot

```text
!registrar
!preferencia rock
!recomendar
```

Con ese flujo, el usuario queda registrado, se agrega una preferencia musical y luego el sistema genera recomendaciones de canciones relacionadas con esa preferencia.

Otro ejemplo:

```text
!registrar
!preferencia latino
!recomendar
```

También se pueden utilizar preferencias como:

```text
pop
rock
latino
reggaeton
electronica
romantica
fiesta
motivacional
clasico
baile
```

---

# Manejo de errores

El proyecto incluye excepciones propias del dominio para representar errores esperados del sistema.

Por ejemplo:

- Usuario no encontrado.
- Usuario ya registrado.
- Datos inválidos.

Estas excepciones permiten diferenciar errores de negocio de errores técnicos inesperados.

En el bot de Discord, las excepciones de dominio se manejan desde `BotCore`.

Por ejemplo, si un usuario intenta agregar una preferencia sin estar registrado:

```text
!preferencia rock
```

El bot no se detiene, sino que responde indicando que primero debe registrarse:

```text
No estás registrado. Usá !registrar antes de continuar.
```

---

# Pruebas

El proyecto incluye pruebas unitarias con xUnit.

Las pruebas verifican funcionalidades principales del sistema, incluyendo:

- Registro de usuarios.
- Manejo de usuarios repetidos.
- Manejo de usuarios inexistentes.
- Validación de datos inválidos.
- Recomendaciones.
- Historial de interacciones.
- Funcionamiento de la Fachada.

Para ejecutar las pruebas:

```bash
dotnet test ProyectoPII.slnx
```

---

# Documentación

La documentación generada con Doxygen se encuentra en:

```text
docs/html/index.html
```

El diagrama UML se encuentra en:

```text
docs/uml.md
docs/uml.png
```

---

# Gestión del proyecto

El desarrollo fue organizado mediante un tablero de Trello:

[Trello del proyecto](https://trello.com/b/OyemCGIp/mi-tablero-de-trello)

---

# Control de versiones

El proyecto fue desarrollado utilizando Git y GitHub.

Se trabajó con ramas de desarrollo y Pull Requests para integrar las distintas funcionalidades al proyecto principal.

---

# Decisiones de diseño

El sistema fue organizado buscando mantener responsabilidades separadas:

- `DiscordBot` se encarga de la conexión con Discord.
- `BotCore` registra y ejecuta comandos.
- Los comandos interactúan con el sistema mediante la Fachada.
- `Fachada` centraliza el acceso a la lógica principal.
- `CancionesIniciales` carga los datos iniciales del catálogo.
- Las excepciones de dominio representan errores propios del sistema.
- El motor de recomendaciones trabaja con estrategias, filtros y ordenadores.

Esta organización facilita el mantenimiento, la lectura del código y la incorporación de nuevas funcionalidades.

---

# Seguridad

El token del bot de Discord no debe guardarse en el código fuente.

Debe configurarse mediante una variable de entorno:

```powershell
$env:DISCORD_TOKEN="TU_TOKEN_DE_DISCORD"
```

De esta manera, el token no queda expuesto en GitHub.

---

# Estado del proyecto

- Registro de usuarios.
- Gestión del catálogo.
- Catálogo inicial de canciones.
- Historial de interacciones.
- Motor de recomendaciones.
- Estrategias de recomendación.
- Filtros de recomendaciones.
- Ordenadores de recomendaciones.
- Bot de Discord funcional.
- Comandos separados.
- Manejo de excepciones de dominio.
- Pruebas unitarias y de historias de usuario.
- Documentación XML.
- Documentación con Doxygen.
- Diagrama UML.

---

# Autores

- Alejandro Erburo
- Andrés Beloqui

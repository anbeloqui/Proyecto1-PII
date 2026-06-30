# Proyecto PII

Sistema de recomendaciones desarrollado en C# para el curso Programación II.

El proyecto implementa un motor de recomendaciones desacoplado basado en estrategias, filtros y ordenadores, permitiendo recomendar distintos tipos de contenido mediante una arquitectura orientada a objetos.

---

# Integrantes

- Alejandro Erburo
- Andrés Beloqui

---

# Descripción

El sistema permite:

- Registrar usuarios.
- Administrar un catálogo de elementos recomendables.
- Registrar preferencias de los usuarios.
- Registrar historial de interacciones.
- Generar recomendaciones utilizando distintas estrategias, como preferencias, historial, usuarios similares y contenido relacionado.

El proyecto fue desarrollado aplicando principios **SOLID**, buenas prácticas de programación orientada a objetos y patrones de diseño.

---

# Patrones de diseño utilizados

- **Facade**
  - Proporciona un único punto de acceso al sistema mediante la clase `Fachada`.

- **Strategy**
  - Permite cambiar el algoritmo de recomendación sin modificar el resto del sistema.

- **Factory**
  - Encapsula la creación de las distintas estrategias de recomendación.

- **Composite (FilterChain)**
  - Permite aplicar múltiples filtros sobre las recomendaciones antes de devolver el resultado final.

- **Ordenadores**
  - Se implementaron componentes independientes para ordenar las recomendaciones según distintos criterios, manteniendo desacoplado el motor de recomendaciones.    

---

# Tecnologías utilizadas

- C#
- .NET 10
- xUnit
- Doxygen
- Mermaid (UML)
- Git
- GitHub

---

# Estructura del proyecto

```text
Proyecto1-PII/
│
├── src/
│   └── Library/
│       ├── Bot/
│       ├── Estrategias/
│       ├── Fachada/
│       ├── Filtros/
│       ├── Interfaces/
│       ├── Modelos/
│       ├── Ordenadores/
│       ├── Servicios/
│       └── ProyectoPII.csproj
│
├── test/
│   └── ProyectoPII.Tests/
│
├── docs/
│   ├── uml.md
│   ├── uml.png
│   └── (documentación generada por Doxygen)
│
├── ProyectoPII.slnx
└── README.md
```

---

# Requisitos

- .NET 10 SDK
- Git

---

# Restaurar dependencias

```bash
dotnet restore ProyectoPII.slnx
```

---

# Compilar el proyecto

```bash
dotnet build ProyectoPII.slnx
```

---

# Ejecutar las pruebas

```bash
dotnet test ProyectoPII.slnx
```

---

# Documentación

La documentación generada con Doxygen se encuentra en:

- `docs/html/index.html`

El diagrama UML se encuentra en:

- `docs/uml.md`
- `docs/uml.png`

```text
docs/
├── uml.md
└── uml.png
```

---

# Gestión del proyecto

El desarrollo fue organizado mediante un tablero de Trello:

[Trello del proyecto](https://trello.com/b/OyemCGIp/mi-tablero-de-trello)

---

# Control de versiones

El proyecto fue desarrollado utilizando Git y GitHub, trabajando con ramas de desarrollo y Pull Requests para integrar las distintas funcionalidades.

---

# Estado del proyecto

✔ Registro de usuarios.
✔ Gestión del catálogo.
✔ Historial de interacciones.
✔ Motor de recomendaciones.
✔ Estrategias de recomendación.
✔ Filtros de recomendaciones.
✔ Pruebas unitarias y de historias de usuario.
✔ Documentación XML.
✔ Diagrama UML.

---

## Autores

- Alejandro Erburo
- Andrés Beloqui

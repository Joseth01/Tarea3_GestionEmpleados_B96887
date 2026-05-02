# Sistema de Gestión de Empleados

## Información del Estudiante
- Joseth Rojas Reyes B96887

---

## Descripción del Proyecto
Aplicación web desarrollada en ASP.NET Core MVC que permite gestionar empleados de una empresa. El sistema incluye funcionalidades de creación, edición, búsqueda y paginación de registros, utilizando Entity Framework Core y el patrón Repositorio.

---

## Funcionalidades

- Registro de empleados
- Edición de empleados
- Búsqueda por nombre, apellidos o departamento
- Paginación de resultados
- Activación y desactivación lógica (ToggleActivo)
- Visualización del estado (Activo / Dado de Baja)

---

## Tecnologías Utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- C#
- Bootstrap

---

## Arquitectura

El proyecto está estructurado en capas:

- MODEL: Entidades del sistema
- DAL: Acceso a datos (Repositorio + DbContext)
- BL: Lógica de negocio
- WEB: Interfaz de usuario (MVC)

---

## Instrucciones de Ejecución

1. Ejecutar el script ubicado en la carpeta `script` para crear la base de datos.
2. Verificar la cadena de conexión en `appsettings.json`.
3. Ejecutar el proyecto desde Visual Studio.
4. Acceder a la ruta `/Empleados`.

---

## Ejemplo de uso

- `/Empleados` → Lista paginada
- `/Empleados?busqueda=TI` → Filtra por departamento
- `/Empleados?busqueda=Ana` → Filtra por nombre

---

## Paginación

El sistema muestra los resultados en páginas de 5 registros, indicando:

- Página actual
- Total de páginas
- Total de registros encontrados

---

## Notas

El sistema no elimina registros físicamente. En su lugar, utiliza un estado lógico (`Activo`) para habilitar o deshabilitar empleados.

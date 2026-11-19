# SDD: préstamos de la biblioteca escolar

Este documento manda. Si el código y el documento no coinciden, se corrige el código.

## Objetivo

**OBJ-001.** Que los alumnos pidan libros desde el sistema y que la biblioteca sepa en todo momento quién tiene
qué libro.

## Casos de uso

**CU-002 · Pedir un libro.**

1. El alumno elige un libro.
2. El sistema revisa las reglas de préstamo.
3. Si se cumplen, registra el préstamo con la fecha de hoy. Si no, muestra el motivo del rechazo.

## Reglas de negocio

### Ya implementada

**RN-001 · Máximo de préstamos.** Un alumno no puede tener más de 3 libros prestados al mismo tiempo.
Ejemplo: Ana tiene 3; pide "El Principito"; se rechaza.

### Párrafo 1 (IDs RN-101, RN-102)

<!-- La pareja del párrafo 1 escribe aquí sus reglas. -->

### Párrafo 2 (IDs RN-201, RN-202)

<!-- La pareja del párrafo 2 escribe aquí sus reglas. -->

### Párrafo 3 (IDs RN-301, RN-302)

<!-- La pareja del párrafo 3 escribe aquí sus reglas. -->

### Párrafo 4 (IDs RN-401, RN-402)

<!-- La pareja del párrafo 4 escribe aquí sus reglas. -->

### Párrafo 5 (IDs RN-501, RN-502)

<!-- La pareja del párrafo 5 escribe aquí sus reglas. -->

## Criterios de aceptación

**AC-007 · verifica RN-001.**
Dado que Ana tiene 3 préstamos activos,
cuando pide otro libro,
entonces se rechaza con "Ya tienes 3 libros prestados".

<!-- Cada pareja agrega aquí sus criterios con el mismo número de párrafo: AC-101, AC-102, AC-201... -->

## Historias de usuario

**US-003 · Pedir un libro.** Como alumno, quiero pedir un libro, para leerlo en casa. Criterios: AC-007.

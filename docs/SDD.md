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

**RN-101 · Duración del préstamo.** Un préstamo dura 7 días naturales desde el día en que se pide. Ejemplo: Ana pide "El Principito" el 2026-11-19; el préstamo expira el 2026-11-26.

**RN-102 · Renovación.** Un préstamo se puede renovar por 7 días adicionales, pero solo una vez. Ejemplo: "El Principito" pedido el 2026-11-19 se puede renovar hasta el 2026-12-03, pero no una segunda vez.

### Párrafo 2 (IDs RN-201, RN-202)

<!-- La pareja del párrafo 2 escribe aquí sus reglas. -->

### Párrafo 3 (IDs RN-301, RN-302)

**RN-301 · Libros de consulta interna.** Los diccionarios y las enciclopedias no se prestan, solo se leen en la biblioteca. Ejemplo: "Diccionario de la Lengua Española" no se puede prestar.

**RN-302 · No se repite libro.** Un alumno no puede tener prestado dos veces el mismo libro. Ejemplo: Ana ya tiene "El Principito"; no puede pedirlo otra vez.

### Párrafo 4 (IDs RN-401, RN-402)

**RN-401 · Apartar un libro prestado.** Si un libro está prestado a otro alumno, otro puede apartarlo para cuando lo devuelvan.
Ejemplo: "Rayuela" está prestado a Luis; Carlos lo aparta; la reserva se crea exitosamente.

**RN-402 · Libro apartado no se renueva.** Si un libro tiene apartado activo, el alumno que lo tiene prestado no puede renovarlo.
Ejemplo: "Rayuela" tiene un apartado; Luis intenta renovarlo; se rechaza con "El libro está apartado".

### Párrafo 5 (IDs RN-501)

**RN-501 · Nuevo ingreso.** Durante su primer mes en la escuela, un alumno de nuevo ingreso solo puede tener 1 libro prestado. Ejemplo: Luis es nuevo ingreso; tiene 1 libro; pide "Rayuela"; se rechaza.

## Criterios de aceptación

**AC-007 · verifica RN-001.**
Dado que Ana tiene 3 préstamos activos,
cuando pide otro libro,
entonces se rechaza con "Ya tienes 3 libros prestados".

**AC-101 · verifica RN-101.**
Dado que se pide un libro el 2026-11-19,
cuando se consulta la fecha de expiración,
entonces es 2026-11-26.

**AC-102 · verifica RN-102.**
Dado que un préstamo del 2026-11-19 se renovó una vez,
cuando intenta renovarse de nuevo,
entonces se rechaza con "Este préstamo ya fue renovado una vez".

**AC-301 · verifica RN-301.**
Dado que un alumno quiere pedir "Diccionario de la Lengua Española",
cuando intenta pedirlo,
entonces se rechaza con "Los diccionarios y enciclopedias son de consulta interna".

**AC-302 · verifica RN-302.**
Dado que Ana ya tiene "El Principito" prestado,
cuando intenta pedir "El Principito" de nuevo,
entonces se rechaza con "Ya tienes este libro prestado".

**AC-501 · verifica RN-501.**
Dado que Luis es alumno de nuevo ingreso y ya tiene 1 libro prestado,
cuando pide otro libro,
entonces se rechaza con "Los alumnos de nuevo ingreso solo pueden tener 1 libro prestado".

<!-- Cada pareja agrega aquí sus criterios con el mismo número de párrafo: AC-101, AC-102, AC-201... AC-601, AC-602... próximamente -->

**AC-401 · verifica RN-401.** Dado que "Rayuela" está prestado a Luis, cuando Carlos intenta apartarlo, entonces la reserva se registra correctamente.

**AC-402 · verifica RN-402.** Dado que "Rayuela" tiene un apartado activo, cuando Luis intenta renovarlo, entonces se rechaza con "El libro está apartado".

## Historias de usuario

**US-003 · Pedir un libro.** Como alumno, quiero pedir un libro, para leerlo en casa. Criterios: AC-007.

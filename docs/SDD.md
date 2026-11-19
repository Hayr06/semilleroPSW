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

### Párrafo 6 (IDs RN-601, RN-602)

**RN-601 · Multa por pérdida.** Al momento que un alumno pierde un libro, se le multa con 300 pesos con la posibilidad de pagar de contado o semanalmente.
Ejemplo: Ana pierde "Cien Años de Soledad"; se le registra una multa de 300 pesos; paga 100 de contado; le quedan 200 pendientes.

**RN-602 · Deuda impide nuevo préstamo.** Mientras un alumno deba una multa, no puede pedir otro libro.
Ejemplo: Ana debe 200 de multa; intenta pedir "1984"; se rechaza con "Tienes una multa pendiente".

## Criterios de aceptación

**AC-007 · verifica RN-001.**
Dado que Ana tiene 3 préstamos activos,
cuando pide otro libro,
entonces se rechaza con "Ya tienes 3 libros prestados".

**AC-601 · verifica RN-601.**
Dado que Ana pierde el libro "Cien Años de Soledad" con fecha 2026-01-15,
entonces se crea una multa de 300 pesos para Ana.

**AC-602 · verifica RN-601.**
Dado que existe una multa de 300 pesos,
cuando Ana paga 100,
entonces la deuda restante es 200.

**AC-603 · verifica RN-602.**
Dado que Ana tiene una multa con deuda restante,
cuando intenta pedir un libro,
entonces se rechaza con "Tienes una multa pendiente".

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

**AC-401 · verifica RN-401.**
Dado que "Rayuela" está prestado a Luis, cuando Carlos intenta apartarlo, entonces la reserva se registra correctamente.

**AC-402 · verifica RN-402.**
Dado que "Rayuela" tiene un apartado activo, cuando Luis intenta renovarlo, entonces se rechaza con "El libro está apartado".

<!-- Cada pareja agrega aquí sus criterios con el mismo número de párrafo: AC-101, AC-102, AC-201... AC-601, AC-602... próximamente -->

## Historias de usuario

**US-003 · Pedir un libro.** Como alumno, quiero pedir un libro, para leerlo en casa. Criterios: AC-007.

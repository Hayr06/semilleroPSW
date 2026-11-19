# Práctica: de una regla a una prueba

Un proyecto pequeño en .NET 10 para practicar el ciclo del semillero: requerimiento → regla (RN) → criterio (AC)
→ prueba → código → pull request.

## Qué hay aquí

| Archivo | Qué es |
|---|---|
| `REQUERIMIENTO.md` | Lo que pidió la biblioteca, en texto corrido. De aquí salen las reglas. |
| `docs/SDD.md` | El documento que manda. Ya trae RN-001 como ejemplo. |
| `src/Biblioteca/` | El código: `Alumno`, `Prestamo` y `Resultado`. |
| `tests/Biblioteca.Tests/` | Las pruebas. Cada una lleva el ID de la regla que protege. |

## Correr las pruebas

```powershell
dotnet test                         # todas
dotnet test --filter "RN=RN-001"    # solo las de una regla
```

## La práctica, paso a paso

El organizador le da a cada pareja un párrafo de `REQUERIMIENTO.md`.

1. Abre el repositorio en OpenCode y corre `/init`.
2. En modo Plan, pide que te explique la estructura. No cambies nada.
3. En pareja, escriban en `docs/SDD.md` 2 reglas (RN) y su criterio (AC) para su párrafo, con los IDs de su
   párrafo (por ejemplo, RN-201 y AC-201 para el párrafo 2). Cada regla lleva un ejemplo con datos reales.
4. Crea tu rama (`feat/rn-201-multa`) y, en modo Build, pide implementar una regla **con su prueba primero**.
   La prueba lleva `[Trait("RN", "RN-201")]` y su nombre empieza con el ID, como `RN201_...`.
5. Revisa el diff: ¿tocó solo lo necesario? ¿inventó algo que no está en el SDD?
6. Commit, push y PR con el ID de la regla en el mensaje: `feat(prestamos): RN-201 multa por día de retraso`.

**Terminado cuando:** la prueba de tu regla pasa, `dotnet test` sigue en verde, el PR está abierto y puedes
explicar cada línea que cambió.

## Pistas

- Las reglas con fechas se prueban pasando la fecha: `PedirLibro("El Principito", new DateOnly(2026, 11, 19))`.
  Nunca dependas del día de hoy en una prueba.
- Si una regla necesita un dato que el código todavía no tiene (por ejemplo, si un libro es de consulta), el
  agente lo va a agregar. Revisa que lo agregue donde tiene sentido y que no invente reglas de más.

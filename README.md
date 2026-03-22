# Itla-P2-CSHARP

Solución en **N capas** para un **Call Center API** enfocada en una sola entidad: `Manager`.

## Estructura
- `CallCenter API/CallCenter API`: Capa API (controladores, DTOs, configuración).
- `CallCenter API/CallCenter.domain`: Capa dominio (entidad `Manager`).
- `CallCenter API/CallCenter.infretruture`: Capa infraestructura (DbContext, repositorios, migraciones).

## Endpoint principal
- `GET /api/manager`

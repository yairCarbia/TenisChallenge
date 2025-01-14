# Torneo de Tenis

Este proyecto modela un torneo de tenis masculino enfocado en un diseño en capas. Construido en **.NET** presentando una API REST que permite gestionar el torneo y obtener los resultados.


---

## Requisitos del Torneo

1. **Modalidad de Eliminación Directa**:  
   - El perdedor de cada encuentro queda eliminado y el ganador avanza a la siguiente ronda.
   - Se eliminan jugadores en cada ronda hasta que quede un único campeón.

2. **Jugadores**:  
   - Todos los participantes son hombres.
   - Cada jugador tiene:
     - **Nombre**.
     - **Nivel de Habilidad** (0-100).
     - **Fuerza**.
     - **Velocidad de Desplazamiento**.
   - No hay empates en los enfrentamientos.

3. **Cálculo del Ganador**:  
   - El ganador de un enfrentamiento se decide en función de:
     - Nivel de habilidad.
     - Parámetros adicionales como fuerza y velocidad.
     - Un factor de suerte para añadir aleatoriedad.

4. **Simulación**:  
   - A partir de una lista de jugadores , siendo potencia de 2 , simula el torneo hasta obtener un unico ganador.

---

## Arquitectura del Proyecto

El proyecto está diseñado siguiendo un enfoque **por capas**, que incluye:

1. **Capa de Datos Abstractos (TDA)**:  
   Modelos que representan los datos del torneo y los jugadores.
   
2. **Capa de Negocio (Business)**:  
   Contiene la lógica de negocio para simular el torneo, calcular los ganadores, y realizar auditorías de los torneos finalizados.

3. **Controladores (Controllers)**:  
   Exponen la funcionalidad del torneo a través de una API REST.

4. **DTOS (Data Transfer Objects)**:  
   Esta capa contiene los objetos de transferencia de datos.

5. **Helpers**:  
   Los helpers o utilitarios contienen funciones auxiliares y métodos comunes que son utilizados por las distintas capas del proyecto. .

6. **Resources (Archivos de recursos)**:  
   Esta capa incluye archivos estáticos y recursos adicionales necesarios para el funcionamiento de la aplicación.

## Endpoints de la API

La API REST está diseñada para interactuar con el torneo. Los controladores exponen los siguientes endpoints:

### **1. Iniciar Torneo**
- **Descripción**: Simula el torneo y retorna el ganador.
- **Método**: `GET`
- **Ruta**: `/api/Torneo/IniciarTorneo`
- **Respuesta**:
  ```json
    {
      "idJugador": "773e2ab2-23a3-4c0b-b2a3-320f31d7b540",
      "nombre": "Juan Hernandez",
      "genero": "Masculino",
      "nivelHabilidad": 85,
      "fuerza": 79,
      "velocidadDesplazamiento": 83
    }
    
### **2. Torneos finalizados**
- **Descripción**: Retorna los torneos finalizados junto a su ganador, con la opción de filtrar por fecha de inicio, fecha de fin y nombre del ganador.
- **Método**: `GET`
- **Ruta**: `/api/Torneo/TorneoFinalizados`
- **Filtros**:
  - `FechaInicio` (opcional): Filtra los torneos por fecha de inicio.
  - `FechaFin` (opcional): Filtra los torneos por fecha de fin.
  - `NombreGanador` (opcional): Filtra los torneos por el nombre del ganador.

- **Respuesta**:
  ```json
    {
     "idTorneo": "4f277e41-13db-4aa1-a7b7-65cfdba8a739",
     "fecha": "2025-01-14T00:00:00-03:00",
     "ganador": "Juan Hernandez"
    }

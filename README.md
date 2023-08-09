# ColmenaApi
# Ejercicio 13 Colmenapi

Por fin tenemos fondos para actualizar nuestra aplicacion a una WebAPI !!!!! :P

Te pasamos el link del repositorio donde se encuentra el codigo de la consola para que lo puedas transformar en una API.

[Colmena_Console](https://dev.azure.com/vy-it-university/Ejercicios/_git/Ejercicio11_Colmena)

## Mejoras

Quemos mantener las funcionalidades que ya existen y añadir nuevas.

Nuevas funcionalidades:

- Mostrar las abejas por cantidad de polen recogido.
- Poder añadir abejas a los registros.
- Poder eliminar abejas.
- Actualizar el estado de las abejas.

## Detalles técnicos
- OOP
- SOLID
- Clean code
- DDD
- Web API
- Swagger
- IOC
- Versioning


## Explicación de la solución

### Controllers

- FilterHiveController: que ya lo teniamos incialmente del ejercicio 11.
- OrderHiveController: utiliza el servicio GetHiveService para obtener la coleccion de abejas ordernada por total recolectado.
- AddBeeController: para añadir nuevas abejas.
- DeleteBeeController: para eliminar abejas por id.
- UpdateBeeController: para actualizar abejas.

### Servicios

- **AddBeeService:** para añadir abejas.
- **DeleteBeeService:** para eliminar abejas por id.
- **UpdateBeeService:** para actualizar abejas por id.

Hasta aqui la relacion es 1 a 1 con los controladores.

- **GetHiveService:** Se ha ampliado el servicio del ejercicio 11 FilterHiveService para que tambien se encargue de la ordenacion. Utilizo LINQ y para la ordenación recibo un property name. Asi el codigo es mucho mas reutilizable.

### Modelos presentación

- **BeeHourlyPerformance:** modelo de respuesta.
- **BeeTotalCollected:** modelo de respuesta.
- **BeeRequest:** modelo de peticion (para el update).

### Modelos de dominio
- **BeeEntity:** modelo de entidad.

### Modelos de infrastructura
- **BeeDTO:** modelo de datos.
- **HiveDTO:** modelo de datos.

### Mappers
- **DomainMapper:** entre la capa de dominio y la de presentación.
- **InfrastructureMapper:** entre la capa de infrastructura y la de dominio.

### Repositorio

- **BeeRepository:** permite añadir, eliminar y actualizar abejas individualmente y cojer coleccion de abejas uniendo ambas persistencias (xml y json).

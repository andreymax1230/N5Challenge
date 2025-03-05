# Challenge Técnico
El Challenge Técnico se desarrollo con Arquitectura EDA (Arquitectura basada en Eventos), utilizando Kafka como cola de mensajeria. 

# Patrones Arquitectonicos:

* Arquitectura EDA
* Arquitectura Limpia

# Patrones de Diseño

* Patrón Repositorio
* Patrón Unit Of Work
* Patrón Request Reply
* Patrón Mediator
* Patrón CQRS

# Base de Datos

* SQL Server para el almacenamiento de la logica del negocio, utiliza una metodología llamada Code First para generar las tablas a traves de clases.
* Mongo DB para el almacenamiento de los eventos.

# Diagrama de diseño
![image](https://github.com/andreymax1230/N5Challenge/blob/1f71d6d209bab5c6c1856e300fefb6628eb6b178/ArquitecturaEda.drawio.png)

# Ejecución
Para ejecutar el proyecto es necesario ejecutar las imagenes de docker (docker-compose.yaml) que contiene los siguientes servicios para el funcionamiento correcto del proyecto:

* Sql Server 
* Kafka Broker
* Zookeeper
* Mongo DB

Se utiliza una consola de powershell para ejecutar el docker compose, ejemplo:
* cd C:\Users\USER\source\repos\N5.MicroService.Test\N5.Presentation.Api
* docker-compose up -d

Es necesario que todos los servicios estén en ejecucion para ejecutar el proyecto

![image](https://github.com/andreymax1230/N5Test/blob/ff08c8d84f5ccdab9e452ea9f6f2a3355059c6f7/DockerN5.png)

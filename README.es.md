## WeNotify .Net Service

##### Servicio notificaciones en tiempo real

Este proyecto desarrollado en ASP.NET es producto del cual podemos obtener un completo servicio de gestión y envió notificaciones a través de canales y etiquetas, que permite a un tercero poder enviar datos crudos o la estructura estándar de notificaciones para que estas sean atendidas por manejadores o difundidas a varias clientes en tiempo real que estén subscriptos a un canal.



##### Escalable y confiable

Este servicio esta desarrollado en .Net e involucra las mejores practicas y tecnologías que el ecosistema de este solido Stack ofrece, hablamos de SignalR para el soporte de tiempo real, ASP.NET para el montaje del servidor y protocolo http, Bases de datos relacionales, Clean Code para personalización del proyecto con otro grupo de buenas practicas para la colaboración de terceros.



##### Fácil de instalar

Solo tiene que clonar el proyecto e instalar sus dependencias con Nuget, una vez hecho esto, solo quedara ir al appsetting.json típico de cada proyecto con ASP.NET, y establecer sus parámetros de la cadena de conexión y otros temas explicado mas adelante.

```bash
mkdir we-notify
cd we-notify
git clone https://github.com/oliver021/we-notify.git .
cd WeNotify.HttpService
dotnet run
```

Con estos comandos ya habremos puesto andar nuestro servicio, las dependencias se deben instalar automáticamente. 
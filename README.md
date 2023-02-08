# voice-chat
Voice chat application - C Server and C# client code.

## Diferencias entre TCP y UDP
Como ya hemos visto durante el curso, cuando dos hosts (ordenadores, smartphones, etc.) necesitan comunicarse entre sí, es necesario que abran un socket TCP o UDP para permitir la comunicación a través de la correspondiente IP (ya sea pública o privada) y también los puertos. Todas las comunicaciones entre dos o más hosts se realizan a nivel de capa de transporte, ya que es la primera capa donde hay una comunicación punto a punto entre dos o más equipos, y aquí podríamos usar el protocolo TCP o bien el protocolo UDP.

El protocolo TCP es un protocolo de la capa de transporte que es orientado a conexión, esto significa que antes de intercambiar los datos reales hay un paso previo para establecer una comunicación. Este protocolo también garantiza que toda la transmisión de los datos se hace sin errores, el propio TCP se encarga de reenviar los datos nuevamente en caso de que el receptor no los reciba a tiempo o los reciba dañados, además, garantiza también el orden, por lo que nos aseguramos de que los procesos van a recibir todos los datos en orden desde su origen.
<div align="center"><img src="https://user-images.githubusercontent.com/25658967/217520063-8bad884d-9996-48b5-a30e-45e1301b5b35.png" width=70% height=70%></div>

En el caso del protocolo UDP, no es orientado a conexión, es decir que no hay un paso previo en la comunicación sino que se envían los datos directamente. Este protocolo no garantiza que la transmisión se realice sin errores, aunque hará todo lo posible para que así lo haga, además, tampoco garantiza el orden de los datos (o datagramas) que el origen envíe al destino. La parte positiva de UDP es que tiene una cabecera muy pequeña y es muy rápido, ya que no hay una fase de establecimiento de la conexión.
<div align="center"><img src="https://user-images.githubusercontent.com/25658967/217520108-b146e9df-37a4-4cc7-8363-7ade82408f47.png" width=30% height=30%></div>

Dada esta rapidez el protocolo UDP es especialmente útil a la hora de transmitir video y audio, como en el ejemplo que se presenta en este proyecto.

## Funcionamiento de la aplicación
Este repositorio contiene el código de un cliente en C# y un servidor en C. La interfaz del cliente consta de 5 botones tal y como se puede ver en la siguiente captura:
<div align="center"><img src="https://user-images.githubusercontent.com/25658967/217513957-6041d0a1-09f4-4141-b302-034880ceedf2.png" width=40% height=40%></div>

A continuación se detalla su funcionamiento:
* **Record:** Activa el microfono del ordenador y una vez está listo para usarse el fondo cambia de color, tal y como se puede ver en la imagen que hay a continuación.
<div align="center"><img src="https://user-images.githubusercontent.com/25658967/217514023-4914fdbf-fafa-473e-acc4-1b5eb9a623de.png" width=40% height=40%></div>

* **Stop recording:** Detiene la grabación y guarda el audio en un archivo wav.

* **Play:** Reproduce el audio que se acaba de grabar.

* **Send:** Envia el audio por UDP al servidor.

* **Receive:** Recibe el audio que ha enviado el servidor también usando el protocolo UDP

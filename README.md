# Dispocat-backend

El mòdul del backend està realitzat amb DotNet Core 3.1 pensat per ser escalable en cas d'augmentar la demanda. Per tal de poder editar el codi i executar-lo recomanem tenir el **Visual Studio Code** o el **Visual Studio 2019**. En cas de voler fer servir el projecte a nivell professional i tenir el servei executant-se en un servidor cal una llicència. Per a més informació consulteu https://visualstudio.microsoft.com/es/vs/pricing/

Els passos per fer funcionar el projecte que trobareu a continuació es basen en l'ús de **Visual Studio 2019**.

### Setup amb el Visual Studio 2019

Descarregar i instalar qualsevol versió del **Visual Studio 2019**. Podeu descarregar la versió que més s'adapti a les vostres necessitats a https://visualstudio.microsoft.com/es/downloads/. Nosaltres hem fet servir l'edició professional.

Un cop descarregat el IDE cal instalar la versió 3.1 de DotNet core. Podeu trobar la última versió a https://dotnet.microsoft.com/download/dotnet-core/3.1. En el cas del Visual Studio la detecció  dels frameworks de Microsoft instalats és automàtica.

Obrir el Visual Studio 2019, carregar el projecte i comprovar que detecta el framework i no hi ha errors. A continuació cal configurar les claus per poder accedir a base de dades i a les apis de tercers. Les claus i la connexió a base de dades les podeu trobar al fitxer de *Contants*.

* `LOCATION_IQ_API_KEY`: Clau per fer servir la api de Location IQ per fer reverse geocoding. Per més informació consulteu https://locationiq.com/. 
* `GOOGLE_MAPS_API_KEY`: Clau per fer servir la api Placer de Google maps api per obtenir els supermercats propers a la ubicació subministrada. Per a més informació consulteu https://developers.google.com/maps/documentation/javascript/get-api-key?hl=es-419  
* `PostgreConnectionString`: Cadena per connectar-se a la base de dades de PostgreSQL segons la configuració que feu servir. Normalment té el format host=nom_del_host;Database=nom_de_la_base_de_dades;user id=usuari_amb_permisosvs;Password=contrassenya_de_lusuari_amb_permisos

Amb tot això configurat, executem l'aplicació en mode debug i amb el navegador que tinguem seleccionat per defecte ens mostrarà la url http://localhost:5000/api/info on es mostrarà un petit json amb la versió del backend (v1), si la connexió amb base de dades funciona correctament (databaseConnectionEstablished) i la data actual (time).

## Docker (opcional)

Descarregar la versió més recent de Docker des de https://www.docker.com/products/docker-desktop

Obrir una consola i anar dins la carpeta Docker del projecte.

Executeu les següents comandes:

### Crear una xarxa on es connectarà el contenidor de docker (en cas de no haver-ho fet prèviament amb el modul Dispocat-platform)

``` shell
docker network create hackovid-network
```

### Construir la imatge
``` shell
docker-compose build
```

### Posar en marxa el contenidor
``` shell
docker-compose up
```
Podeu afegir el parametre -d per tal que una vegada aixecat el contenidor pogueu continuar fent servir el terminal

### Aturar el contenidor
``` shell
docker-compose down
```
***Nota:*** els fitxers Dockerfile i docker-compose.yml estan configurats per fer-se servir a MacOS Catalina, és possible que alguna comanda sigui lleugerament diferent a entorns amb Windows o Linux

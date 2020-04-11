# hackovid-platform

* `LOCATION_IQ_API_KEY`: Clau per fer servir la api de Location IQ per fer reverse geocoding. Per més informació consulteu https://locationiq.com/. 
* `GOOGLE_MAPS_API_KEY`: Clau per fer servir la api Placer de Google maps api per obtenir els supermercats propers a la ubicació subministrada. Per a més informaciço consulteu https://developers.google.com/maps/documentation/javascript/get-api-key?hl=es-419  
* `PostgreConnectionString`: Cadena per connectar-se a la base de dades de PostgreSQL segons la configuració que feu servir. Normalment té el format host=nom_del_host;Database=nom_de_la_base_de_dades;user id=usuari_amb_permisosvs;Password=contrassenya_de_lusuari_amb_permisos

## Docker (opcional)

Descarregar la versió més recent de Docker des de https://www.docker.com/products/docker-desktop

Obrir una consola i anar dins la carpeta Docker del projecte.

Executeu les següents comandes:

### Crear una xarxa on es connectarà el contenidor de docker (en cas de no haver-ho fet prèviament amb el modul hackovid-platform)
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

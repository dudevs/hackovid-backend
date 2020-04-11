# hackovid-backend




## Docker (opcional)

Descarregar la versió més recent de Docker des de https://www.docker.com/products/docker-desktop

Obrir una consola i anar dins la carpeta Docker del projecte.

Executeu les següents comandes:

### Crear una xarxa on es connectarà el contenidor de docker (en cas de no haver-se fet al hackovid-platform)
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

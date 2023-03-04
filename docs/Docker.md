```ps
docker build -t desafio-api .
docker build -t desafio-app .
```

```ps
docker images
```

|-------------|--------|--------------|
| REPOSITORY  |  TAG   |   IMAGE ID   |
| desafio-api | latest | 6d6766724899 |
| desafio-app | latest | 634463e20269 |
|-------------|--------|--------------|


```ps
docker run -d -p 5001:80 --name api desafio-api
docker run -d -p 5002:80 --name app desafio-app
```

```ps
docker container ls --all
```

```ps
docker container start [CONTAINER_ID]
docker container stop [CONTAINER_ID]
docker container rm [CONTAINER_ID]
```
## Install postgresql with docker

```
docker-compose up -d
```

## Connect to postgresql using psql

### Install psql (on Mac)

```
brew install postgresql
```

### Connect using psql

```
psql -h localhost -p 5432 -U myuser mydatabase
```
* Then paste "mypassword"
# RESTful API with ASP NET Core and .NET 5 

### Requirements:
- **Docker** and **Docker-Compose** installed
- **Docker Daemon** running (e.g **sudo systemctl start docker.service**)

### Running the application
- **cd RestWithASPNETUdemy**
- **docker-compose up -d --build**
- **docker ps -a** to check if containers are running
- **docker logs *"container id or name"*** to see the container logs
- **docker exec -it *"container name"* /bin/bash** to get a bash shell in the container that is running.

### Open the API on Swagger
- API is by default hosted in **http://localhost:44300**


### Postman Collection
- You can import the **JSON** in the **Postman-Collection** directory to your running Postman account for viewing the API requests

### Database
- Docker will create a MYSQL image in a container with the **port 3308** exposed
- Can use any viewer of preference that **supports MYSQL databases**

#### To connect to the database:

- **Hostname:** localhost
- **Port:** 3308
- **Username:** docker
- **Password:** docker

#### Access Front-End 

- Hosted in **http://localhost:80**

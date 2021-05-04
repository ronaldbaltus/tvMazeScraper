# tvMazeScraper

## Setting up
`docker-compose up` will build & start services. After that api calls can be made from the swagger at: http://localhost:5000/swagger .
The Apiserver will restart (with exceptions) when the Database is newly created, the api can start after the Database server is running than and the api can connect succesfully.
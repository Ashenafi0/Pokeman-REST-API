# Pokedex REST API

## Overview
This is a REST API for managing Pokémon data, built with .NET Core and connected to a MongoDB database. The API provides CRUD operations for Pokémon, allowing users to add, update, delete, and fetch Pokémon data.

## Features
- **Create**: Add new Pokémon.
- **Read**: Retrieve all Pokémon or search by ID or name.
- **Update**: Modify existing Pokémon data.
- **Delete**: Remove Pokémon from the database.

---

## Technologies Used
- **.NET Core**: For building the web API.
- **MongoDB**: NoSQL database to store Pokémon data.
- **Swagger**: For API documentation and testing.

---

## Setup Instructions

### Prerequisites
1. Install [.NET SDK](https://dotnet.microsoft.com/download).
2. Install [MongoDB](https://www.mongodb.com/try/download/community) or set up a [MongoDB Atlas](https://www.mongodb.com/cloud/atlas) cluster.
3. Ensure MongoDB is running locally or accessible via a connection string.

### Configuration
1. Open the `appsettings.json` file and configure MongoDB settings:
   ```json
   "MongoDB": {
     "ConnectionString": "mongodb://localhost:27017",
     "DatabaseName": "PokedexDB",
     "PokemonCollectionName": "Pokemons"
   }
   ```

2. Use `appsettings.Development.json` for environment-specific configurations if needed.

### Running the Application
1. Build and run the application:
   ```bash
   dotnet build
   dotnet run
   ```
2. The API will start, typically at `http://localhost:5000` (or `https://localhost:5001`).

### Testing the API
- Open the Swagger interface at `http://localhost:5000/swagger` to explore and test the API.
- Example endpoints:
  - `GET /api/pokemons`: Get all Pokémon.
  - `POST /api/pokemons`: Add a new Pokémon.
  - `PUT /api/pokemons/{id}`: Update a Pokémon.
  - `DELETE /api/pokemons/{id}`: Delete a Pokémon.

---

## Folder Structure
- **Controllers**: Contains API controllers.
- **Models**: Defines data models like `Pokemon`.
- **Services**: Contains business logic, including `PokemonService`.
- **Properties**: Application metadata.
- **appsettings.json**: Configuration file for MongoDB and logging.

---



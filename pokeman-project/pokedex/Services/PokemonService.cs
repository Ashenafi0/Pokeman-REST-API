using pokedex.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace pokedex.Services
{
    // Service class to handle all operations related to Pokemon
    public class PokemonService : IPokemonService
    {
        // MongoDB collection for storing Pokemon data
        private readonly IMongoCollection<Pokemon> _pokemonCollection;

        // Constructor to initialize MongoDB client and database settings
        public PokemonService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            // Create a MongoDB client using the provided connection string
            var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);

            // Access the specified database
            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);

            // Get the collection for Pokemon data
            _pokemonCollection = mongoDatabase.GetCollection<Pokemon>(mongoDBSettings.Value.PokemonCollectionName);
        }

        // Method to fetch all Pokemon from the database
        public async Task<List<Pokemon>> GetPokemons()
        {
            // Find all Pokemon in the collection
            return await _pokemonCollection.Find(_ => true).ToListAsync();
        }

        // Method to fetch a Pokemon by its unique ID
        public async Task<Pokemon> GetPokemonById(string id)
        {
            // Attempt to find a Pokemon with the matching ID
            var pokemon = await _pokemonCollection.Find(p => p.Id == id).FirstOrDefaultAsync();

            // Throw an exception if the Pokemon is not found
            if (pokemon == null)
                throw new Exception("Pokemon not found");

            return pokemon;
        }

        // Method to fetch a Pokemon by its name
        public async Task<Pokemon> GetPokemonByName(string name)
        {
            // Attempt to find a Pokemon with the matching name
            var pokemon = await _pokemonCollection.Find(p => p.Name == name).FirstOrDefaultAsync();

            // Throw an exception if the Pokemon is not found
            if (pokemon == null)
                throw new Exception("Pokemon not found");

            return pokemon;
        }

        // Method to add a new Pokemon to the database
        public async Task<Pokemon> AddPokemon(Pokemon newPokemon)
        {
            // Insert the new Pokemon into the collection
            await _pokemonCollection.InsertOneAsync(newPokemon);
            return newPokemon;
        }

        // Method to update an existing Pokemon's data
        public async Task<Pokemon> UpdatePokemon(string id, Pokemon updatedPokemon)
        {
            // Replace the Pokemon document with the updated data
            var result = await _pokemonCollection.ReplaceOneAsync(p => p.Id == id, updatedPokemon);

            // Throw an exception if no matching document was found
            if (result.MatchedCount == 0)
                throw new Exception("Pokemon not found");

            return updatedPokemon;
        }

        // Method to delete a Pokemon from the database
        public async Task<bool> DeletePokemon(string id)
        {
            // Attempt to delete the Pokemon with the given ID
            var result = await _pokemonCollection.DeleteOneAsync(p => p.Id == id);

            // Throw an exception if no matching document was found
            if (result.DeletedCount == 0)
                throw new Exception("Pokemon not found");

            return true;
        }
    }
}

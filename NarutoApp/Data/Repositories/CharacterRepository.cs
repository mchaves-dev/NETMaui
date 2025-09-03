using NarutoApp.Data.Repositories.Contracts;
using NarutoApp.Models;
using NarutoApp.Responses;
using System.Net.Http.Json;

namespace NarutoApp.Data.Repositories;

public sealed class CharacterRepository : ICharacterRepository
{
    private readonly HttpClient _httpClient;

    public CharacterRepository(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient(ApiSettings.ApiName);
    }

    public async Task<Character?> GetCharacterById(int codCharacter)
    {
        var response = await _httpClient.GetAsync($"/characters/{codCharacter}");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Character>();
        }

        throw new Exception("Failed to load characters");
    }

    public async Task<IEnumerable<Character>?> LoadCharactersAsync(int currentPage = 1)
    {
        var response = await _httpClient.GetAsync($"/characters?page={currentPage}");

        if (response.IsSuccessStatusCode)
        {
            var characterResponse = await response.Content.ReadFromJsonAsync<CharacterResponse>();
            return characterResponse?.characters;
        }

        throw new Exception("Failed to load characters");
    }
}
using NarutoApp.Models;

namespace NarutoApp.Data.Repositories.Contracts;

public interface ICharacterRepository
{
    Task<IEnumerable<Character>?> LoadCharactersAsync(int currentPage = 1);
    Task<Character?> GetCharacterById(int codCharacter);
}
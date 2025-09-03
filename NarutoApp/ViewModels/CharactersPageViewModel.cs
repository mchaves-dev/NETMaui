using NarutoApp.Data.Repositories.Contracts;
using NarutoApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NarutoApp.ViewModels;

public class CharactersPageViewModel : INotifyPropertyChanged
{
    private bool _isBusy;
    private ICharacterRepository _characterRepository;
    private ObservableCollection<Character> _characters;

    public CharactersPageViewModel(ICharacterRepository characterRepository)
    {
        _isBusy = false;
        _characterRepository = characterRepository;
        _characters = new();
    }

    public ObservableCollection<Character> Characters => _characters;

    private async Task LoadCharactersAsync(int currentPage = 1)
    {
        try
        {
            _isBusy = true;

            var characters = await _characterRepository.LoadCharactersAsync(currentPage);

            if (characters is IEnumerable<Character> == false)
                return;

            foreach (var character in characters)
                _characters.Add(character);

            OnPropertyChanged(nameof(_characters));
            OnPropertyChanged(nameof(Characters));
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Ops!", $"Ops, Something went wrong {ex.Message}", "OK");
        }
        finally
        {
            _isBusy = false;
        }
    }

    #region Property changed
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string property)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
    #endregion
}
using NarutoApp.Data.Repositories.Contracts;
using NarutoApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

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

        RemainingItemsThresholdReachedCommand = new Command(async () => await LoadCharactersAsync());

        _ = LoadCharactersAsync();
    }

    public ICommand RemainingItemsThresholdReachedCommand { get; }

    public ObservableCollection<Character> Characters => _characters;

    private async Task LoadCharactersAsync()
    {
        if (_isBusy) return;

        try
        {
            _isBusy = true;

            var currentPage = ( _characters.Count / 20 ) + 1;
            var characters = await _characterRepository.LoadCharactersAsync(currentPage);

            if (characters is IEnumerable<Character> == false) return;

            foreach (var character in characters)
                _characters.Add(character);
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Ops!", $"Ops, Something went wrong {ex.Message}", "OK");
            _isBusy = false;
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
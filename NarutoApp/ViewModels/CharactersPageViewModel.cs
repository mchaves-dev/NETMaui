using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NarutoApp.Data.Repositories.Contracts;
using NarutoApp.Models;

namespace NarutoApp.ViewModels;

public partial class CharactersPageViewModel : ObservableObject
{
	private bool _isBusy;
	private ICharacterRepository _characterRepository;
	private MvvmHelpers.ObservableRangeCollection<Character> _characters;

	public CharactersPageViewModel(ICharacterRepository characterRepository)
	{
		_isBusy = false;
		_characterRepository = characterRepository;
		_characters = new();

		_ = LoadCharactersAsync();
	}

	public MvvmHelpers.ObservableRangeCollection<Character> Characters => _characters;

	[RelayCommand]
	private async Task LoadCharactersAsync()
	{
		if (_isBusy) return;

		try
		{
			_isBusy = true;

			var currentPage = (_characters.Count / 20) + 1;
			var characters = await _characterRepository.LoadCharactersAsync(currentPage);

			if (characters is IEnumerable<Character> == false) return;

			_characters.AddRange(characters);
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
}
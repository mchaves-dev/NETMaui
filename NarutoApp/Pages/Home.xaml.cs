using NarutoApp.Models;
using NarutoApp.Responses;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace NarutoApp.Pages;

public partial class Home : ContentPage
{
	private ObservableCollection<Character> _characters = new ObservableCollection<Character>();
	private int _currentPage = 1;
	private bool _isBuzy = false;

	public Home()
	{
		InitializeComponent();
		clvCharacters.ItemsSource = _characters; // bind uma vez
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		if (_characters.Count == 0)
			LoadCharacters(_currentPage);
	}

	private async void LoadCharacters(int currentPage = 1)
	{
		try
		{
			if (IsBusy) return;

			_isBuzy = true;

			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri("https://dattebayo-api.onrender.com");
				var response = await httpClient.GetAsync($"/characters?page={currentPage}");

				if (response.IsSuccessStatusCode == false)
				{
					await DisplayAlert("Error", $"Ops, Algo não saiu como esperado: {response.StatusCode}", "OK");
				}

				var characterResponse = await response.Content.ReadFromJsonAsync<CharacterResponse>();

				if (characterResponse != null)
				{
					foreach (var item in characterResponse.characters)
					{
						_characters.Add(item);
					}

					clvCharacters.ItemsSource = _characters;
				}
			}
		}
		catch (Exception ex)
		{
			await DisplayAlert("Error", $"Falha ao caregar os personagens: {ex.Message}", "OK");
		}
		finally
		{
			_isBuzy = false;
		}
	}

	private void clvCharacters_RemainingItemsThresholdReached(object sender, EventArgs e)
	{
		LoadCharacters(_currentPage++);
	}
}
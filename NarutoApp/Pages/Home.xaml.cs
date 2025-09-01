using NarutoApp.Models;
using NarutoApp.Responses;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace NarutoApp.Pages;

public partial class Home : ContentPage
{
    public Home()
    {
        InitializeComponent();
        LoadCharactersAsync();
    }

	protected override void OnAppearing()
	{
		base.OnAppearing();
		LoadCharactersAsync();
	}

    private async Task LoadCharactersAsync(int currentPage = 1)
    {
        try
        {
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
                    clvCharacters.ItemsSource = new ObservableCollection<Character>(characterResponse.characters);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Falha ao caregar os personagens: {ex.Message}", "OK");
        }
    }
}
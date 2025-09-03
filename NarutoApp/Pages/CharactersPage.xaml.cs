using NarutoApp.ViewModels;

namespace NarutoApp.Pages;

public partial class CharactersPage : ContentPage
{
	public CharactersPage(CharactersPageViewModel charactersPageViewModel)
	{
		InitializeComponent();
		BindingContext = charactersPageViewModel;
    }
}
using System.ComponentModel;
using System.Windows.Input;

namespace MVVMApp.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    private int _count = 0;
    public string _textCounterBtn = "Click me";

    public string TextCounterBtn => _textCounterBtn;

    public ICommand OnClickedButton { get; }

    public MainPageViewModel()
    {
        OnClickedButton = new Command(IncrementCount);
    }

    private void IncrementCount()
    {
        _count++;

        if (_count == 1)
            _textCounterBtn = $"Clicked {_count} time";
        else
            _textCounterBtn = $"Clicked {_count} times";

        OnPropertyChanged(nameof(TextCounterBtn));

        SemanticScreenReader.Announce(_textCounterBtn);
    }

    #region PropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged(string property)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
    #endregion
}
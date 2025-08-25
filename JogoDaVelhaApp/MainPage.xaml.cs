namespace JogoDaVelhaApp;

public partial class MainPage : ContentPage
{
    private char jogadaAtual = 'X';

    public MainPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var button = (Button) sender;

        if (string.IsNullOrWhiteSpace(button.Text))
        {
            AtualizaJogada(button);
            VerificaGanhador();
        }
    }

    private void AtualizaJogada(Button button)
    {
        if (jogadaAtual == 'X')
        {
            button.Text = "X";
            jogadaAtual = 'O';
        }
        else
        {
            button.Text = "O";
            jogadaAtual = 'X';
        }

        lblRodadaAtual.Text = jogadaAtual.ToString();
    }

    private void VerificaGanhador()
    {
        // LINHA 1
        if (btn10.Text == "X" && btn11.Text == "X" && btn12.Text == "X")
            Ganhou("X");
        else if (btn10.Text == "O" && btn11.Text == "O" && btn12.Text == "O")
            Ganhou("O");

        // LINHA 2
        if (btn20.Text == "X" && btn21.Text == "X" && btn22.Text == "X")
            Ganhou("X");
        else if (btn20.Text == "O" && btn21.Text == "O" && btn22.Text == "O")
            Ganhou("O");

        // LINHA 3
        if (btn30.Text == "X" && btn31.Text == "X" && btn32.Text == "X")
            Ganhou("X");
        else if (btn30.Text == "O" && btn31.Text == "O" && btn32.Text == "O")
            Ganhou("O");

        // COLUNA 1
        if (btn10.Text == "X" && btn20.Text == "X" && btn30.Text == "X")
            Ganhou("X");
        else if (btn10.Text == "O" && btn20.Text == "O" && btn30.Text == "O")
            Ganhou("O");

        // COLUNA 2
        if (btn11.Text == "X" && btn21.Text == "X" && btn31.Text == "X")
            Ganhou("X");
        else if (btn11.Text == "O" && btn21.Text == "O" && btn31.Text == "O")
            Ganhou("O");

        // COLUNA 3
        if (btn12.Text == "X" && btn22.Text == "X" && btn32.Text == "X")
            Ganhou("X");
        else if (btn12.Text == "O" && btn22.Text == "O" && btn32.Text == "O")
            Ganhou("O");

        // DIAGONAL 1
        if (btn10.Text == "X" && btn21.Text == "X" && btn32.Text == "X")
            Ganhou("X");
        else if (btn10.Text == "O" && btn21.Text == "O" && btn32.Text == "O")
            Ganhou("O");

        // DIAGONAL 2
        if (btn12.Text == "X" && btn21.Text == "X" && btn30.Text == "X")
            Ganhou("X");
        else if (btn12.Text == "O" && btn21.Text == "O" && btn30.Text == "O")
            Ganhou("O");

        if (TodosPreenchidos())
            DeuVelha();
    }
    private bool TodosPreenchidos()
    {
        return !string.IsNullOrWhiteSpace(btn10.Text) &&
               !string.IsNullOrWhiteSpace(btn11.Text) &&
               !string.IsNullOrWhiteSpace(btn12.Text) &&
               !string.IsNullOrWhiteSpace(btn20.Text) &&
               !string.IsNullOrWhiteSpace(btn21.Text) &&
               !string.IsNullOrWhiteSpace(btn22.Text) &&
               !string.IsNullOrWhiteSpace(btn30.Text) &&
               !string.IsNullOrWhiteSpace(btn31.Text) &&
               !string.IsNullOrWhiteSpace(btn32.Text);
    }

    private async void DeuVelha()
    {
        await DisplayAlert("Empate", "Deu velha! Ninguém ganhou.", "OK");
        ResetarPartida();
    }
    private async void Ganhou(string jogador)
    {
        await DisplayAlert("Ganhador", $"Jogador {jogador} ganhou!", "OK");

        if (jogador == "X")
            lblPlayer1.Text = ( Convert.ToInt32(lblPlayer1.Text) + 1 ).ToString();
        else
            lblPlayer2.Text = ( Convert.ToInt32(lblPlayer2.Text) + 1 ).ToString();

        ResetarPartida();
    }

    private void ResetarPartida()
    {
        jogadaAtual = ( jogadaAtual == 'X' ) ? 'O' : 'X';
        lblRodadaAtual.Text = jogadaAtual.ToString();

        btn10.Text = string.Empty;
        btn11.Text = string.Empty;
        btn12.Text = string.Empty;
        btn20.Text = string.Empty;
        btn21.Text = string.Empty;
        btn22.Text = string.Empty;
        btn30.Text = string.Empty;
        btn31.Text = string.Empty;
        btn32.Text = string.Empty;
    }
}

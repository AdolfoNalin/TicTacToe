namespace TicTacToe.View;

public partial class Screen : ContentPage
{
    string[,] _board = new string[4, 3];
    private List<Button> _listButton = new List<Button>();

	public Screen()
	{
		InitializeComponent();
	}

    string value = "X";
	#region Button_Clicked
	private void Button_Clicked(object sender, EventArgs e)
	{
		try
		{
            var button = (Button)sender;
            _listButton.Add(button);

            string[] pos = button.CommandParameter.ToString().Split(",");

            int.TryParse(pos[0].ToString(), out int line);
            int.TryParse(pos[1].ToString(), out int column);

            // Marca no tabuleiro
            _board[line, column] = value;

            // Atualiza UI
            button.Text = value;
            button.IsEnabled = false;

            // Verifica vencedor
            if (VerificationResut())
            {
                DisplayAlert("Fim de jogo", $"Jogador {value} venceu!", "OK");
                return;
            }

            // Troca jogador
            value = value == "X" ? "O" : "X";

        }
		catch (Exception ex)
		{
            DisplayAlert("Error", $"{ex.Message}, {ex.StackTrace}, {ex.HelpLink}", "OK");
			throw;
		}
    }
    #endregion

	private void Clear()
	{
		foreach(Button b in  _listButton)
        {
            b.Text = String.Empty;
            b.IsEnabled = true;
        }
	}

	private bool VerificationResut()
	{
		try
		{
            bool result = false;

            string j = value;

            // Linhas
            for (int i = 0; i <= 3; i++)
            {
                if (_board[i, 0] == j &&
                    _board[i, 1] == j &&
                    _board[i, 2] == j)
                    result = true;
            }

            // Colunas
            for (int i = 1; i < 3; i++)
            {
                if (_board[1, i] == j &&
                    _board[2, i] == j &&
                    _board[3, i] == j)
                    result = true;
            }

            // Diagonal principal
            if (_board[1, 0] == j &&
                _board[2, 1] == j &&
                _board[3, 2] == j)
                result = true;

            // Diagonal secundária
            if (_board[3, 2] == j &&
                _board[2, 1] == j &&
                _board[1, 0] == j)
                result = true;

            if (result)
                 Clear();

            return result;
            
		}
		catch (Exception ex)
		{
			DisplayAlert("Error", $"{ex.Message}, {ex.StackTrace}, {ex.HelpLink}", "OK");
            return false;
		}
	}
}
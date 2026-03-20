namespace TicTacToe.View;

public partial class Screen : ContentPage
{
	private int _counter = 0;
	public Screen()
	{
		InitializeComponent();
	}

	#region Button_Clicked
	private void Button_Clicked(object sender, EventArgs e)
	{
		try
		{
			Button btn = (Button)sender;

			if (_counter % 2 == 0)
			{
				btn.Text = "X";
				_counter++;
				btn.IsEnabled = false;
			}
			else
			{
				btn.Text = "O";
				_counter++;
				btn.IsEnabled = false;
			}

			if (btn10.Text == "X" && btn11.Text == "X" && btn12.Text == "X")
			{
				DisplayAlert("Vencedor".ToUpper(), "O jogador X ganhou!", "OK");
			}
		}
		catch (Exception ex)
		{

			throw;
		}
    }
    #endregion

	private void Zerar()
	{

	}
}
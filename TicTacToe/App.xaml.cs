using Microsoft.Extensions.DependencyInjection;
using TicTacToe.View;

namespace TicTacToe
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Screen());
        }
    }
}
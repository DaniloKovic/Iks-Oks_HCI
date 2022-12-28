using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Iks_Oks.GameLogic;
using Iks_Oks.ViewLogic;

namespace Iks_Oks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window // 3x3
    { 
        private const string boardString = "3x3";
        private GameController _gameController = new GameController(boardString);
        private Window _parent;

        private StreamWriter _writer;
        private const string logPath = "C:\\Users\\DaK\\source\\repos\\Iks-Oks\\results3x3.log";

        public MainWindow(Window parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        private void ClickByPlayer(object sender, RoutedEventArgs e)
        {
            if(sender.GetType() == typeof(Button))
            {
                Button b = (Button)sender;

                if (!String.IsNullOrWhiteSpace(b.Content?.ToString())) return;

                if (_gameController.CurrentPlayer.ToString().Equals("X")) // Dinamičko mijenjanje boja za igrače: X->Blue, O->Red
                    b.Foreground = Brushes.Blue;
                else
                    b.Foreground = Brushes.Red;

                string[] coordinates = b.Tag.ToString().Split(',');
                int positionX = Int32.Parse(coordinates[0]);
                int positionY = Int32.Parse(coordinates[1]);
                Position positionOfLastMove = new Position(positionX, positionY);
                _gameController.UpdateGameBoard(positionOfLastMove, _gameController.CurrentPlayer.ToString());

                b.Content = _gameController.CurrentPlayer;
                if (_gameController.numberOfMoves > 4)
                {
                    if(_gameController.CheckIfPlayerWins_3x3() == true)
                    {
                        GameController.winner = true;
                        GameViewLogic.displayWinner(_gameController, lbWinner);
                        GameViewLogic.disableRemainButtons(grid_Iks_Oks);

                        using (_writer = new StreamWriter(logPath, true))
                        {
                            _writer.WriteLine("3x3 " + DateTime.Now.ToString() + " " + lbWinner.Content.ToString() + "\n");
                        }
                    }
                    if (_gameController.numberOfMoves == 9 && (GameController.winner == false)) // DRAW - NERJEŠENO
                    {
                        lbWinner.Foreground = Brushes.White;
                        lbWinner.Content = "Draw ! Play again ?";
                        lbWinner.Visibility = Visibility.Visible;

                        using (_writer = new StreamWriter(logPath, true))
                        {
                            _writer.WriteLine("3x3 " + DateTime.Now.ToString() + " DRAW !\n");
                        }
                    }
                }
                _gameController.SetNextPlayer();
            }
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            if (sender.GetType() == typeof(Button))
                GameViewLogic.StartNewGame(grid_Iks_Oks, lbWinner, _gameController, boardString);
            _gameController = new GameController(boardString);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _parent.Show();
            this.Close();
        }

        private void MouseEnterByPlayer(object sender, RoutedEventArgs e)
        {

        }

        private void MouseLeaveByPlayer(object sender, RoutedEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Iks_Oks.GameLogic;

namespace Iks_Oks.ViewLogic
{
    public class GameViewLogic
    {
        public static void disableRemainButtons(Grid gameGrid)
        {
            foreach (Control c in gameGrid.Children)
            {
                if (c.GetType() == typeof(Button)) // <==> if(c is Button)
                    ((Button)c).IsEnabled = false;
            }
        }

        public static void displayWinner(GameController game, Label lb)
        {
            if (game.CurrentPlayer.Equals("X"))
            {
                lb.Foreground = Brushes.Blue;
                lb.Content = "Player X is winner !";
                lb.Opacity = 0.5;
            }
            else
            {
                lb.Foreground = Brushes.Red;
                lb.Content = "Player O is winner !";
                lb.Opacity = 0.5;
            }
            lb.Visibility = Visibility.Visible;
        }

        public static void StartNewGame(Grid grid, Label lb, GameController game, string boardString)
        {
            lb.Visibility = Visibility.Hidden;
            foreach (Control c in grid.Children)
            {
                if (c.GetType() == typeof(Button)) // <==> if(c is Button)
                    ((Button)c).IsEnabled = true;
            }
            foreach (Control c in grid.Children)
            {
                if (c.GetType() == typeof(Button)) // <==> if(c is Button)
                    ((Button)c).Content = null;
            }
            game.gameBoard = null;
            // game = new GameController(boardString);
        }
    }
}

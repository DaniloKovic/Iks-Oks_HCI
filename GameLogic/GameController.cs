using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iks_Oks.GameLogic
{
    public class GameController
    {
        private const string PlayerX = "X";
        private const string PlayerO = "O";
        public int numberOfMoves = 1;
        public string CurrentPlayer { get; set; }
        public string[,] gameBoard = null;

        private bool bigBoard = true;
        public static bool winner = false;
        

        public GameController(string boardSize) 
        {
            CurrentPlayer = PlayerX;
            Random rnd = new Random();

            if(boardSize.Equals("3x3"))
            {
                bigBoard = false;
                gameBoard = new string[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                        gameBoard[i, j] = "" + rnd.Next(0, 50).ToString(); // popunjavanje niza pseudoslučajnim vrijednostima
                }
            }
            else
            {
                bigBoard = true;
                gameBoard = new string[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                        gameBoard[i, j] = "" + rnd.Next(0, 50).ToString(); // popunjavanje niza pseudoslučajnim vrijednostima
                }
            }
            winner = false;
        }

        public void SetNextPlayer()
        {
            if (CurrentPlayer.Equals(PlayerX))
                CurrentPlayer = PlayerO;
            else
                CurrentPlayer = PlayerX;

            ++numberOfMoves;
        }

        public void UpdateGameBoard(Position p, string currentPlayer)
        {
            int x = p.positionX;
            int y = p.positionY;
            gameBoard[x, y] = currentPlayer; // Vrijednosti polja su X ili Y, u zavisnosti koji je igrač na potezu
        }

        public bool CheckIfPlayerWins_3x3()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((gameBoard[i, 0].Equals(gameBoard[i, 1])) && (gameBoard[i, 1].Equals(gameBoard[i, 2])) && (gameBoard[i, 0].Equals(gameBoard[i, 2]))) // Provjera vertikalnih redova
                        winner = true;

                    if ((gameBoard[0, j].Equals(gameBoard[1, j])) && (gameBoard[1, j].Equals(gameBoard[2, j])) && (gameBoard[0, j].Equals(gameBoard[2, j]))) // Provjera horizontalnih redova
                        winner = true;
                }
            }
            if ((gameBoard[0, 0].Equals(gameBoard[1, 1])) && (gameBoard[1, 1].Equals(gameBoard[2, 2])) && (gameBoard[0, 0].Equals(gameBoard[2, 2]))) // Glavna dijagonala
                winner = true;

            if ((gameBoard[0, 2].Equals(gameBoard[1, 1])) && (gameBoard[1, 1].Equals(gameBoard[2, 0])) && (gameBoard[0, 2].Equals(gameBoard[2, 0]))) // Sporedna dijagonala
                winner = true;

            if (winner == true)
            { 
                return true;
            }
            else
                return false;
        }

        public bool CheckIfPlayerWins_5x5()
        {
            for (int i = 0; i < 5; i++) // provjera po vrstama
            {
                    if ( ( (gameBoard[i, 0].Equals(gameBoard[i, 1])) && (gameBoard[i, 1].Equals(gameBoard[i, 2])) && (gameBoard[i, 2].Equals(gameBoard[i, 3])) && (gameBoard[i, 0].Equals(gameBoard[i, 3])) ) ||
                         ( (gameBoard[i, 1].Equals(gameBoard[i, 2])) && (gameBoard[i, 2].Equals(gameBoard[i, 3])) && (gameBoard[i, 3].Equals(gameBoard[i, 4])) && (gameBoard[i, 1].Equals(gameBoard[i, 4]))) ) // Provjera vertikalnih redova (po vrstama)
                        return true;
            }

            for(int j = 0; j < 5; j++) // provjera po kolonama
            {
                if ( ( (gameBoard[0, j].Equals(gameBoard[1, j])) && (gameBoard[1, j].Equals(gameBoard[2, j])) && (gameBoard[2, j].Equals(gameBoard[3, j])) && (gameBoard[0, j].Equals(gameBoard[3, j]) ) ) ||
                   ( ( (gameBoard[1, j].Equals(gameBoard[2, j])) && (gameBoard[2, j].Equals(gameBoard[3, j])) && (gameBoard[3, j].Equals(gameBoard[4, j])) && (gameBoard[1, j].Equals(gameBoard[4, j]) ) ) ) ) // Provjera horizontalnih redova (po kolo0nama)
                    return true;
            }

            // provjera po dijagonalama
            if (((gameBoard[0, 0].Equals(gameBoard[1, 1])) && (gameBoard[1, 1].Equals(gameBoard[2, 2])) && (gameBoard[2, 2].Equals(gameBoard[3, 3])) && (gameBoard[0, 0].Equals(gameBoard[3, 3]))) ||
                ((gameBoard[1, 1].Equals(gameBoard[2, 2])) && (gameBoard[2, 2].Equals(gameBoard[3, 3])) && (gameBoard[3, 3].Equals(gameBoard[4, 4])) && (gameBoard[1, 1].Equals(gameBoard[4, 4])))) // Glavna dijagonala
                return true;

            if ((gameBoard[0, 1].Equals(gameBoard[1, 2])) && (gameBoard[1, 2].Equals(gameBoard[2, 3])) && (gameBoard[2, 3].Equals(gameBoard[3, 4]))) 
                return true;

            if ((gameBoard[1, 0].Equals(gameBoard[2, 1])) && (gameBoard[2, 1].Equals(gameBoard[3, 2])) && (gameBoard[3, 2].Equals(gameBoard[4, 3])))
                return true;

            
            if (((gameBoard[0, 4].Equals(gameBoard[1, 3])) && (gameBoard[1, 3].Equals(gameBoard[2, 2])) && (gameBoard[2, 2].Equals(gameBoard[3, 1])) && (gameBoard[0, 4].Equals(gameBoard[3, 1]))) ||
                ((gameBoard[1, 3].Equals(gameBoard[2, 2])) && (gameBoard[2, 2].Equals(gameBoard[3, 1])) && (gameBoard[3, 1].Equals(gameBoard[4, 0])) && (gameBoard[1, 3].Equals(gameBoard[4, 0])))) // Glavna dijagonala
                return true;

            if ((gameBoard[0, 3].Equals(gameBoard[1, 2])) && (gameBoard[1, 2].Equals(gameBoard[2, 1])) && (gameBoard[2, 1].Equals(gameBoard[3, 0])))
                return true;

            if ((gameBoard[1, 4].Equals(gameBoard[2, 3])) && (gameBoard[2, 3].Equals(gameBoard[3, 2])) && (gameBoard[3, 2].Equals(gameBoard[4, 1])))
                return true;

            return false;
        }
    }
}

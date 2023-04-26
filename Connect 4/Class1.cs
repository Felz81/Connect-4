using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    internal class Board
    {
        public string[] board;
        public static int xWin;
        public static int oWin;

        public Board()
        {
            // Un string pour chacune des cases du tableau de jeu
            board = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42" };
        }

        public void printBoard()
        {
            // Créeation du tableau de jeu utilisant les valeurs du tableau board
            Console.WriteLine(" Rangée: 1     2     3     4     5     6     7");
            Console.WriteLine("_______________________________________________________________________");
            Console.WriteLine("         {0} _|_ {1} _|_ {2} _|_ {3} _|_ {4} _|_ {5} _|_ {6} ", GetValueOrEmpty(0), GetValueOrEmpty(1), GetValueOrEmpty(2), GetValueOrEmpty(3), GetValueOrEmpty(4), GetValueOrEmpty(5), GetValueOrEmpty(6));
            Console.WriteLine("         {0} _|_ {1} _|_ {2} _|_ {3} _|_ {4} _|_ {5} _|_ {6} ", GetValueOrEmpty(7), GetValueOrEmpty(8), GetValueOrEmpty(9), GetValueOrEmpty(10), GetValueOrEmpty(11), GetValueOrEmpty(12), GetValueOrEmpty(13));
            Console.WriteLine("         {0} _|_ {1} _|_ {2} _|_ {3} _|_ {4} _|_ {5} _|_ {6} ", GetValueOrEmpty(14), GetValueOrEmpty(15), GetValueOrEmpty(16), GetValueOrEmpty(17), GetValueOrEmpty(18), GetValueOrEmpty(19), GetValueOrEmpty(20));
            Console.WriteLine("         {0} _|_ {1} _|_ {2} _|_ {3} _|_ {4} _|_ {5} _|_ {6} ", GetValueOrEmpty(21), GetValueOrEmpty(22), GetValueOrEmpty(23), GetValueOrEmpty(24), GetValueOrEmpty(25), GetValueOrEmpty(26), GetValueOrEmpty(27));
            Console.WriteLine("         {0} _|_ {1} _|_ {2} _|_ {3} _|_ {4} _|_ {5} _|_ {6} ", GetValueOrEmpty(28), GetValueOrEmpty(29), GetValueOrEmpty(30), GetValueOrEmpty(31), GetValueOrEmpty(32), GetValueOrEmpty(33), GetValueOrEmpty(34));
            Console.WriteLine("         {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |  {6} ", GetValueOrEmpty(35), GetValueOrEmpty(36), GetValueOrEmpty(37), GetValueOrEmpty(38), GetValueOrEmpty(39), GetValueOrEmpty(40), GetValueOrEmpty(41));
        }

        // Pour utiliser la valeur du tableau board sans les voir directement sur le tableau de jeu
        private string GetValueOrEmpty(int index)
        {
            return int.TryParse(board[index], out int value) ? " " : board[index];
        }

        // Vérifie si le jeu est terminé avec une des 2 conditions, soit un gagnant ou un tableau plein
        public bool isGameOver()
        {
            return getWinner(board) != null || isBoardFull();
        }

        // Fonction pour vérifier si un joueur a gagné
        public static string getWinner(string[] gameBoard)
        {

            // On vérifie les rangées
            for (int i = 0; i < 39; i++)
            {
                if (gameBoard[i] == gameBoard[i + 1] && gameBoard[i + 1] == gameBoard[i + 2] && gameBoard[i + 2] == gameBoard[i + 3])
                {
                    return gameBoard[i];

                }
            }
            // On vérifies les colonnes
            for (int i = 0; i < 21; i++)
            {
                if (gameBoard[i] == gameBoard[i + 7] && gameBoard[i + 7] == gameBoard[i + 14] && gameBoard[i + 14] == gameBoard[i + 21])
                {
                    return gameBoard[i];
                }
            }
            // On vérifie les diagonales gauche vers droite
            for (int i = 0; i < 14; i++)
            {
                if (gameBoard[i] == gameBoard[i + 8] && gameBoard[i + 8] == gameBoard[i + 16] && gameBoard[i + 16] == gameBoard[i + 24])
                {
                    return gameBoard[i];
                }
            }
            // On vérifie les diagonales de droite vers gauche
            for (int i = 20; i >= 0; i--)
            {
                if (gameBoard[i] == gameBoard[i + 6] && gameBoard[i + 6] == gameBoard[i + 12] && gameBoard[i + 12] == gameBoard[i + 18])
                {
                    return gameBoard[i];
                }
            }
            // Aucun gagnant
            return null;
        }

        // Vérifie si le board est plein
        public bool isBoardFull()
        {
            for (int i = 0; i < 42; i++)
            {
                if (board[i] != "O" || board[i] != "X")
                {
                    return false;
                }
            }
            return true;
        }

        // Envoie le jeton dans le bas de la colonne
        public void makeMove(string[] gameBoard, int index, string symbol)
        {
            if (index < 7)
            {
                if (gameBoard[index + 35] != "X" && gameBoard[index + 35] != "O")
                {
                    index += 35;
                }
                else if (gameBoard[index + 28] != "X" && gameBoard[index + 28] != "O")
                {
                    index += 28;
                }
                else if (gameBoard[index + 21] != "X" && gameBoard[index + 21] != "O")
                {
                    index += 21;
                }
                else if (gameBoard[index + 14] != "X" && gameBoard[index + 14] != "O")
                {
                    index += 14;
                }
                else if (gameBoard[index + 7] != "X" && gameBoard[index + 7] != "O")
                {
                    index += 7;
                }
            }
            // La case est libre, on peut y jouer
            gameBoard[index] = symbol;
        }

        // Fonction pour le calcul du score
        public void updateWinCount(string winner)
        {
            if (winner == "X")
            {
                xWin++;
            }
            else if (winner == "O")
            {
                oWin++;
            }
        }

        public int getXWinCount()
        {
            return xWin;
        }

        public int getOWinCount()
        {
            return oWin;
        }
    }

    class Player
    {
        public string Name = "Player";
        public string Symbol = "O";

        // Fonction pour demander au joueur où il veut placer son jeton
        public int getMove(Board board)
        {
            Console.WriteLine("Entrez le numéro de la colonne où vous voulez placer votre jeton");
            int moveR;
            while (!int.TryParse(Console.ReadLine(), out moveR) || moveR < 1 || moveR > 7 || !board.board.Contains(moveR.ToString()))
            {
                Console.WriteLine("Entrez un numéro de colonne valide");
            }

            return moveR - 1;
        }

    }

    class Computer
    {

        public string Name = "Computer";
        public string Symbol = "X";

        // Fonction pour demander au computer où il veut placer son jeton
        public int getMove(Board board)
        {
            // Vérifie si le computer peut gagner
            for (int j = 0; j < 7; j++)
            {
                if ((board.board[j] != "X" || board.board[j] != "O") && int.TryParse(board.board[j], out _))
                {
                    Board tempBoard = new Board();
                    Array.Copy(board.board, tempBoard.board, board.board.Length); // LA LIGNE QUI FAISAIT EN SORTE QUE MON CODE NE FONCTIONNAIT PAS, FINALEMENT RÉSOLU!!! Quand on copie un tableau, il faut utiliser Array.Copy, simplement faire un nouveau board ne fonctionnait pas. En faisait du debug, je vérifiais mes valeurs et je me suis rendu compte que tempBoard.board n'était pas égal a board.board sans cette ligne.
                    tempBoard.makeMove(tempBoard.board, j, "X");
                    if (Board.getWinner(tempBoard.board) == "X")
                    {
                        return j;
                    }
                }
            }
            // Vérifie si le joueur peut gagner
            for (int j = 0; j < 7; j++)
            {
                if ((board.board[j] != "X" || board.board[j] != "O") && int.TryParse(board.board[j], out _))
                {
                    Board tempBoard = new Board();
                    Array.Copy(board.board, tempBoard.board, board.board.Length);
                    tempBoard.makeMove(tempBoard.board, j, "O");
                    if (Board.getWinner(tempBoard.board) == "O")
                    {
                        return j;
                    }
                }
            }
            // Le jeu joue aléatoirement si les 2 autres function ne sont pas vraies
            Random rng = new Random();
            int move = rng.Next(7);
            while (!board.board.Contains(move.ToString()))
            {
                move = rng.Next(7);

            }
            return move - 1;
        }
    }
}

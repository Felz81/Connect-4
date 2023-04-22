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

        public Board()
        {
            board = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42" };
        }

        public void printBoard()
        {
            Console.WriteLine(" Rangée: 1      2      3      4      5      6      7");
            Console.WriteLine("_______________________________________________________________________");
            Console.WriteLine("         {0}  _|_ {1}  _|_ {2}  _|_ {3}  _|_ {4}  _|_ {5}  _|_ {6} ", board[0], board[1], board[2], board[3], board[4], board[5], board[6]);
            Console.WriteLine("         {0}  _|_ {1}  _|_ {2} _|_ {3 } _|_ {4} _|_ {5} _|_ {6} ", board[7], board[8], board[9], board[10], board[11], board[12], board[13]);
            Console.WriteLine("         {0} _|_ {1} _|_ {2} _|_ {3} _|_ {4} _|_ {5} _|_ {6} ", board[14], board[15], board[16], board[17], board[18], board[19], board[20]);
            Console.WriteLine("         {0} _|_ {1} _|_ {2} _|_ {3} _|_ {4} _|_ {5} _|_ {6} ", board[21], board[22], board[23], board[24], board[25], board[26], board[27]);
            Console.WriteLine("         {0} _|_ {1} _|_ {2} _|_ {3} _|_ {4} _|_ {5} _|_ {6} ", board[28], board[29], board[30], board[31], board[32], board[33], board[34]);
            Console.WriteLine("         {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |  {6} ", board[35], board[36], board[37], board[38], board[39], board[40], board[41]);
        }


        public bool isGameOver()
        {
            return getWinner(board) != null || isBoardFull();
        }

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
            for (int i = 0; i < 20; i++)
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

        public string[] getBoard()
        {
            return board;
        }
    }

    class Player
    {
        public string Name = "Player";
        public string Symbol = "O";
        public string Color = "Red";

        public int getMove(Board board)
        {
            Console.WriteLine("Entrez le numéro de la colonne où vous voulez placer votre jeton");
            int move = Convert.ToInt32(Console.ReadLine());
            while (!board.board.Contains(move.ToString()))
            {
                Console.WriteLine("Entrez un numéro de colonne valide");
                move = Convert.ToInt32(Console.ReadLine());
            }
            return move - 1;
        }
    }

    class Computer
    {

        public string Name = "Computer";
        public string Symbol = "X";
        public string Color = "Yellow";
        public int getMove(Board board)
        {
            // Vérifie si le computer peut gagner
            for (int j = 0; j < 7; j++)
            {
                if (board.getBoard()[j] != "X" || board.getBoard()[j] != "O")
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
                if (board.getBoard()[j] != "X" || board.getBoard()[j] != "O")
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
            // Le jeu joue aléatoirement
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

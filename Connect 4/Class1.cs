﻿using System;
using System.Collections.Generic;
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
            return getWinner() != null || isBoardFull();
        }

        public string getWinner()
        {
            // On vérifie les rangées
            for (int i = 0; i < 6; i += 7)
            {
                if (board[i] == board[i + 1] && board[i + 1] == board[i + 2] && board[i + 2] == board[i + 3])
                {
                    return board[i];
                }
            }
            // On vérifies les colonnes
            for (int i = 0; i < 6; i++)
            {
                if (board[i] == board[i + 7] && board[i + 7] == board[i + 14] && board[i + 14] == board[i + 21])
                {
                    return board[i];
                }
            }
            // On vérifie les diagonales gauche vers droite
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (board[i] == board[i + 8] && board[i + 8] == board[i + 16] && board[i + 16] == board[i + 24])
                    {
                        return board[i];
                    }
                }
            // On vérifie les diagonales de droite vers gauche
            for(int i = 7; i >= 0; i--)
                for(int j = 0; j < 4; j++)
                {
                   if (board[i] == board[i + 8] && board[i + 8] == board[i + 16] && board[i + 16] == board[i + 24])
                    {
                        return board[i];
                    }
                }
            // Aucun gagnant
            return null;
        }

        public bool isBoardFull()
        {
            for (int i = 0; i < 6; i++)
            {
                if (board[i] != "O")
                {
                    return false;
                }
            }
            return true;
        }

        public void makeMove(int index, string symbol)
        {
            board[index] = symbol;
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
            return move -1;
        }
    }

    class Computer
    {
        public string Name ="Computer";
        public string Symbol = "X";
        public string Color = "Yellow";
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


}
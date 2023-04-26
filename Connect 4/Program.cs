using System.Diagnostics.Metrics;

namespace Connect_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Créer un objet de type Board
            Board board = new Board();
            board.printBoard();
            // Créer un objet de type Player
            Player player = new Player();

            // Créer un objet de type Computer
            Computer computer = new Computer();

            // Joueur qui commence
            int currentPlayer = 1;
            Player currentPlayerC = player;
            Computer computerC = computer;

            // Boucle de jeu
            while(!board.isGameOver())
            {
                Console.Clear();
                board.printBoard();

                // Tour du joueur
                if(currentPlayer == 1)
                {
                    Console.WriteLine("C'est au tour de " + player.Name);
                    int move = player.getMove(board);
                    board.makeMove(board.board,move, player.Symbol);
                    currentPlayer = 2;
                }
                else
                {
                    // Tour de l'ordinateur
                    int move = computer.getMove(board);
                    board.makeMove(board.board, move, computer.Symbol);
                    currentPlayer = 1;
                }
            }
            // Impression du board
            Console.Clear();
            board.printBoard();

            // Affiche le gagnant s'il y en a un
            Console.WriteLine("Gagnant:" + Board.getWinner(board.board));
            // Calcul pour le total de victoires
            string winner = Board.getWinner(board.board);
            board.updateWinCount(winner);
            Console.WriteLine("Victoires du joueur 1: {0}", Board.oWin);
            Console.WriteLine("Victoires de l'ordi : {0}", Board.xWin);
            Console.WriteLine("Voulez-vous rejouer? (O/N)");
            char answer;
            while (!char.TryParse(Console.ReadLine(), out answer) || (answer != 'O' && answer != 'N'))
            {
                Console.WriteLine("Entrez un caractère valide");
            }
            if (answer == 'O')
            {
                Main(args);
            }
        }
    }

}
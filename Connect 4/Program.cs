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
                    Console.ForegroundColor = ConsoleColor.Red;
                    board.makeMove(move, player.Symbol);
                    Console.ResetColor();
                    currentPlayer = 2;
                }
                else
                {
                    // Tour de l'ordinateur
                    int move = computer.getMove(board);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    board.makeMove(move, computer.Symbol);
                    Console.ResetColor();
                    currentPlayer = 1;
                }
            }
            // Impression du board
            Console.Clear();
            board.printBoard();

            // Affiche le gagnant s'il y en a un
            Console.WriteLine("Gagnant:" + board.getWinner());

        }
    }
}
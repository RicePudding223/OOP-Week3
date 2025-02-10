using System;

namespace OOP_Week3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            Console.Write("Press any key to exit... ");
            Console.ReadLine();
        }

        public class Game
        {
            public int numberOfTurns;
            public void Start()
            {
                SetNumberOfTurns();
                Player player = new Player();
                for (int i = 0; i < numberOfTurns; i++)
                {
                    player.PlayTurn();
                    player.DeclareWinner();
                }
            }

            public void SetNumberOfTurns()
            {
                Console.Write("Enter the number of turns you want to play: ");
                numberOfTurns = Convert.ToInt32(Console.ReadLine());
            }
        }

        public class Dice
        {
            private Random random = new Random();

            public int Roll()
            {
                return random.Next(1, 7);
            }
        }

        public class Player
        {
            private Dice dice = new Dice();
            private int userScore;
            private int computerScore;

            public int userWins;
            public int computerWins;

            public Player()
            {
                userWins = 0;
                computerWins = 0;
            }

            public void PlayTurn()
            {
                userScore = dice.Roll();
                computerScore = dice.Roll();
            }

            public void DeclareWinner()
            {
                if (userScore > computerScore)
                {
                    Console.WriteLine($"User wins as they got {userScore} and computer got {computerScore}");
                    userWins++;
                }
                else if (userScore < computerScore)
                {
                    Console.WriteLine($"Computer wins as they got {computerScore} and user got {userScore}");
                    computerWins++;
                }
                else
                {
                    Console.WriteLine($"It's a draw as both got {userScore}");
                }
            }
        }
    }
}
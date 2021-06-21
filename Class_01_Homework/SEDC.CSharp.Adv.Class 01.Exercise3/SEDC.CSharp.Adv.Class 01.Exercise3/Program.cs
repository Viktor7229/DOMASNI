using SEDC.CSharp.Adv.Class01.ConsoleApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.CSharp.Adv.Class01.ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player angel = new Player() { Name = "Angel" };
            Player petre = new Player() { Name = "Petre" };
            Player martin = new Player() { Name = "Martin" };
            Player dragan = new Player() { Name = "Dragan" };
            Player damjan = new Player() { Name = "Damjan" };
            Player nikola = new Player() { Name = "Nikola" };
            Player roze = new Player() { Name = "Roze" };
            Player mario = new Player() { Name = "Mario" };
            List<Player> allPlayers = new List<Player>() { angel, petre, martin, dragan, damjan, nikola, roze, mario };
            while (true)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("===========================================");
                Console.WriteLine("           ROCK PAPPER SCISSERS");
                Console.WriteLine("===========================================");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n1) Play\n2) Stats\n3) Leaderboard\n4) Exit");
                Console.Write(" > ");
                string userInput = Console.ReadLine();
                int menuChosen = ChooseMenuItem(userInput);

                switch (menuChosen)
                {
                    case 0:
                        throw new Exception("Invalid input!");
                    case 1:

                        Play(allPlayers);
                        continue;
                    case 2:
                        ShowStats(allPlayers);
                        Exit();
                        continue;
                    case 3:
                        Leaderboard(allPlayers);
                        Exit();
                        break;
                }
                if (menuChosen > 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Good Bye! Until next time!");
                    Console.ReadLine();
                    break;
                }
                Console.ReadLine();
            }
        }

        static int ChooseMenuItem(string userInput)
        {
            int result = 0;
            bool isValidNumber = int.TryParse(userInput, out result);
            return result;
        }
        static void Play(List<Player> players)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("===========================================");
                Console.WriteLine("            AVAILABLE PLAYERS");
                Console.WriteLine("===========================================");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (Player player in players)
                {
                    Console.WriteLine($" - {player.Name}");
                }
                Player firstPlayer = null;
                Player secondPlayer = null;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Choose the first player: ");
                Console.ForegroundColor = ConsoleColor.White;
                string firstPick = Console.ReadLine();
                firstPlayer = players.FirstOrDefault(player => player.Name.ToLower() == firstPick.ToLower());
                if (firstPlayer == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID CHOICE!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Choose the second player: ");
                Console.ForegroundColor = ConsoleColor.White;
                string secondPick = Console.ReadLine();
                secondPlayer = players.FirstOrDefault(player => player.Name.ToLower() == secondPick.ToLower());
                if (secondPlayer == null || firstPlayer.Name.ToLower() == secondPlayer.Name.ToLower())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID CHOICE!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                firstPlayer.GamesPlayed();
                secondPlayer.GamesPlayed();
                int playerOnePickRandom = new Random().Next(1, 3);
                firstPlayer.PlayerChoice = (UserChoice)playerOnePickRandom;
                int playerTwoPickRandom = new Random().Next(1, 3);
                secondPlayer.PlayerChoice = (UserChoice)playerTwoPickRandom;
                string resultText = DecideWinner(firstPlayer, secondPlayer);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(resultText);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Press 'Y' to play again or any key to enter the menu: ");
                string playAgain = Console.ReadLine();
                if (playAgain.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }

        static string DecideWinner(Player playerOne, Player playerTwo)
        {
            if (playerOne.PlayerChoice == UserChoice.Rock && playerTwo.PlayerChoice == UserChoice.Scissors)
            {
                playerOne.GamesWon++;
                return $"Player {playerOne.Name} won!";
            }
            else if (playerOne.PlayerChoice == UserChoice.Rock && playerTwo.PlayerChoice == UserChoice.Paper)
            {
                playerTwo.GamesWon++;
                return $"Player {playerTwo.Name} won!";
            }
            else if (playerOne.PlayerChoice == UserChoice.Scissors && playerTwo.PlayerChoice == UserChoice.Paper)
            {
                playerOne.GamesWon++;
                return $"Player {playerOne.Name} won!";
            }
            else if (playerOne.PlayerChoice == UserChoice.Scissors && playerTwo.PlayerChoice == UserChoice.Rock)
            {
                playerTwo.GamesWon++;
                return $"Player {playerTwo.Name} won!";
            }
            else if (playerOne.PlayerChoice == UserChoice.Paper && playerTwo.PlayerChoice == UserChoice.Scissors)
            {
                playerTwo.GamesWon++;
                return $"Player {playerTwo.Name} won!";
            }
            else if (playerOne.PlayerChoice == UserChoice.Paper && playerTwo.PlayerChoice == UserChoice.Rock)
            {
                playerOne.GamesWon++;
                return $"Player {playerOne.Name} won!";
            }
            else
            {
                playerOne.GamesTied++;
                playerTwo.GamesTied++;
                return $"Its a tie!";
            }
        }
        static void ShowStats(List<Player> totalPlayers)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("===========================================");
            Console.WriteLine("             PLAYER STATISTIC");
            Console.WriteLine("===========================================");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Player player in totalPlayers)
            {
                float tiedPerc = 0;
                float winPerc = 0;
                float lostPerc = 0;
                float gamesLost = (player.TotalGamesPlayed - player.GamesTied) - player.GamesWon;
                if (player.TotalGamesPlayed > 0)
                {
                    winPerc = 100 * (player.GamesWon / player.TotalGamesPlayed);
                    lostPerc = 100 * (gamesLost / player.TotalGamesPlayed);
                    tiedPerc = 100 * (player.GamesTied / player.TotalGamesPlayed);
                }
                Console.WriteLine("===========================");
                Console.WriteLine($"Name: {player.Name}\nTotal Games Played: {player.TotalGamesPlayed}\nGames Won: {player.GamesWon} - {winPerc}%\nGames Lost: {gamesLost} - {lostPerc}%\nGames Tied: {player.GamesTied} - {tiedPerc}%");
                Console.WriteLine("===========================");
            }
        }
        static void Exit()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any key to leave player statistic...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        static void Leaderboard(List<Player> listOfPlayers)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("===========================================");
            Console.WriteLine("               LEADERBOARD");
            Console.WriteLine("===========================================");
            Console.ForegroundColor = ConsoleColor.White;

            listOfPlayers.Sort(delegate (Player x, Player y)
            {
                return y.GamesWon.CompareTo(x.GamesWon);
            });
            for (int i = 0; i < listOfPlayers.Count; i++)
            {
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if (i == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                else if (i == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine($"{i + 1}. {listOfPlayers[i].Name}  Total Winnings: {listOfPlayers[i].GamesWon}");
            }
        }
    }
}
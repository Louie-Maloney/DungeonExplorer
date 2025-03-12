using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        // Main method used to start the game
        static void Main(string[] args)
        {
            // Run tests before starting the game
            Console.WriteLine("Running tests...");
            Testing.Test();
            Console.WriteLine("Tests completed.");

            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.WriteLine("Enter player name: ");
            string playerName = Console.ReadLine();

            // Check if the player name is empty, if so tell the user to enter a valid name
            while (string.IsNullOrEmpty(playerName))
            {
                Console.WriteLine("Player name cannot be empty. Please enter a valid name: ");
                playerName = Console.ReadLine();
            }

            // Create a new game object and start the game
            Game game = new Game(playerName);
            game.Start();
        }
    }
}

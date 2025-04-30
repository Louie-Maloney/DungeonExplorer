using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // This class represents the statistics of the player in the game.
    public class Statistics
    {
        // Properties to store various statistics
        public int TotalDamageDealt { get; private set; }
        public int TotalHealthRestored { get; private set; }
        public int TotalItemsCollected { get; private set; }

        // Constructor to initialize the statistics
        public void AddDamageDealt(int amount)
        {
            TotalDamageDealt += amount;
        }

        // Method to add health restored to the statistics
        public void AddHealthRestored(int health)
        {
            TotalHealthRestored += health;
        }

        // Method to add items collected to the statistics
        public void AddItemCollected()
        {
            TotalItemsCollected++;
        }

        // Method to display the statistics
        public void DisplayStatistics()
        {
            Console.WriteLine("Game Statistics:");
            Console.WriteLine($"Total damage dealt: {TotalDamageDealt}");
            Console.WriteLine($"Total health restored: {TotalHealthRestored}");
            Console.WriteLine($"Total items collected: {TotalItemsCollected}");
        }
    }
}

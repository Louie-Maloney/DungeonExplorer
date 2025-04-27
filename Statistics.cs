using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Statistics
    {
        public int TotalDamageDealt { get; private set; }
        public int TotalHealthRestored { get; private set; }
        public int TotalItemsCollected { get; private set; }

        public void AddDamageDealt(int amount)
        {
            TotalDamageDealt += amount;
        }

        public void AddHealthRestored(int health)
        {
            TotalHealthRestored += health;
        }

        public void AddItemCollected()
        {
            TotalItemsCollected++;
        }

        public void DisplayStatistics()
        {
            Console.WriteLine("Game Statistics:");
            Console.WriteLine($"Total damage dealt: {TotalDamageDealt}");
            Console.WriteLine($"Total health restored: {TotalHealthRestored}");
            Console.WriteLine($"Total items collected: {TotalItemsCollected}");
        }
    }
}
